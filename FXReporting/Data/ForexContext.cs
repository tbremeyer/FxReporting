using System;
using FXReporting.Models;
using Microsoft.EntityFrameworkCore;

namespace FXReporting.Data
{
    public class ForexContext : DbContext
    {
        public ForexContext(DbContextOptions<ForexContext> options) : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<ForexTransaction> ForexTransactions { get; set; }

        public DbSet<Robot> Robots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().ToTable("Bank");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");
            modelBuilder.Entity<ForexTransaction>().ToTable("ForexTransaction");
            modelBuilder.Entity<Robot>().ToTable("Robot");
        }
    }

}
