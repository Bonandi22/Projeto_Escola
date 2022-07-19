using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digibank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        public static void TelaPrincipal()
        {
           

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();


            Console.WriteLine("                                                       ");
            Console.WriteLine("                             Digite a opcao desejado   ");
            Console.WriteLine("                          ============================ ");
            Console.WriteLine("                             1 - Criar conta           ");
            Console.WriteLine("                          ============================ ");
            Console.WriteLine("                             2 - entrar com o NIF      ");
            Console.WriteLine("                          ============================ ");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1: CriarConta();
                    break;
                case 2: TelaLogin();
                    break;
               default: Console.WriteLine("Opcao invalida, aperte qualquer tecla para voltar ao menu principal");
                    Console.ReadLine();
                    TelaPrincipal();
                    break;
            }

            
        }

        private static void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("                                                       ");
            Console.WriteLine("                            Digite seu Nome:           ");
            string Nome = Console.ReadLine();
            Console.WriteLine("                          ============================ ");
            Console.WriteLine("                             Digite seu NIF:           ");
            string Nif = Console.ReadLine();
            Console.WriteLine("                          ============================ ");
            Console.WriteLine("                             Digite sua senha:         ");
            string Senha = Console.ReadLine();
            Console.WriteLine("                          ============================ ");

            //Criar conta

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(Nome);
            pessoa.SetNIf(Nif);
            pessoa.SetSenha(Senha);

            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                          Conta cadastrada com sucesso    ");
            Console.WriteLine("                          ============================    ");

            Console.ReadLine();

            TelaContalogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                       ");
            Console.WriteLine("                             Digite seu NIF            ");
            string Nif = Convert.ToString(Console.ReadLine());
            Console.WriteLine("                          ============================ ");
            Console.WriteLine("                             Digite sua senha          ");
            string Senha = Convert.ToString(Console.ReadLine());
            Console.WriteLine("                          ============================ ");

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.Nif == Nif && x.Senha == Senha);

            if(pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContalogada(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Pessoa nao cadastrada");

                Console.WriteLine();
                Console.WriteLine();
            }  

        }


        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string MSG =
                $" {pessoa.Nome} | Banco: {pessoa.Conta.GetCodiBanco()}" +
                $"| Agencia: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()}";
            Console.WriteLine("");
            Console.WriteLine($"        Seja Bem vindo, {MSG} ");
            Console.WriteLine(" ");

        }

        private static void TelaContalogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("      Digite a opcao desejada        ");
            Console.WriteLine("    ============================     ");
            Console.WriteLine("     1 - Realizar um deposito        ");
            Console.WriteLine("    ============================     ");
            Console.WriteLine("     2 - Realizar um levantamento    ");
            Console.WriteLine("    ============================     ");
            Console.WriteLine("     3 - Consultar Saldo             ");
            Console.WriteLine("    ============================     ");
            Console.WriteLine("     4 - Sair                        ");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    Console.WriteLine("Qual o valor que deseja depositar");
                    double Valor = Convert.ToInt32(Console.ReadLine());
                    Conta.deposita(Valor);
                    Console.WriteLine($"Valor depositado com sucesso na conta [{pessoa.Conta.GetNumeroConta()}]\n");
                    Console.WriteLine($"Seu saldo atualizado é de: [{pessoa.Conta.ConsultaSaldo()}]");
                    break;                    
                case 2:
                    Console.WriteLine("Qual o valor que deseja levantar\n");
                    Valor = Convert.ToInt32(Console.ReadLine());

                    if (Valor > pessoa.Conta.ConsultaSaldo())
                    {
                        Console.WriteLine("Valor solicitado maior que o saldo disponivel");
                        Console.WriteLine($"Saldo disponivel é de:[{pessoa.Conta.ConsultaSaldo()}]");
                    }
                    else
                    {
                        Conta.Saca(Valor);
                        Console.WriteLine($"Realizado um levantamento na conta [{pessoa.Conta.GetNumeroConta()}] de [{Valor}]\n");
                        Console.WriteLine($"Seu saldo atualizado é de:[{pessoa.Conta.ConsultaSaldo()}]");
                    }
                    break;
                case 3:
                    Console.WriteLine($"O saldo da conta [{pessoa.Conta.GetNumeroConta()}] é de: [{pessoa.Conta.ConsultaSaldo()}]");
                    break;              
                case 4: TelaPrincipal();
                break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opcao invalida");
                break;
            }
        }

    }
}
