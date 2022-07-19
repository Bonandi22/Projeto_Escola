using System;

namespace Exerc_Class_interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int QtdGas;
            
            Car car1 = new Car(10);
            

            Console.WriteLine("insira a quantidade de litros de Gasoleo desejado");
            QtdGas = Convert.ToInt32(Console.ReadLine());
            Drive(QtdGas);
            Refuel(QtdGas);
           
                                                      
        }

        static void Drive(int movimento)
        {
            if (movimento == 0)
            {
                Console.WriteLine("Carro esta parado");

            }
            else
            {
                Console.WriteLine("Carro esta em movimento");
            }


        }

        static bool Refuel(int Gasoleo)
        {

            while (Gasoleo == 0)
            {
                Console.WriteLine("Carro precisa ser abastecido");
                Gasoleo++;
            }


            return true;
        }

    }
}
