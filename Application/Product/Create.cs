using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Product
{
    public class Create
    {
        public class Command : IRequest<string>
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

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Product>(request.ProductCreateParam);

                _context.Products.Add(product);

                var success = await _context.SaveChangesAsync()>0;

                if (success) return "Product is updated";
                return "Please try Again";
            }
        }


    }
}
