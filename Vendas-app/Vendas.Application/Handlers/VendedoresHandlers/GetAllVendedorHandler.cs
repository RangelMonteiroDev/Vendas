using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.DTOs;
using Vendas.Application.Querys;
using Vendas.Application.Responses;
using Vendas.Application.Services;
using Vendas.Domain.Entitys;

namespace Vendas.Application.Handlers.VendedoresHandlers
{
    public class GetAllVendedorHandler : IRequestHandler<VendedoresQueryGetAll, VendedoresResponseGetAll>
    {
        private readonly ServiceVendedores _serviceVendedores;
        public GetAllVendedorHandler(ServiceVendedores serviceVendedores)
        {
            _serviceVendedores = serviceVendedores;
        }
        public async Task<VendedoresResponseGetAll> Handle(VendedoresQueryGetAll request, CancellationToken cancellationToken)
        {
            bool Status = request.Status;
            var resultado = await _serviceVendedores.GetAllVendedoresServiceAsync(Status);

            if (resultado == null)
            {
                return new VendedoresResponseGetAll(404, resultado);
            }

            return new VendedoresResponseGetAll(200, resultado);
        }
    }
}