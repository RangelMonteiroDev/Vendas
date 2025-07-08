using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Domain.Entitys
{
    public class Vendedores
    {
        [Key]
        public int ID { get; protected set; }
        public string Name { get; protected set; }
        public string CorporativeEmail { get; protected set; }
        public string Senha { get; protected set; }
        public int Idade { get; protected set; }
        public bool Status { get; protected set; }

        public Vendedores(string Name, string CorporativeEmail, string Senha, int Idade, bool Status)
        {
            this.Name = Name;
            this.CorporativeEmail = CorporativeEmail;
            this.Senha = Senha;
            this.Idade = Idade;
            this.Status = Status;
        }

        public Vendedores(int iD, string name, string corporativeEmail, string senha, int idade, bool Status)
        {
            this.ID = iD;
            this.Name = name;
            this.CorporativeEmail = corporativeEmail;
            this.Senha = senha;
            this.Idade = idade;
        }

        public Vendedores NovoVendedor(string Name, string CorporativeEmail, string Senha, int Idade, bool Status)
        {
            int workfactor = 10; // 2 ^ (10) = 1024 iterations.

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(Senha, salt);

            return new Vendedores(Name, CorporativeEmail, hash, Idade, Status);
        }

        public void AtualizarStatus(bool status)
        {
            this.Status = status;
        }

        public void AtualizarDados(string Name, string CorporativeEmail, string Senha, int Idade)
        {
            this.Name = Name;
            this.CorporativeEmail = CorporativeEmail;
            this.Senha = Senha;
            this.Idade = Idade;
        }
    }
}