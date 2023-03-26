using Api.Extensions;
using Api.Middlewares;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("aspbackend")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();


if (app.Environment.IsDevelopment())
{
}
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// using var scope = app.Services.CreateScope();
// var services = scope.ServiceProvider;
// try
// {
//    var context = services.GetRequiredService<AppDataContext>();
//    await context.Database.MigrateAsync(); // equivalent database Update
//    await SeedData.Seed(context);
// }
// catch (Exception ex)
// {
//    var logger = services.GetRequiredService<ILogger<Program>>();
//    logger.LogError(ex, "An Error occured during migration");
// }

app.Run();
