using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola
{
    internal class Data_Connections
    {
        //const string connectionString = @"Server=localhost\MSSQLSERVER02;Database=master;Trusted_Connection=True;";
        const string connectionString = @"Server=localhost\MSSQLSERVER02;Database=Scheduler;Trusted_Connection=True;";
        
        // Michel connections
        //const string connectionString = @"Server=localhost;Database=Scheduler;User Id=sa;Password=CiAdmin!";

        private  SqlConnection sqlConnection = new(connectionString);

        public void ExcuteSQL(String command_text, List<SqlParameter> parameters = null)
        {
            var command = sqlConnection.CreateCommand();

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            command.CommandText = command_text;
            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
