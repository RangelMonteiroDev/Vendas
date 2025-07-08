using Microsoft.EntityFrameworkCore;
using Vendas.Application;
using Vendas.Application.Services;
using Vendas.Domain;
using Vendas.Domain.Interfaces;
using Vendas.Domain.UseCases;
using Vendas.Infraestrutura;
using Vendas.Infraestrutura.Contexts;
using Vendas.Infraestrutura.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ServiceVendedores>();
builder.Services.AddScoped<VendedoresUseCase>();
builder.Services.AddScoped<IVendasAsync, VendedoresRepository>();


builder.Services.AddMediatR(
    cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly)
);

builder.Services.AddDbContext<AppDbContext>(options =>

options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer")
));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapStaticAssets();

app.Run();
