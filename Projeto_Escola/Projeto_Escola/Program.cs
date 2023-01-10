using Projeto_Escola.Models;
using Projeto_Escola.Repositories;

namespace Projeto_Escola
{


    public class Program
    {
        public static Person authenticatedPerson = null;
        public static void Main(string[] args)
        {
            Screen_Repository screen_Repository = new();
            
            screen_Repository.Init_System();          
            screen_Repository.Finish();
        }          
    }

}


