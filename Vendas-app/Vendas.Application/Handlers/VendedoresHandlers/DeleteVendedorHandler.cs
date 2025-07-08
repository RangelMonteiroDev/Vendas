using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.Commands;
using Vendas.Application.Responses;
using Vendas.Application.Services;

namespace Vendas.Application.Handlers.VendedoresHandlers
{
    public class DeleteVendedorHandler : IRequestHandler<VendedoresCommandDelete, VendedoresResponseHTTP>
    {
        private readonly ServiceVendedores _serviceVendedores;
        public DeleteVendedorHandler(ServiceVendedores serviceVendedores)
        {
            _serviceVendedores = serviceVendedores; 
        }
        public async Task<VendedoresResponseHTTP> Handle(VendedoresCommandDelete request, CancellationToken cancellationToken)
        {
            int ID = request.ID;

            var delete = await _serviceVendedores.DeleteVendedorServiceAsync(ID);

            if (delete)
            {
                return new VendedoresResponseHTTP(200, "Dados deletados com sucesso!");
            }
            return new VendedoresResponseHTTP(400, "Falha em deletar os Dados");
        }
    }
}