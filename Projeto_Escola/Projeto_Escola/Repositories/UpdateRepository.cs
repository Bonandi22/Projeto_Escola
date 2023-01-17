using Projeto_Escola.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto_Escola.Repositories
{
    public class UpdateRepository
    {
        public void User_Update(string queryUpdate, List<SqlParameter> listUpdateParameters)
        {
            DataConnections conection=new();
            conection.ExcuteSQLToSelect(queryUpdate, listUpdateParameters);
            Console.WriteLine("Cadastro alterado com sucesso");
            Console.ReadLine();
            Console.Clear();
        }       
    
    }
}
