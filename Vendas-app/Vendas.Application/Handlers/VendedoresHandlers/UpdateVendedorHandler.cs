using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.Commands;
using Vendas.Application.DTOs;
using Vendas.Application.Responses;
using Vendas.Application.Services;

namespace Vendas.Application.Handlers.VendedoresHandlers
{
    public class UpdateVendedorHandler : IRequestHandler<VendedoresCommandUpdate, VendedoresResponseHTTP>
    {
        private readonly ServiceVendedores _serviceVendedores;
        public UpdateVendedorHandler(ServiceVendedores serviceVendedores)
        {
            _serviceVendedores = serviceVendedores;
        }
        public async Task<VendedoresResponseHTTP> Handle(VendedoresCommandUpdate request, CancellationToken cancellationToken)
        {
            int ID = request.ID;
            string Name = request.Name;
            string CorporativeEmail = request.CorporativeEmail;
            int Idade = request.Idade;
            string Senha = request.Senha;

            VendedoresDTO vendedoresDTO = new VendedoresDTO(ID, Name, CorporativeEmail,Idade,Senha);

            var updates = await _serviceVendedores.AtualizarVendedorServiceAsync(vendedoresDTO);

            if (updates)
            {
                return new VendedoresResponseHTTP(200, "Dados atualizados com Sucesso!");
            }

            return new VendedoresResponseHTTP(400, "Falha em atualizar Dados");
        }
    }
}