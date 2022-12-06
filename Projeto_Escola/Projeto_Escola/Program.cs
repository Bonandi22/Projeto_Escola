using System;
using System.Data.SqlClient;

namespace Projeto_Escola
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            int opcao=1;           
            Teacher Teacher1 = new();
            Student Student1 = new();

            while (opcao!=0)
            {

                Console.WriteLine("#**************************************#");
                Console.WriteLine("# #");
                Console.WriteLine("# --- MENU PRINCIPAL --- #");
                Console.WriteLine("# #");
                Console.WriteLine("# 1 - Professor #");
                Console.WriteLine("# 2 - Estudante #");
                 Console.WriteLine("# 0 - Sair #");
                Console.WriteLine("# #");
                Console.WriteLine("# #");
                Console.WriteLine("#**************************************#");
                Console.WriteLine();
                Console.Write("Digite sua opcao: ");
                                
                opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                if (opcao < 0 || opcao > 3)
                {
                    Console.WriteLine("Opção inválida, digite novamente");
                    opcao = int.Parse(Console.ReadLine());
                }

                switch (opcao)
                {
                    case 1: Teacher1.MenuTeacher();

                        break;
                    case 2: Student1.MenuStudent();

                        break;

                }
            }

            Console.WriteLine("=========================================\n");
            Console.WriteLine("Obrigado!!! Tenha um bom dia!\n");
            Console.WriteLine("=========================================\n");


        }
       
    }

}
    

