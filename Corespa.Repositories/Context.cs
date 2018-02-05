using Corespa.Models;
using System.Data.Entity;
using System.IO;
using System.Configuration;

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

