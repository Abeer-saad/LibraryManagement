using LibraryManagement.Application.Services;
using LibraryManagement.Application.Services.Base;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories;
using LibraryManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args); builder.Services.AddControllers(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen(); builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); builder.Services.AddScoped<IBookRepository, BookRepository>(); builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(); builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>(); builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); builder.Services.AddScoped<IBookService, BookService>(); builder.Services.AddScoped<ICategoryService, CategoryService>(); builder.Services.AddScoped<ICustomerService, CustomerService>(); builder.Services.AddScoped<IBorrowingService, BorrowingService>(); var app = builder.Build(); if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.UseHttpsRedirection(); app.UseAuthorization(); app.MapControllers(); app.Run();
