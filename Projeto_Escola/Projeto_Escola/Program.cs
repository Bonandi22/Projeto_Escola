using Projeto_Escola.Models;
using Projeto_Escola.Repositories;

namespace Projeto_Escola
{


    public class Program
    {
        public static Person authenticatedPerson = null;
        public static void Main(string[] args)
        {
            ScreenRepository screen_Repository = new();            
            screen_Repository.InitSystem();          
            screen_Repository.Finish();
        }          
    }

}


