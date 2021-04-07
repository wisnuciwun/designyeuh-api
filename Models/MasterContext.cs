using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace designyeuh_api.Models
{
    public class MasterContext : DbContext
    {
        
        
       public DbSet<Resumes> Resumes {get; set;}

        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Resumes>();
        }

    }
}