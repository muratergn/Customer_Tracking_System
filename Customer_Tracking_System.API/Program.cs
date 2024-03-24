using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Core.Services;
using Customer_Tracking_System.Core.UnitOfWork;
using Customer_Tracking_System.Repository;
using Customer_Tracking_System.Repository.Repositories;
using Customer_Tracking_System.Repository.UnitOfWorks;
using Customer_Tracking_System.Service.Mapping;
using Customer_Tracking_System.Service.Services;
using Customer_Tracking_System.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Customer_Tracking_System.Service.Validations;
using FluentValidation;
using Customer_Tracking_System.API.Filters;
using Microsoft.AspNetCore.Mvc;
using Customer_Tracking_System.API.Middlewares;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Customer_Tracking_System.API.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

builder.Services.AddScoped(typeof(NotFoundFilterUser<>));
builder.Services.AddScoped(typeof(NotFoundFilterOrder<>));
builder.Services.AddScoped(typeof(NotFoundFilterProduct<>));
builder.Services.AddScoped(typeof(NotFoundFilterProductComment<>));
builder.Services.AddScoped(typeof(NotFoundFilterCustomerInterests<>));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<ISellerRepository, SellerRepository>();
//builder.Services.AddScoped<ICustomerService, CustomerService>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ISellerService, SellerService>();


builder.Services.AddDbContext<AppDbContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
