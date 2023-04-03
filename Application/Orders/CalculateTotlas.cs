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

namespace Application.Orders
{
	public class CalculateTotlas
	{
		public class Query: IRequest<Result<List<OrderDto>>>
		{
			public List<OrderDto> OrderDto { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<OrderDto>>>
		{

			public async Task<Result<List<OrderDto>>> Handle(
				Query request,
				CancellationToken cancellationToken
			)
			{
				foreach (OrderDto dto in request.OrderDto)
				{
					decimal amountDue = dto.Purchases.Aggregate((decimal)0, (t, next) => t + next.AmountDue);
					decimal discountAmount = dto.Purchases.Aggregate((decimal)0, (t, next) => t + next.DiscountAmount);
					dto.DiscountAmount = discountAmount;
					dto.AmountDue = amountDue;

				}

				return Result<List<OrderDto>>.Success(request.OrderDto);
			}
		}
}
}
