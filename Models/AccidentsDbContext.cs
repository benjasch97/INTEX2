using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// this sets up our database in our app

namespace INTEX2.Models
{
    public class AccidentsDbContext : DbContext
    {
        public AccidentsDbContext(DbContextOptions<AccidentsDbContext> options) : base(options)
        {

        }

        public DbSet<Accident> mytable { get; set; }
    }
}
