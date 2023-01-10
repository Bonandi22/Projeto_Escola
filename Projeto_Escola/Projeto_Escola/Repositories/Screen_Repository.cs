using Projeto_Escola.Connections;
using Projeto_Escola.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto_Escola.Repositories
{
    public class Screen_Repository
    {
        public void Init_System()
        {      
            int escolha;
            do {
                Console.WriteLine("#*************************************#");
                Console.WriteLine("#                                     #");
                Console.WriteLine("#          --- MAIN MENU ---          #");
                Console.WriteLine("#                                     #");
                Console.WriteLine("# 1 - Login                           #");
                Console.WriteLine("# 2 - Register                        #");
                Console.WriteLine("# 0 - Exit                            #");
                Console.WriteLine("#                                     #");
                Console.WriteLine("#*************************************#");
                Console.WriteLine();
                Console.Write("Digite sua opcao: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out escolha))
                {
                   Console.WriteLine("opcao inválida");
                   Console.Clear();
                   continue;               
                }
                switch (escolha)
                {
                    case 1:
                       Autentication autentication = new();
                        Console.WriteLine("Enter username ");
                        string User = Console.ReadLine();
                        Console.WriteLine("Enter Password? ");
                        string pass = Console.ReadLine();
                        autentication.Login(User, pass);
                     break;
                    case 2:
                        New_Register();
                        break;
                        default:
                            Console.WriteLine("Opção inválida");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                }
            } while (escolha != 0);
        }
        public void Menu_Teacher()
        {
            string opcao = "Teacher";
            int escolha;
            do
            {
                Console.WriteLine("#*************************************#");
                Console.WriteLine("#                                     #");
                Console.WriteLine("#        --- MENU Teacher ---         #");
                Console.WriteLine("#                                     #");
                Console.WriteLine("# 1 - Update Teacher                  #");
                Console.WriteLine("# 2 - Delet Teacher                   #");
                Console.WriteLine("# 3 - List Teacher                    #");
                Console.WriteLine("# 4 - Register Classes                #");
                Console.WriteLine("# 5 - Student and Classes             #");
                Console.WriteLine("# 0 - Sair                            #");
                Console.WriteLine("#                                     #");
                Console.WriteLine("#*************************************#");
                Console.WriteLine();
                Console.Write("Digite sua opcao: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out escolha))
                {
                    Console.WriteLine("opcao inválida");
                    Console.Clear();
                    continue;
                }                
                switch (escolha)
                {
                    case 1:                        
                        Update();
                        break;
                    case 2:
                        Delet_Repository delet_Repository = new();
                        delet_Repository.User_Delet();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("                 ");
                        List_Repository list_Repository = new();
                        list_Repository.List_User(opcao);                        
                        break;
                    case 4:
                        New_Subject();
                        break;
                    case 5:
                        Student_Subject();
                        break;
                    case 0:
                        Init_System();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

            } while (escolha != 0);
        }
        public void Menu_Student()
        {
            string opcao = "Student";
            int escolha;
            do
            {
                Console.WriteLine("#**************************************#");
                Console.WriteLine("#                                      #");
                Console.WriteLine("#        --- MENU Student ---          #");
                Console.WriteLine("#                                      #");
                Console.WriteLine("# 1 - Update Student                   #");
                Console.WriteLine("# 2 - List Student                     #");
                Console.WriteLine("# 0 - Sair                             #");
                Console.WriteLine("#                                      #");
                Console.WriteLine("#**************************************#");
                Console.WriteLine();
                Console.Write("Digite sua opcao: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out escolha))
                {
                    Console.WriteLine("opcao inválida");
                    Console.Clear();
                    continue;
                }
                switch (escolha)
                {
                    case 1:
                        Data_Connections conection;
                        Update();                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("                 ");
                        List_Repository list_Repository = new();
                        list_Repository.List_User(opcao);
                        break;
                    case 0:
                        Init_System();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (escolha != 0);
        }
        public void New_Register()
        {
            Screen_Repository screen_Repository = new();
            Register_Repository register_repository = new();
            Data_Connections conection = new();
            Console.Clear();
            Console.WriteLine("#*************************************#");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#     --- Register New User ---       #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#*************************************#");
            Console.WriteLine();            

            Console.WriteLine("Favor informar o nome completo");
            string Name = Console.ReadLine();
            Console.WriteLine("Favor informar o numero de contribuinte - NIF");
            string NIF = Console.ReadLine();
            Console.WriteLine("Favor informar E-mail)");
            string Email = Console.ReadLine();
            Console.WriteLine("Favor informar a morada completa)");
            string Adress = Console.ReadLine();
            Console.WriteLine("Favor informar o numero de Telemovel");
            string Phone = Console.ReadLine();
            Console.WriteLine("Favor informar o nome de usuario");
            string Login = Console.ReadLine();
            Console.WriteLine("Favor informar a senha");
            string Password = Console.ReadLine();
            Console.WriteLine("Favor informar o tipo de usuário (Teacher or Student)");
            string Type = Console.ReadLine();
            string queryInsert = $"INSERT INTO [User] (Name, NIF, Email, Adress, Phone, [User], Password, Type )" +
                                 $" Values ('{Name}', '{NIF}', '{Email}', '{Adress}', '{Phone}', '{Login}', '{Password}', '{Type}')";

            register_repository.User_Register(queryInsert);
            screen_Repository.Init_System();
        }
        public void New_Subject()
        {
            Screen_Repository screen_Repository = new();
            Register_Repository register_repository = new();
            Data_Connections conection = new();
            Console.Clear();
            Console.WriteLine("#*************************************#");
            Console.WriteLine("#                                     #");
            Console.WriteLine("# --- Register Classes Student    --- #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#*************************************#");
            Console.WriteLine();
            Console.WriteLine("Favor informar o nome da disciplina");
            string Name = Console.ReadLine();
            Console.WriteLine("Favor informar a matricula do aluno");
            string userID = Console.ReadLine();
            Console.WriteLine("Favor informar o horario (manha, tarde ou noite)");
            string horario = Console.ReadLine();
            string queryInsert = $"INSERT INTO Subjects (Subjects, Time_Subject, user_id)" +
                     $" Values ('{Name}','{horario}', '{userID}')";
            register_repository.User_Register(queryInsert);
            screen_Repository.Menu_Teacher();
        }
        public void Update()
        {
            Data_Connections conection = new();
            Update_Repository update_Repository = new();
            Console.Clear();
            Console.WriteLine("#*************************************#");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#        --- User Update ---          #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#*************************************#");
            Console.WriteLine();
            string NIF_Update;
            do
            {
                Console.WriteLine("Favor informar o numero de contribuinte - NIF");
                NIF_Update = Console.ReadLine();

                string querySelect = @"SELECT * FROM [User] WHERE NIF = @nif";

                var listSelectParameters = new List<SqlParameter>
                            {
                                new SqlParameter("@nif", NIF_Update)
                            };

                var people = conection.ExcuteSQLToSelect(querySelect, listSelectParameters);
                if (people.Any())
                {
                    break;
                }
                    Console.Clear();
                    Console.WriteLine("Numero de contribuinte - NIF incorreto ");
                    Console.WriteLine();
                    Console.WriteLine("       Favor informar NIF valido       ");
                    Console.WriteLine();
                    Console.WriteLine("#*************************************#");
                    Console.WriteLine("#                                     #");
                    Console.WriteLine("#        --- User Update ---          #");
                    Console.WriteLine("#                                     #");
                    Console.WriteLine("#*************************************#");
                    Console.WriteLine();            
            } while (true);

            Person person = new();
            Console.Clear();
            Console.WriteLine("#*************************************#");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#   Favor informar os novos dados     #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#*************************************#");
            Console.WriteLine();            
            Console.WriteLine("Favor informar o nome completo");
            person.Name = Console.ReadLine();
            Console.WriteLine("Favor informar E-mail");
            person.Email = Console.ReadLine();
            Console.WriteLine("Favor informar a morada completa");
            person.Adress = Console.ReadLine();
            Console.WriteLine("Favor informar o numero de Telemovel");
            person.Phone = Console.ReadLine();
            string queryUpdate = @"UPDATE [User]
                                                SET Name = @nome,
                                                     Email = @email, 
                                                     Adress = @address, 
                                                     Phone = @phone
                                                 WHERE NIF = @nif_to_update";

           var  listUpdateParameters = new List<SqlParameter>
                            {
                                new SqlParameter("@nome", person.Name),
                                new SqlParameter("@email", person.Email),
                                new SqlParameter("@address", person.Adress),
                                new SqlParameter("@phone", person.Phone),
                                new SqlParameter("@nif_to_update", NIF_Update)
                            };

            update_Repository.User_Update(queryUpdate, listUpdateParameters);

        }
        public  void Finish()
        {
            Console.WriteLine("=========================================\n");
            Console.WriteLine("Obrigado!!! Tenha um bom dia!\n");
            Console.WriteLine("=========================================\n");
        }             
    }



}
