using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entitys;

namespace Vendas.Infraestrutura.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<DbContext> options) : base(options) { }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vendedores> Vendedores { get; set; }
        
    }
}