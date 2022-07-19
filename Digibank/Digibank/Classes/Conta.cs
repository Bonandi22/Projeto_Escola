using Digibank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digibank.Classes
{
    public abstract class Conta : Banco, IConta
    {

        public Conta()
        {
            this.numeroagencia = "0001";
            Conta.NumeroContaseguencial++;
        }
        public double Saldo { get;protected set; }        
        public string numeroagencia {  get; private set; }
        public string numeroconta { get; protected set; }
        public static int NumeroContaseguencial { get; private set; }

        public void deposita(double valor)
        {
            this.Saldo += valor;
        }
        public bool Saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;


            this.Saldo -= valor;
            return true;
        }
        public double ConsultaSaldo()
        {
            return this.Saldo;
        }      

        public string GetCodiBanco()
        {
            return this.CodigoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.numeroagencia;
        }

        public string GetNumeroConta()
        {
            return this.numeroconta;
        }        
       
    }
}
