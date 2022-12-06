namespace Projeto_Escola
{
    public abstract class Person
    {
        public int Id_Person { get; set; }
        public string Name { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public abstract PersonType PersonType { get; protected set; }
    }

   
    public enum PersonType
    {
        Teacher,
        Student
    }
}
