using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Login_Page.Models
{
    public class Student
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public int age { get; set; }



    }
}
