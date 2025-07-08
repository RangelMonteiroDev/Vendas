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
    public class GetByIDVendedorHandler : IRequestHandler<VendedoresQueryGetByID, VendedoresResponseGetByID>
    {
        private readonly ServiceVendedores _serviceVendedores;
        public GetByIDVendedorHandler(ServiceVendedores serviceVendedores)
        {
            _serviceVendedores = serviceVendedores;
        }
        public async Task<VendedoresResponseGetByID> Handle(VendedoresQueryGetByID request, CancellationToken cancellationToken)
        {
            int ID = request.ID;

            var resultado = await _serviceVendedores.GetByIDVendedorServiceAsync(ID);

            if (resultado == null)
            {
                return new VendedoresResponseGetByID(404, resultado);
            }
            return new VendedoresResponseGetByID(200, resultado);
        }
    }
}