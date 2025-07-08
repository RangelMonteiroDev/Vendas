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
    public class CreateVendedorHandler : IRequestHandler<VendedoresCommandCreate, VendedoresResponseHTTP>
    {
        private readonly ServiceVendedores _serviceVendedores;
        public CreateVendedorHandler(ServiceVendedores serviceVendedores)
        {
            _serviceVendedores = serviceVendedores;  
        }
        public async Task<VendedoresResponseHTTP> Handle(VendedoresCommandCreate request, CancellationToken cancellationToken)
        {
            string Nome = request.Name;
            string Email = request.CorporativeEmail;
            string Senha = request.Senha;
            int Idade = request.Idade;
            bool Status = request.Status;

            VendedoresDTO vendedoresDTO = new VendedoresDTO(Nome, Email, Senha, Idade, Status);

            var creates = await _serviceVendedores.CreateVendedoresServiceAsync(vendedoresDTO);

            if (creates)
            {
                return new VendedoresResponseHTTP(201, "Criado com Sucesso!");
            }
            return new VendedoresResponseHTTP(400, "Problema na Requisição!");
        }
    }
}