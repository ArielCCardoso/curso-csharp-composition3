using System;

namespace Curso.Udemy.CSharpCompleto2020.Capitulo9.Composition3.Entities
{
    class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Client(string name,string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override string ToString() => $"{Name} ({BirthDate.ToLocalTime():dd/MM/yyyy}) - {Email}";
    }
}
