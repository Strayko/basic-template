using Demo.Middleware;
using Demo.Services.Employees;
using Demo.Validation;
using FluentValidation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
        .CreateLogger();

    builder.Services.AddCors();

    builder.Logging.AddSerilog(logger);
    builder.Services.AddControllers();
    builder.Services.AddScoped<IEmployeeService, EmployeeService>();
    builder.Services.AddValidatorsFromAssembly(typeof(EmployeeValidator).Assembly);
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());
    
    app.UseCustomExceptionHandler();
    app.MapControllers();
    app.Run();
}