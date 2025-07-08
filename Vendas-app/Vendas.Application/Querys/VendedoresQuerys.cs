using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.DTOs;
using Vendas.Application.Responses;
using Vendas.Domain.Entitys;

namespace Vendas.Application.Querys
{
    public class VendedoresQueryGetAll : IRequest<VendedoresResponseGetAll>
    {
        public bool Status { get; set; }
    }

    public class VendedoresQueryGetByEmail : IRequest<VendedoresResponseGetByEmail>
    {
        public string Email { get; set; }
    }

    public class VendedoresQueryGetByID : IRequest<VendedoresResponseGetByID>
    {
        public int ID { get; set; }
    }
}