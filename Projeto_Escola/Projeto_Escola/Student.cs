using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto_Escola
{
    public class Student : Person
    {
                     
        public sealed override PersonType PersonType
        {
            get => PersonType;
            protected set => PersonType = PersonType.Student;
        }

        public void MenuStudent()
        {
            var conection = new Data_Connections();

            Console.Clear();
            Console.WriteLine("#**************************************#");
            Console.WriteLine("# #");
            Console.WriteLine("# --- MENU PRINCIPAL Estudante --- #");
            Console.WriteLine("# #");
            Console.WriteLine("# 1 - Cadastrar Novo Estudante #");
            Console.WriteLine("# 2 - Editar Cadastro Estudante #");
            Console.WriteLine("# 3 - Deletar Cadastro Estudante #");
            Console.WriteLine("# 4 - Sair #");
            Console.WriteLine("# #");
            Console.WriteLine("# #");
            Console.WriteLine("#**************************************#");
            Console.WriteLine();
            Console.Write("Digite sua opcao: ");


            int opcaoMenuPrincipal = int.Parse(Console.ReadLine());

            if (opcaoMenuPrincipal < 0 || opcaoMenuPrincipal > 4)
            {
                Console.WriteLine("Opção inválida, digite novamente");
                opcaoMenuPrincipal = int.Parse(Console.ReadLine());
            }

            string sair = "";
            while (opcaoMenuPrincipal != 4)
            {

                switch (opcaoMenuPrincipal)
                {
                    //cadastro de Estudantes

                    case 1:

                        Console.WriteLine("#**************************************#");
                        Console.WriteLine("# #");
                        Console.WriteLine("# --- MENU Cadastro Estudante --- #");
                        Console.WriteLine("# #");
                        Console.WriteLine("#**************************************#");
                        Console.WriteLine();

                        Console.WriteLine("Favor informar o nome completo");
                        string Nome_Student = Console.ReadLine();

                        Console.WriteLine("Favor informar o numero de contribuinte - NIF");
                        int NIF_Student = int.Parse(Console.ReadLine());

                        Console.WriteLine("Favor informar E-mail)");
                        string Email_Student = Console.ReadLine();

                        Console.WriteLine("Favor informar a morada completa)");
                        string Adress_Student = Console.ReadLine();

                        Console.WriteLine("Favor informar o numero de Telemovel)");
                        int Phone_Student = int.Parse(Console.ReadLine());

                        string queryInsert = $"INSERT INTO Student (Nome_Student, NIF_Student, Email_Student, Adress_Student, Phone_Student) " +
                                             $"Values ({Nome_Student}, {NIF_Student}, {Email_Student}, {Adress_Student}, {Phone_Student})";

                        conection.ExcuteSQL(queryInsert);

                        Console.WriteLine("Cadastro realizado com sucesso");
                        break;

                    case 2:

                        Console.WriteLine("#**************************************#");
                        Console.WriteLine("# #");
                        Console.WriteLine("# --- MENU Update Estudante --- #");
                        Console.WriteLine("# #");
                        Console.WriteLine("#**************************************#");
                        Console.WriteLine();

                        Console.WriteLine("Favor informar o numero de contribuinte - NIF");
                        string NIF_Update = Console.ReadLine();


                        Console.WriteLine("Favor informar o nome completo");
                        string Nome = Console.ReadLine();

                        Console.WriteLine("Favor informar o numero de contribuinte - NIF");
                        int NIF = int.Parse(Console.ReadLine());

                        Console.WriteLine("Favor informar E-mail)");
                        string Email = Console.ReadLine();

                        Console.WriteLine("Favor informar a morada completa)");
                        string Adress = Console.ReadLine();

                        Console.WriteLine("Favor informar o numero de Telemovel)");
                        int Phone = int.Parse(Console.ReadLine());

                        string queryUpdate = @"UPDATE Student
                                                SET Nome_Student = @nome, 
                                                     NIF_Student = @nif,
                                                     Email_Student = @email, 
                                                     Adress_Student = @address, 
                                                     Phone_Student = @phone 
                                                 WHERE NIF_Student = @nif_to_update";

                        var listParameters = new List<SqlParameter>();
                        listParameters.Add(new SqlParameter("@nome", Nome));
                        listParameters.Add(new SqlParameter("@nif", NIF));
                        listParameters.Add(new SqlParameter("@email", Email));
                        listParameters.Add(new SqlParameter("@address", Adress));
                        listParameters.Add(new SqlParameter("@phone", Phone));
                        listParameters.Add(new SqlParameter("@nif_to_update", NIF_Update));

                        conection.ExcuteSQL(queryUpdate, listParameters);

                        break;

                    case 3:

                        Console.WriteLine("#**************************************#");
                        Console.WriteLine("# #");
                        Console.WriteLine("# --- MENU Delete Estudante --- #");
                        Console.WriteLine("# #");
                        Console.WriteLine("#**************************************#");
                        Console.WriteLine();

                        Console.WriteLine("Favor informar o numero de contribuinte - NIF");
                        string NIF_Delet = Console.ReadLine();

                        Console.WriteLine("Deseja realmente deletar o cadastro? S/N");
                        string Delete = Console.ReadLine();

                        if (Delete.StartsWith("s", StringComparison.OrdinalIgnoreCase))
                        {
                            string queryDelete = $"DELETE FROM Student WHERE NIF_Student = {NIF_Delet}";

                            conection.ExcuteSQL(queryDelete);
                        }

                        break;

                }

                Console.WriteLine("Sair para o menu principal? S/N");
                sair = Console.ReadLine();

                if (sair.StartsWith("s", StringComparison.OrdinalIgnoreCase))
                {
                    opcaoMenuPrincipal = 4;
                }
            }




        }


    }
}



