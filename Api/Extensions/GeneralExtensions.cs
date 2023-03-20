using MediatR;
using Application.Core;
using FluentValidation.AspNetCore;
using FluentValidation;
using Application.Product;
using Stripe;
using Api.Services;
using Api.Models;
using Application.Services;
using Infrastructure.Photos;

namespace API.Extensions
{
    public static class GeneralExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(typeof(Products.Handler));
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Create>();

            services.AddScoped<TokenService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<ChargeService>();
            StripeConfiguration.ApiKey = config.GetValue<string>(
                "StripeOptions:SecretKey"
            );

            services.AddScoped<IStripeService, StripeService>();

            services.Configure<SmtpSettings>(config.GetSection("SmtpSettings"));
            services.AddSingleton<IEmailSender, EmailSenderService>();
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();

            return services;
        }
    }
}
