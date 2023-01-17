using Projeto_Escola.Connections;
using Projeto_Escola.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto_Escola.Repositories
{
    public class ScreenRepository
    {
        public void InitSystem()
        {      
            int escolha;
            do {
                Console.WriteLine("#*************************************#");
                Console.WriteLine("#                                     #");
                Console.WriteLine("#          --- MAIN MENU ---          #");
                Console.WriteLine("#                                     #");
                Console.WriteLine("# 1 - login                           #");
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
                        Console.WriteLine("Enter password? ");
                        string pass = Console.ReadLine();
                        autentication.Login(User, pass);
                     break;
                    case 2:
                        NewRegister();
                        break;
                        default:
                            Console.WriteLine("Opção inválida");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                }
            } while (escolha != 0);
        }
        public void MenuTeacher()
        {
            ListClasses listClasses = new();
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
                Console.WriteLine("# 5 - List Student and Classes        #");
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
                        DeletRepository DeletRepository = new();
                        DeletRepository.User_Delet();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("                 ");
                        List_Repository ListRepository = new();
                        ListRepository.ListUser(opcao);                        
                        break;
                    case 4:
                        NewSubject();
                        break;
                    case 5:
                        listClasses.ListSubjects();
                        break;
                    case 0:
                        InitSystem();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

            } while (escolha != 0);
        }
        public void MenuStudent()
        {
            ListClasses ListClasses = new();
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
                Console.WriteLine("# 3 - List students and classes        #");
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
                        Update();                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("                 ");
                        List_Repository ListRepository = new();
                        ListRepository.ListUser(opcao);
                        break;
                    case 3:
                        Console.WriteLine("Favor informar o numero de matricula");
                       int myid = int.Parse(Console.ReadLine());
                        ListClasses.ListSubjectsStudent(myid);

                        break;
                    case 0:
                        InitSystem();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (escolha != 0);
        }
        public void NewRegister()
        {
            ScreenRepository ScreenRepository = new();
            RegisterRepository RegisterRepository = new();
            DataConnections conection = new();
            Console.Clear();
            Console.WriteLine("#*************************************#");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#     --- Register New User ---       #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#*************************************#");
            Console.WriteLine();            

            Console.WriteLine("Favor informar o nome completo");
            string name = Console.ReadLine();
            Console.WriteLine("Favor informar o numero de contribuinte - nif");
            string nif = Console.ReadLine();
            Console.WriteLine("Favor informar E-mail)");
            string email = Console.ReadLine();
            Console.WriteLine("Favor informar a morada completa)");
            string adress = Console.ReadLine();
            Console.WriteLine("Favor informar o numero de Telemovel");
            string phone = Console.ReadLine();
            Console.WriteLine("Favor informar o nome de usuario");
            string login = Console.ReadLine();
            Console.WriteLine("Favor informar a senha");
            string password = Console.ReadLine();
            Console.WriteLine("Favor informar o tipo de usuário (Teacher or Student)");
            string type = Console.ReadLine();
            string queryInsert = $"INSERT INTO [User] (name, nif, email, adress, phone, [User], password, type )" +
                                 $" Values ('{name}', '{nif}', '{email}', '{adress}', '{phone}', '{login}', '{password}', '{type}')";

            RegisterRepository.UserRegister(queryInsert);
            ScreenRepository.InitSystem();
        }
        public void NewSubject()
        {
            ScreenRepository ScreenRepository = new();            
            RegisterRepository RegisterRepository = new();
            DataConnections conection = new();
            Console.Clear();
            Console.WriteLine("#*************************************#");
            Console.WriteLine("#                                     #");
            Console.WriteLine("# --- Register Classes Student    --- #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#*************************************#");
            Console.WriteLine();
            Console.WriteLine("Favor informar o nome da disciplina");
            string name = Console.ReadLine();
            Console.WriteLine("Favor informar a matricula do aluno");
            string userID = Console.ReadLine();
            Console.WriteLine("Favor informar o horario (manha, tarde ou noite)");
            string horario = Console.ReadLine();
            string queryInsert = $"INSERT INTO Subjects (Subjects, Time_Subject, user_id)" +
                     $" Values ('{name}','{horario}', '{userID}')";
            RegisterRepository.UserRegister(queryInsert);
            ScreenRepository.MenuTeacher();
        }
        public void Update()
        {
            DataConnections conection = new();
            UpdateRepository UpdateRepository = new();
            Console.Clear();
            Console.WriteLine("#*************************************#");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#        --- User Update ---          #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#*************************************#");
            Console.WriteLine();
            string nif_update;
            do
            {
                Console.WriteLine("Favor informar o numero de contribuinte - nif");
                nif_update = Console.ReadLine();

                string querySelect = @"SELECT * FROM [User] WHERE nif = @nif";

                var listSelectParameters = new List<SqlParameter>
                            {
                                new SqlParameter("@nif", nif_update)
                            };

                var people = conection.ExcuteSQLToSelect(querySelect, listSelectParameters);
                if (people.Any())
                {
                    break;
                }
                    Console.Clear();
                    Console.WriteLine("Numero de contribuinte - nif incorreto ");
                    Console.WriteLine();
                    Console.WriteLine("       Favor informar nif valido       ");
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
                                                SET name = @nome,
                                                     email = @email, 
                                                     adress = @address, 
                                                     phone = @phone
                                                 WHERE nif = @nif_to_update";

           var  listUpdateParameters = new List<SqlParameter>
                            {
                                new SqlParameter("@nome", person.Name),
                                new SqlParameter("@email", person.Email),
                                new SqlParameter("@address", person.Adress),
                                new SqlParameter("@phone", person.Phone),
                                new SqlParameter("@nif_to_update", nif_update)
                            };

            UpdateRepository.User_Update(queryUpdate, listUpdateParameters);

        }
        public  void Finish()
        {
            Console.WriteLine("=========================================\n");
            Console.WriteLine("Obrigado!!! Tenha um bom dia!\n");
            Console.WriteLine("=========================================\n");
        }             
    }



}
