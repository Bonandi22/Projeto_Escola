using Microsoft.Data.SqlClient;
using Projeto_Escola.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola.Repositories
{
    public class Register_Repository
    {
        public void User_Register(string queryInsert)
        {
            Screen_Repository screen_Repository = new();
            Data_Connections conection = new();
            conection.ExcuteSQLToSelect(queryInsert);

            Console.WriteLine("Cadastro realizado com sucesso");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
