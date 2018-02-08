using Corespa.Models;
using System.Data.Entity;

namespace Corespa.Repositories
{
    public class Context : DbContext
    {       

        public Context() : base("cnxConnection")
        {           
        }
     
        public DbSet<User> Users { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
          
        }

    }

}

