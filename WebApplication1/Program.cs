using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DomainLayer;
using WebApplication1.RepositoryLayer;
using WebApplication1.RepositoryLayer.Repository.RepoBase;
using WebApplication1.RepositoryLayer.Repository.RepoCompany;
using WebApplication1.RepositoryLayer.Repository.RepoEmployee;
using WebApplication1.ServiceLayer.Queries.EmployeeQueries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped<IContext, Context>();

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(ICompanyRepository<>), typeof(CompanyRepository<>));
builder.Services.AddScoped(typeof(IEmployeeRepository<>), typeof(EmployeeRepository<>));

builder.Services.AddMediatR(typeof(GetEmployeesQuerry).Assembly);

var app = builder.Build();

app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
