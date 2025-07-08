using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Domain.Entitys;

namespace Vendas.Infraestrutura.Configure
{
    public class VendedoresConfig : IEntityTypeConfiguration<Vendedores>
    {
        public void Configure(EntityTypeBuilder<Vendedores> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.Name).HasMaxLength(40);
            builder.Property(u => u.CorporativeEmail).HasMaxLength(40);
            builder.Property(u => u.Senha).HasMaxLength(40);
            builder.Property(u => u.Idade).HasMaxLength(40);
        }
    }
}