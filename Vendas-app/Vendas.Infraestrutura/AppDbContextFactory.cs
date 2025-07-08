using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Vendas.Infraestrutura.Contexts;

namespace Vendas.Infraestrutura
{
/// <summary>
/// Usado APENAS em design‑time (migrations, update‑database).
/// </summary>
public sealed class AppDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // ↓ Ajuste aqui a mesma string de conexão do appsettings
        const string connectionString =
            "Server=localhost;Database=VendasDB;" +
            "Trusted_Connection=True;TrustServerCertificate=True;";

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new AppDbContext(options);
    }
}
}