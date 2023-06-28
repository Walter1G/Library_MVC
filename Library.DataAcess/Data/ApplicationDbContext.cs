using Library.Models;
using Microsoft.EntityFrameworkCore;


namespace Library.DataAccess.Data
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

        //overide onModelcreating to seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Category>().HasData(
               new Category { Id=1, Name="Action",DisplayOrder=1},
               new Category { Id=2, Name="Scifi",DisplayOrder=2},
               new Category { Id=3, Name="History",DisplayOrder=3}
               );
        }

    }
}
