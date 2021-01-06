using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста ввелите своё имя")]
        public string NamePerson { get; set; }
        [Required(ErrorMessage = "Пожалуйста ввелите свою фамилию")]
        public string SurmamePerson { get; set; }
        [Required(ErrorMessage = "Пожалуйста ввелите своё отчество")]
        public string MiddlenamePerson { get; set; }
        [Required(ErrorMessage = "Пожалуйста ввелите свой номер телефона")]
        public int PhonePerson { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Пожалуйста ввелите свой Email")]

        public string EmailPerson { get; set; }
        public bool PaidProduct { get; set; }
        public int ProductId { get; set; }
    }
}
