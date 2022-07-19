using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digibank.Classes
{
    public abstract class Banco
    {

        public Banco()
        {
            this.NomeBanco = " DigiBank ";
            this.CodigoBanco = "027";
        }

        public string NomeBanco { get;  set; }

        public string CodigoBanco { get;  set; }


    }
}
