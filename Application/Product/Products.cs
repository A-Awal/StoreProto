﻿using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.Core;
using AutoMapper.QueryableExtensions;

namespace Application.Product
{
    public class Products
    {
        public class Query:IRequest<Result<List<ProductDto>>>
        {
            public string SearchTerm { get; set; }

        }

        public class Handler: IRequestHandler<Query, Result<List<ProductDto>>>
        {
            private readonly AppDataContext _dataContext;
            private readonly IMapper _mapper;

            public Handler( AppDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<List<ProductDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                 var query =  _dataContext.Products
                    .OrderBy( p => p.ProductName)
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();
                
                if(!String.IsNullOrEmpty(request.SearchTerm))
                {
                    query = query.Where(p => p.ProductName.Contains(request.SearchTerm));
                }
                var products = await query.ToListAsync();
                return Result<List<ProductDto>>.Success(products);
            }
        }
    }
}
