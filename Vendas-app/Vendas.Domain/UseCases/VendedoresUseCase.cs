using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Domain.Entitys;
using Vendas.Domain.Interfaces;

namespace Vendas.Domain.UseCases
{
    public class VendedoresUseCase
    {
        private readonly IVendasAsync _vendasAsync;
        public VendedoresUseCase(IVendasAsync vendasAsync)
        {
            _vendasAsync = vendasAsync;
        }
        public async Task<bool> NovoVendedor(Vendedores vendedores)
        {
            var resultado = await _vendasAsync.CreateVendedorAsync(vendedores);
            return resultado;
        }
        public async Task<List<Vendedores>> GetAllVendedoresAsync(bool ativo)
        {
            var resultado = await _vendasAsync.GetAllAsync(ativo);
            return resultado;
        }
        public async Task<int> ReturnIDByEmailAsync(string email)
        {
            var resultado = await _vendasAsync.GetByEmailAsync(email);
            return resultado;
        }
        public async Task<Vendedores> GetByIDAsync(int ID)
        {
            var resultado = await _vendasAsync.GetByIDAsync(ID);
            return resultado;
        }
        public async Task<bool> UpdateAsync(Vendedores vendedores)
        {
            var resultado = await _vendasAsync.UpdateAsync(vendedores);
            return resultado;
        }
        public async Task<bool> DeleteAsync(int ID)
        {
            var resultado = await _vendasAsync.Delete(ID);
            return resultado;
        }

    }
}