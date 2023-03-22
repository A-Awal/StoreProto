using Application.Core;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Product
{
    public class Create
    {
        public class Command : IRequest<Result<string>>
        {
            public ProductCreateParam ProductCreateParam { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductCreateParam).SetValidator(new ProductValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<string>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Product>(request.ProductCreateParam);

                _context.Products.Add(product);

                var success = await _context.SaveChangesAsync()>0;

                if (success) return Result<string>.Success("Product is updated");
                return Result<string>.Failure("Please try Again");
            }
        }


    }
}
