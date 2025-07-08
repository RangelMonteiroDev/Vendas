using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.Querys;
using Vendas.Application.Responses;
using Vendas.Application.Services;

namespace Vendas.Application.Handlers.VendedoresHandlers
{
    public class GetByEmailVendedorHandler : IRequestHandler<VendedoresQueryGetByEmail, VendedoresResponseGetByEmail>
    {
        private readonly ServiceVendedores _serviceVendedores;
        public GetByEmailVendedorHandler(ServiceVendedores serviceVendedores)
        {
            _serviceVendedores = serviceVendedores;
        }
        public async Task<VendedoresResponseGetByEmail> Handle(VendedoresQueryGetByEmail request, CancellationToken cancellationToken)
        {
            string Email = request.Email;

            var ID = await _serviceVendedores.GetByEmailVendedorServiceAsync(Email);

            if (ID == 0)
            {
                return new VendedoresResponseGetByEmail(404, ID);
            }
            return new VendedoresResponseGetByEmail(200, ID);
        }
    }
}