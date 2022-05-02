using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phnbk3.Entities
{
    
    public class ContactContext :DbContext
    {
        public DbSet<Contact>? Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=ContactDB;");
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
