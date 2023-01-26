using Projeto_Escola.Connections;
using Projeto_Escola.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Projeto_Escola.Repositories
{
    public class LoginRepository
    {
        public void Login(string username, string password)
        {
            DataConnections conection = new();
            ScreenRepository ScreenRepository = new();
            string connectionString = DataConnections.MyConnection();//passando a conexao com o SQLSERVER
            SqlConnection connection = new(connectionString);

            try
            {
                connection.Open();

                string querylogin = "SELECT * FROM [User] WHERE [User]='" + username + "' and password='" + password + "'";

                SqlCommand command = new(querylogin, connection);
                var listSelectParameters = new List<SqlParameter>
                            {
                                new SqlParameter("@username", username),
                                new SqlParameter("@password", password)
                            };
                // conversao da senha para o sistema Hash Cryptography
                byte[] passwordBytes = Encoding.Default.GetBytes(password);

                HashAlgorithm sha = SHA256.Create();
                byte[] hashBytes = sha.ComputeHash(passwordBytes);

                StringBuilder sb = new();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: (0) {e.Message}");
                ScreenRepository.InitSystem();
            }
            finally
            {
                connection.Close();
            }
        }
        public void ValidLogin(ScreenRepository ScreenRepository, SqlCommand command, string Password)
        {
            SqlDataReader reader = command.ExecuteReader();

            
            /*Console.WriteLine(sb.ToString());*///para imprimir a senha Cryptography

            if (reader.Read())
            {
                //fazer login
                string usertype = reader.GetString("Type");
                //Verifica se o usurario que logou foi teacher ou student
                if (usertype.Equals("Teacher"))
                {
                    Console.Clear();
                    Console.WriteLine("#*******************************************************#");
                    Console.WriteLine("                                                         ");
                    Console.WriteLine($"welcome to the system Teacher {reader.GetString("Name")}");
                    Console.WriteLine("                                                         ");
                    ScreenRepository.MenuTeacher();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("#*******************************************************#");
                    Console.WriteLine("                                                         ");
                    Console.WriteLine($"welcome to the system Student {reader.GetString("Name")}");
                    Console.WriteLine("                                                         ");
                    ScreenRepository.MenuStudent();
                }
            }
            //caso esteja errado a senha ou login
            if (!reader.Read())
            {
                Autentication autentication = new();
                Console.Clear();
                Console.WriteLine("Senha ou usuario invalidos, tente novamente");
                Console.WriteLine("username? ");
                string user = Console.ReadLine();
                Console.WriteLine("password? ");
                string pass = Console.ReadLine();
                autentication.Login(user, pass);
            }
            Console.Clear();
        }




    }
}
