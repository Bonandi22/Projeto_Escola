using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digibank.Classes
{
    public  class ContaCorrente : Conta
    {

        public ContaCorrente()
        {
            this.numeroconta = "00" + Conta.NumeroContaseguencial;
            this.Limite = ;
        }

    }
}
