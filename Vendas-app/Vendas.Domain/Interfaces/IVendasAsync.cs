using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Domain.Entitys;

namespace Vendas.Domain.Interfaces
{
    public interface IVendasAsync
    {
        Task<bool> CreateVendedorAsync(Vendedores vendedores);
        Task<List<Vendedores>> GetAllAsync(bool ativo);
        Task<int> GetByEmailAsync(string email);
        Task<Vendedores> GetByIDAsync(int ID);
        Task<bool> UpdateAsync(Vendedores vendedores);
        Task<bool> Delete(int ID);
    }
}