using System.ComponentModel.DataAnnotations;

namespace Login_Page.Models
{
    public class Users
    {
        public int Id { get; set; } //primary ket in the DB

        [Required]
        public string UserName { get; set; }

        [Required]
        public string password { get; set; }

        public int status { get; set; }
    }
}
