using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace MvcLoginRegistration.Models
{
    public class OurDbContext 
    {
        public DbSet<UserAccount> userAccount { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
