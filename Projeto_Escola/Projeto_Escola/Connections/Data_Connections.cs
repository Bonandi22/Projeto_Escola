using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Text;
using Projeto_Escola.Models;
using Projeto_Escola.Repositories;

namespace Projeto_Escola.Connections
{
    internal class Data_Connections
    {
        private static string connectionString = @"Server=localhost\MSSQLSERVER02;Database=Scheduler;Trusted_Connection=True;";

        private SqlConnection sqlConnection = new(connectionString);

        public static string My_Connection()
        {
            //esse metodo é usado para passar a conexao com o banco de dados.
            return connectionString;
        }
        public List<Person> ExcuteSQLToSelect(string command_text, List<SqlParameter> parameters = null)
        {
            //esse metodo é usado para fazer novo registro, alteracao e o delete.

            var people = new List<Person>(); //gera lista de dados da Person para executar as açoes de alteracao e delete
            try
            {
                SqlCommand command = sqlConnection.CreateCommand();

                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                command.CommandText = command_text;
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //cria a person com as propriedades de cada person
                while (reader.Read())
                {
                    var person = new Person();

                    person.Id_Person = Convert.ToInt32(reader["ID"]);
                    person.Name = Convert.ToString(reader["Name"]);
                    person.NIF = Convert.ToString(reader["NIF"]);
                    person.Email = Convert.ToString(reader["Email"]);
                    person.Adress = Convert.ToString(reader["Adress"]);
                    person.Phone = Convert.ToString(reader["Phone"]);
                    person.Username = Convert.ToString(reader["User"]);
                    person.Password = Convert.ToString(reader["Password"]);
                    person.Typee = Convert.ToString(reader["Type"]);

                    people.Add(person);
                }
            }

            catch (Exception e)
            {
                Screen_Repository screen_Repository = new();
                Console.WriteLine($"Erro: (0) {e.Message}");         
            }
            finally
            {
                sqlConnection.Close();
            }
            return people;
        }
    }
}

