using Digibank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digibank.Classes
{
    public class Pessoa
    {

        public string Nome { get; private set; }
        public string Nif { get; private set; }
        public string Senha { get;  private set; }
        public IConta Conta {  get;  set; }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetNIf(string Nif)
        {
            this.Nif = Nif;
        }

        public void SetSenha(string senha)
        {
            this.Senha = senha;
        }
                
            


    }
}
