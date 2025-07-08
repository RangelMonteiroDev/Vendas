using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.Responses;

namespace Vendas.Application.Commands
{
    public class VendedoresCommandCreate : IRequest<VendedoresResponseHTTP>
    {
        public string Name { get; set; }
        public string CorporativeEmail { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
        public bool Status { get; set; }
    }

    public class VendedoresCommandUpdate : IRequest<VendedoresResponseHTTP>
    {   
        public int ID { get; set;}
        public string Name { get; set; }
        public string CorporativeEmail { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
    }

    public class VendedoresCommandDelete : IRequest<VendedoresResponseHTTP>
    {
        public int ID { get; set;}
    }
}