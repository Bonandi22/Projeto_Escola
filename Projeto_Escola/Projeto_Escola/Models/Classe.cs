using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projeto_Escola.Models
{
    public class Classe
    {
        public int ID { get; set; }
        public string Subjects { get; set; }
        public string Time_Subjects { get; set; }
        public int User_Id { get; set; }

        public Classe() { }
        public Classe(int iD, string subjects, string time_Subjects, int user_Id)
        {
            ID = iD;
            Subjects = subjects;
            Time_Subjects = time_Subjects;
            User_Id = user_Id;
        }
    }
}
