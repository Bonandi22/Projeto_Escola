using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digibank.Contratos
{
    public interface IConta
    {
        void deposita(double valor);
        bool Saca(double valor);
        double ConsultaSaldo();
        string GetCodiBanco();
        string GetNumeroAgencia();
        string GetNumeroConta();
    }
}
