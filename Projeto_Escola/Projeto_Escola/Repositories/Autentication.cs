using Projeto_Escola.Connections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


namespace Projeto_Escola.Repositories
{
    public class Autentication
    {
        public void Login(string Username, string Password)
        {
            Data_Connections conection = new();
            Screen_Repository screen_Repository = new();
            string connectionString = Data_Connections.My_Connection();//passando a conexao com o SQLSERVER
            SqlConnection connection = new (connectionString);

            try
            {              
                connection.Open();

                string querylogin = "SELECT * FROM [User] WHERE [User]='" + Username + "' and Password='" + Password + "'";

                SqlCommand command = new(querylogin, connection);
                var listSelectParameters = new List<SqlParameter>
                            {
                                new SqlParameter("@Username", Username),
                                new SqlParameter("@Password", Password)
                            };

                Valid_Login(screen_Repository, command, Password); // validacao de login e senha           

            }
            catch(Exception e)
            {
                Console.WriteLine($"Erro: (0) {e.Message}");
                screen_Repository.Init_System();
            }
            finally
            {            
                connection.Close();
            }
        }
        public void Valid_Login(Screen_Repository screen_Repository, SqlCommand command, string Password)
        {
            SqlDataReader reader = command.ExecuteReader();

            // conversao da senha para o sistema Hash Cryptography
            byte[] passwordBytes = Encoding.Default.GetBytes(Password);

            HashAlgorithm sha = SHA256.Create();
            byte[] hashBytes = sha.ComputeHash(passwordBytes);

            StringBuilder sb = new();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            /*Console.WriteLine(sb.ToString());*///para imprimir a senha Cryptography

            if (reader.Read())
            {
                //fazer login
                string User_type = reader.GetString("Type");
                //Verifica se o usurario que logou foi teacher ou student
                if (User_type.Equals("Teacher"))
                {
                    Console.Clear();
                    Console.WriteLine("#*******************************************************#");
                    Console.WriteLine("                                                         ");
                    Console.WriteLine($"welcome to the system Teacher {reader.GetString("Name")}");
                    Console.WriteLine("                                                         ");
                    screen_Repository.Menu_Teacher();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("#*******************************************************#");
                    Console.WriteLine("                                                         ");
                    Console.WriteLine($"welcome to the system Student {reader.GetString("Name")}");
                    Console.WriteLine("                                                         ");
                    screen_Repository.Menu_Student();
                }
            }
            //caso esteja errado a senha ou login
            if (!reader.Read())
            {
                Autentication autentication = new();
                Console.Clear();
                Console.WriteLine("Senha ou usuario invalidos, tente novamente");
                Console.WriteLine("Username? ");
                string user = Console.ReadLine();
                Console.WriteLine("Password? ");
                string pass = Console.ReadLine();
                autentication.Login(user, pass);
            }
            Console.Clear();
        }
    }
}
