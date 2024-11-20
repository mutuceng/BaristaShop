using BaristaShop.Cargo.BusinessLayer.Abstract;
using BaristaShop.Cargo.BusinessLayer.Concrete;
using BaristaShop.Cargo.DataAccessLayer.Abstract;
using BaristaShop.Cargo.DataAccessLayer.Concrete;
using BaristaShop.Cargo.DataAccessLayer.EntityFramework;
using BaristaShop.Cargo.BusinessLayer.Mapping;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;
});


// Add services to the container.
builder.Services.AddDbContext<CargoContext>();

builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();

builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();

builder.Services.AddScoped<IShipmentDetailService, ShipmentDetailManager>();
builder.Services.AddScoped<IShipmentDetailDal, EfShipmentDetailDal>();

builder.Services.AddScoped<IShipmentOperationService, ShipmentOperationManager>();
builder.Services.AddScoped<IShipmentOperationDal, EfShipmentOperationDal>();

builder.Services.AddScoped<IShippingBillService, ShippingBillManager>();
builder.Services.AddScoped<IShippingBillDal, EfShippingBillDal>();

builder.Services.AddAutoMapper(typeof(GeneralMapping));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
