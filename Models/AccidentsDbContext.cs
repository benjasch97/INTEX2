﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public class AccidentsDbContext : DbContext
    {
        public AccidentsDbContext(DbContextOptions<AccidentsDbContext> options) : base(options)
        {

        }

        public DbSet<Accident> Accidents { get; set; }
    }
}
