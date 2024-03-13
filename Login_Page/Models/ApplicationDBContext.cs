using Microsoft.EntityFrameworkCore;
namespace Login_Page.Models
{
   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; } //list of objects from my class

    }
}

// Migration -> converts the code to database Table.
// Add - Migration init -> converts the Class to SQL statements
// update-Database -> execute the SQL