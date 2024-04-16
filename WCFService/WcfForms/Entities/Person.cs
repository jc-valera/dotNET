using System;

namespace WcfForms.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstSurname { get; set; }

        public string SecondSurname { get; set; }

        public string Area { get; set; }

        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }
    }
}
