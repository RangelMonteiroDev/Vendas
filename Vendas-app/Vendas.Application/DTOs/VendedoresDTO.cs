using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Application.DTOs
{
    public class VendedoresDTO
    {
        private bool v;

        public int ID { get; set; }
        public string Name { get; set; }
        public string CorporativeEmail { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
        public bool Status { get; set; }


        public VendedoresDTO(string Name, string CorporativeEmail, string Senha, int Idade, bool Status)
        {
            this.Name = Name;
            this.CorporativeEmail = CorporativeEmail;
            this.Senha = Senha;
            this.Idade = Idade;
            this.Status = Status;
        }

        public VendedoresDTO(int ID, string Name, string CorporativeEmail, int Idade, string Senha)
        {
            this.ID = ID;
            this.Name = Name;
            this.CorporativeEmail = CorporativeEmail;
            this.Idade = Idade;
            this.Senha = Senha;
        }

        public VendedoresDTO(int iD, string name, string corporativeEmail, string senha, int idade, bool Status)
        {
            this.ID = iD;
            this.Name = name;
            this.CorporativeEmail = corporativeEmail;
            this.Senha = senha;
            this.Idade = idade;
            this.Status = Status;
        }

        public VendedoresDTO(int iD, string name, string corporativeEmail, int idade, bool status)
        {
            this.ID = iD;
            this.Name = name;
            this.CorporativeEmail = corporativeEmail;
            this.Idade = idade;
            this.Status = status;
        }
    }
}