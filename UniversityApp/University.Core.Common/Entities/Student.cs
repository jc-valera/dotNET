using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace University.Core.Common.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Names { get; set; }

        public string FirstSurname { get; set; }

        public string SecondSurname { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public int GenderId { get; set; }

        public int CarrersId { get; set; }

        public int MaximunLevelStudiesId { get; set; }

        public int CivilStatusId { get; set; }

        public int StudentStatusId { get; set; }

    }
}
