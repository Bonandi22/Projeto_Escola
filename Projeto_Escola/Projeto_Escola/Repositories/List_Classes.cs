using ConsoleTables;
using Projeto_Escola.Connections;
using Projeto_Escola.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto_Escola.Repositories
{
    public class List_Classes
    {
        public List<Classe> List_Subjects()
        {
            Data_Connections conection = new();
            Screen_Repository screen_Repository = new();
            string connectionString = Data_Connections.My_Connection();//passando a conexao com o SQLSERVER
            SqlConnection connection = new(connectionString);
            List<Classe> usuarios = new();          

            try
            {
                connection.Open();
                string sql = "SELECT [User].Name, Subjects.Subjects, Subjects.Time_Subject FROM [User] " +                    
                    "JOIN Subjects ON [User].ID = Subjects.user_id ORDER BY [User].Name";
                
                SqlCommand command = new(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"    Student list for Class      ");
                Console.WriteLine();
                var table = new ConsoleTable("Name", "Class", "Time");
                while (reader.Read())
                {
                    table.AddRow(reader["Name"], reader["Subjects"], reader["Time_Subject"]);
                }
                table.Write();
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
            return usuarios.OrderBy(p => p.ID).ToList(); //ordena a lista de usuarios por nomes
        }
        public List<Classe> List_Subjects_Student(int My_Id)
        {
            Data_Connections conection = new();
            Screen_Repository screen_Repository = new();
            string connectionString = Data_Connections.My_Connection();//passando a conexao com o SQLSERVER
            SqlConnection connection = new(connectionString);
            List<Classe> usuarios = new();

            try
            {
                connection.Open();
                string sql = "SELECT[User].Name, Subjects.Subjects, Subjects.Time_Subject FROM[User] " +
                                $"JOIN Subjects ON[User].ID = Subjects.user_id WHERE[User].ID ='{My_Id}'" +                              
                                "ORDER BY[User].Name";
                //$"SELECT [User].Name, Subjects.Subjects, Subjects.Time_Subject FROM [User] JOIN Subjects ON [User].ID = Subjects.user_id ORDER BY [User].Name WHERE={My_Id}";
                SqlCommand command = new(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"    List students and classes      ");
                Console.WriteLine();
                var table = new ConsoleTable("Name", "Class", "Time");
                while (reader.Read())
                {
                    table.AddRow(reader["Name"], reader["Subjects"], reader["Time_Subject"]);
                }
                table.Write();
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
            return usuarios.OrderBy(p => p.ID).ToList(); //ordena a lista de usuarios por nomes
        }
    }
}

