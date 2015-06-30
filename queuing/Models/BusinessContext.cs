using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queuing.Models
{
    public class BusinessContext : DbContext
    {
        public BusinessContext()
            : base("ConStr")
        {

        }

        public DbSet<Business> business { get; set; }
        public DbSet<BusinessType> businessType { get; set; }
        public DbSet<BusinessWithoutOrder> businessWithoutOrder { get; set; }
    }
}
