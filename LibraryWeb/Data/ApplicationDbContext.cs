using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        //establish connection between db and ef
       
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            //pass the connection string in the appsetting to the ctor by injecting it as a param as dbcontext option

            
        }
        //dbset to create a table 
        public DbSet<Category> Categories{ get; set; }

    }
}
