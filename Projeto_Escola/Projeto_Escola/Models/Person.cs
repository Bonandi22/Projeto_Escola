using System;
using System.Collections.Generic;

namespace Projeto_Escola.Models
{
    public class Person
    {      
        public int Id_Person { get; set; }
        public string Typee { get; set; }

       public string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
            }
        }
        public string NIF { get; set; }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _email = value;
            }
        }
        private string _adress;
        public string Adress
        {
            get { return _adress; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _adress = value;
            }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _phone = value;
            }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _username = value;
            }
        }
        public string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _password = value;
            }
        }       

public Person() { }
               
        public Person(string name, string nif, string email, string adress, string phone, string login, string password)
        {
            Name = name;
            NIF = nif;
            Email = email;
            Adress = adress;
            Phone = phone;
            Username = login;
            Password = password;
        }
    }
    enum PersonType : int
    {
        Teacher=1,
        Student=2,
    }
}
