using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product
{
	public class Details
	{
		public class Command : IRequest<Result<ProductDetail>>
		{
			public Guid ProductId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<ProductDetail>>
		{
			private readonly AppDataContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDataContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<Result<ProductDetail>> Handle(Command request, CancellationToken cancellationToken)
			{
				var product = _context.Products
					.Include(p => p.ProductPhotos).Include(p => p.Reviews)
						.ThenInclude(r => r.ReviewReply)
					.Include(p => p.Purchases)
					.First(p => p.ProductId == request.ProductId);

				if (product == null) { return Result<ProductDetail>.Failure("Product does not exist"); }

				var productDetail = _mapper.Map<ProductDetail>(product);

				return Result<ProductDetail>.Success(productDetail);

			}
		}
	}
}
