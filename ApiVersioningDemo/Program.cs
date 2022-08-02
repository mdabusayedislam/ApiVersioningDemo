using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
    options.Conventions.Controller<ApiVersioningDemo.Controllers.v1.BooksController>()
        .HasApiVersion(new ApiVersion(1, 0));
    options.Conventions.Controller<ApiVersioningDemo.Controllers.v2.BooksController>()
        .HasDeprecatedApiVersion(new ApiVersion(2, 0));
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
