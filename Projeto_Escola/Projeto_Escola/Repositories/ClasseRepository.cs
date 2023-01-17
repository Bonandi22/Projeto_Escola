using Projeto_Escola.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola.Repositories
{
    public class ClasseRepository
    {
        public void ClassStudent(string queryInsert)
        {
            ScreenRepository screenRepository = new();
            DataConnections conection = new();
            conection.ExcuteSQLToSelect(queryInsert);

            Console.WriteLine("Cadastro realizado com sucesso");
            Console.ReadLine();
            Console.Clear();
        }



    }
}
