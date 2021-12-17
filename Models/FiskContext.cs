using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digitala_FiskGuiden.Models
{
    public class FiskContext : DbContext
    {
        public DbSet<Klass> Klasser { get; set; }
        public DbSet<Fisk> Fiskar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=klass.db");
        }

    }
}
