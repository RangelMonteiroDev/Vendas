using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Application.DTOs;
using Vendas.Domain.Entitys;
using Vendas.Domain.UseCases;

namespace Vendas.Application.Services
{
    public class ServiceVendedores
    {
        private readonly VendedoresUseCase _vendedoresUseCase;

        public ServiceVendedores(VendedoresUseCase vendedoresUseCase)
        {
            _vendedoresUseCase = vendedoresUseCase;
        }

        public async Task<bool> CreateVendedoresServiceAsync(VendedoresDTO vendedoresDTO)
        {
            string Name = vendedoresDTO.Name;
            string CorporativeEmail = vendedoresDTO.CorporativeEmail;
            string Senha = vendedoresDTO.Senha;
            int Idade = vendedoresDTO.Idade;
            bool Status = vendedoresDTO.Status;

            Vendedores vendedores = new Vendedores(Name, CorporativeEmail, Senha, Idade, Status);

            var creates = await _vendedoresUseCase.NovoVendedor(vendedores);

            if (creates)
            {
                return true;
            }

            return false;
        }

        public async Task<Vendedores> GetByIDVendedorServiceAsync(int ID)
        {
            var vendedor = await _vendedoresUseCase.GetByIDAsync(ID);

            return vendedor;
        }

        public async Task<int> GetByEmailVendedorServiceAsync(string email)
        {
            var ID = await _vendedoresUseCase.ReturnIDByEmailAsync(email);
            return ID;
        }

        public async Task<List<Vendedores>> GetAllVendedoresServiceAsync(bool ativo)
        {
            var vendedores = await _vendedoresUseCase.GetAllVendedoresAsync(ativo);

            return vendedores;
        }

        public async Task<bool> AtualizarVendedorServiceAsync(VendedoresDTO vendedoresDTO)
        {
            int ID = vendedoresDTO.ID;
            string Name = vendedoresDTO.Name;
            string CorporativeEmail = vendedoresDTO.CorporativeEmail;
            string Senha = vendedoresDTO.Senha;
            int Idade = vendedoresDTO.Idade;

            Vendedores vendedores = new Vendedores(ID, Name, CorporativeEmail, Senha, Idade, true);

            var updates = await _vendedoresUseCase.UpdateAsync(vendedores);

            if (updates)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteVendedorServiceAsync(int ID)
        {
            var delete = await _vendedoresUseCase.DeleteAsync(ID);

            if (delete)
            {
                return true;
            }

            return false;
        }
    }
}