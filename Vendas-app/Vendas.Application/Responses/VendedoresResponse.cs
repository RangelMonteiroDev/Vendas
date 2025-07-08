using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Application.DTOs;
using Vendas.Domain.Entitys;

namespace Vendas.Application.Responses
{
    public class VendedoresResponseGetByID
    {
        public int HttpCodeStatus { get; set; }
        public VendedoresDTO Vendedores { get; set; }

        private VendedoresDTO GetVendedor(Vendedores vendedores)
        {
            VendedoresDTO vendedoresDTO = new VendedoresDTO(vendedores.ID, vendedores.Name, vendedores.CorporativeEmail, vendedores.Idade, vendedores.Status);

            return vendedoresDTO;
        }

        public VendedoresResponseGetByID(int HttpCodeStatus, Vendedores vendedores)
        {
            this.HttpCodeStatus = HttpCodeStatus;
            this.Vendedores = GetVendedor(vendedores);
        }
        
    }
    public class VendedoresResponseGetAll
    {
        public int HttpCodeStatus { get; set; }
        public List<VendedoresDTO> VendedoresDTOs { get; set; }

        private List<VendedoresDTO> ListarVendedores(List<Vendedores> list)
        {
            List<VendedoresDTO> vendedores = new List<VendedoresDTO>();

            foreach (var vendedor in list)
            {
                VendedoresDTO vendedoresDTO = new(vendedor.ID,vendedor.Name, vendedor.CorporativeEmail, vendedor.Idade, vendedor.Status);
                vendedores.Add(vendedoresDTO);
            }

            return vendedores;
        }

        public VendedoresResponseGetAll(int HttpCodeStatus, List<Vendedores> vendedores)
        {
            this.HttpCodeStatus = HttpCodeStatus;
            this.VendedoresDTOs = ListarVendedores(vendedores);
        }
    }
    public class VendedoresResponseGetByEmail(int HttpStatusCode, int ID)
    {
        public int HttpStatusCode = HttpStatusCode;
        public int ID { get; set; } = ID;
        
    }
    public class VendedoresResponseHTTP(int HttpCodeStatus, string HttpMessage)
    {
        public int HttpCodeStatus { get; set; } = HttpCodeStatus;
        public string HttpMessage { get; set; } = HttpMessage;
    }
    
}