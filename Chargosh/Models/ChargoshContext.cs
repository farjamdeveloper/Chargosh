using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chargosh.Models
{
    public class ChargoshContext:DbContext
    {
        public ChargoshContext()
        {
            Database.SetInitializer<ChargoshContext>(new DropCreateDatabaseIfModelChanges<ChargoshContext>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}