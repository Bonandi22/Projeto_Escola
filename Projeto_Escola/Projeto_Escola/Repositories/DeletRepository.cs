using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using Projeto_Escola.Connections;
using Projeto_Escola.Models;

namespace Projeto_Escola.Repositories
{
    public class DeletRepository
    {
        public void User_Delet()
        {
            DataConnections conection = new();
            Console.Clear();
            Console.WriteLine("#**************************************#");
            Console.WriteLine("# #");
            Console.WriteLine("# --- MENU User Delet --- #");
            Console.WriteLine("# #");
            Console.WriteLine("#**************************************#");
            Console.WriteLine();

            Console.WriteLine("Favor informar o numero de contribuinte - NIF");
            string NIF = Console.ReadLine();

            Console.WriteLine("Deseja realmente deletar o cadastro? S/N");
            string Delete = Console.ReadLine();

            if (Delete.StartsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                string queryDelete = $"DELETE FROM [User] WHERE NIF = {NIF}";

                conection.ExcuteSQLToSelect(queryDelete);
            }

            Console.WriteLine("Cadastro deletado com sucesso");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
