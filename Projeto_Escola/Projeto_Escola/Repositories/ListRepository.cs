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
    public class ListRepository
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
                CreadList(opcao, usuarios, reader);
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

        public void CreadList(string opcao, List<Person> usuarios, SqlDataReader reader)
        {
            string currentUserType = opcao;
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

            if (currentUserType == "Teacher")
            {
                List<Person> teachers = usuarios.Where(u => u.Typee == "Teacher").ToList();
                var table = new ConsoleTable("Name", "Email", "Phone", "Type");
                foreach (var teacher in teachers)
                {
                    table.AddRow(teacher.Name, teacher.Email, teacher.Phone, teacher.Typee);
                }
                Console.WriteLine("Teacher list");
                Console.WriteLine("            ");
                table.Write();
            }
            else if (currentUserType == "Student")
            {
                List<Person> students = usuarios.Where(u => u.Typee == "Student").ToList();
                var table = new ConsoleTable("Name", "Email", "Phone", "Type");
                foreach (var student in students)
                {
                    table.AddRow(student.Name, student.Email, student.Phone, student.Typee);
                }
                Console.WriteLine("Student list");
                Console.WriteLine("            ");
                table.Write();
            }
           
        }
    }
}

