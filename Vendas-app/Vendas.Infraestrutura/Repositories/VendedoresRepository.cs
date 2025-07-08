using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entitys;
using Vendas.Domain.Interfaces;
using Vendas.Infraestrutura.Contexts;

namespace Vendas.Infraestrutura.Repositories
{
    public class VendedoresRepository : IVendasAsync
    {
        private readonly AppDbContext _appDbContext;
        public VendedoresRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateVendedorAsync(Vendedores vendedores)
        {
            try
            {
                Vendedores NovoVendedor = vendedores.NovoVendedor(vendedores.Name, vendedores.CorporativeEmail, vendedores.Senha, vendedores.Idade, vendedores.Status);

                await _appDbContext.Vendedores.AddAsync(NovoVendedor);

                await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int ID)
        {
            try
            {
                var vendedor = await _appDbContext.Vendedores.FindAsync(ID);

                if (vendedor == null)
                {
                    return false;
                }

                vendedor.AtualizarStatus(false);

                await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<List<Vendedores>> GetAllAsync(bool ativo)
        {
            var dados = await _appDbContext.Vendedores.Where(v => v.Status == ativo).ToListAsync();

            return dados;
        }

        public async Task<int> GetByEmailAsync(string email)
        {
            try
            {
                var retorno = await _appDbContext.Vendedores.FirstOrDefaultAsync(v => v.CorporativeEmail == email);
                var ID = retorno.ID;

                if (ID <= 0)
                {
                    return 0;
                }

                return ID;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Vendedores> GetByIDAsync(int ID)
        {
            var dados = await _appDbContext.Vendedores.FindAsync(ID);
            return dados;
        }

        public async Task<bool> UpdateAsync(Vendedores vendedores)
        {
            try
            {     
                var vendedor = await _appDbContext.Vendedores.FindAsync(vendedores.ID);

                if (vendedor == null)
                {
                    return false;
                }

                vendedor.AtualizarDados(vendedores.Name, vendedores.CorporativeEmail, vendedores.Senha, vendedores.Idade);

                await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}