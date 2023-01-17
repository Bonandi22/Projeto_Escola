using Projeto_Escola.Connections;
using Projeto_Escola.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ConsoleTables;


namespace Projeto_Escola.Repositories
{
    public class List_Repository
    {        
        public List<Person> ListUser(string opcao)
        {
            DataConnections conection = new();
            ScreenRepository ScreenRepository = new();
            string connectionString = DataConnections.MyConnection();//passando a conexao com o SQLSERVER
            SqlConnection connection = new(connectionString);
            List<Person> usuarios = new();          

            try
            {
                connection.Open();
                string sql = "SELECT * FROM [User] ORDER BY [User].Name";
                SqlCommand command = new(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                //retorna as propriedades de cada person para a lista de usuario
                while (reader.Read())
                {
                    Person usuario = new()
                    {
                        Id_Person = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        NIF = Convert.ToString(reader["NIF"]),
                        Email = Convert.ToString(reader["Email"]),
                        Adress = Convert.ToString(reader["Adress"]),
                        Phone = Convert.ToString(reader["Phone"]),
                        Username = Convert.ToString(reader["User"]),
                        Password = Convert.ToString(reader["Password"]),
                        Typee = Convert.ToString(reader["Type"])
                    };
                    usuarios.Add(usuario);
                }

                //verifica se a lista é para teacher ou student
                if (opcao == "Teacher")
                {                    
                    List<Person> teacher = usuarios.Where(u => u.Typee == "Teacher").ToList();
                    var table = new ConsoleTable("Name","Email","Phone");
                    foreach (var pessoa in teacher)
                    {
                        table.AddRow(pessoa.Name, pessoa.Email, pessoa.Phone);                        
                    }
                    Console.WriteLine($"{opcao} list");
                    Console.WriteLine($"            ");
                    table.Write(); 
                }
                else
                {
                    List<Person> students = usuarios.Where(u => u.Typee == "Student").ToList();
                    var table = new ConsoleTable("Name", "Email", "Phone");
                    foreach (var pessoa in students)
                    {
                        table.AddRow(pessoa.Name, pessoa.Email, pessoa.Phone);                        
                    }
                    Console.WriteLine($"{opcao} list");
                    Console.WriteLine($"            ");
                    table.Write();
                }               
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: (0) {e.Message}");
            }
            finally
            {
                connection.Close();
            }

            return usuarios;
        }
    }
}

