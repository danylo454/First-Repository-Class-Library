using Company.Data.Data.Initializer;
using Company.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=194.44.93.225;Database=DanyloEFRepository;User Id=test;Password=1;MultipleActiveResultSets=True;");

                //optionsBuilder.UseSqlServer(@"Server=52.168.23.170;Database=DanyloEFRepository;User Id=sa;Password=RpYP>$K((2Y$:_6K;MultipleActiveResultSets=True;"); */

                optionsBuilder.UseSqlServer(@"Server=DESKTOP-PFI6MSV\SQLEXPRESS;Database=DanyloEFRepository;Integrated Security=True");


            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ITCompany>().Property(c => c.Name).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyID);
           // modelBuilder.Seed();
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<ITCompany>? ITCompanies { get; set; }

    }
}

