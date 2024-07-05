using Microsoft.EntityFrameworkCore;
using smart_credit.Entities;
using Smart_Credit.Entities;
using System.Reflection.Emit;

namespace Smart_Credit.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

        public DbSet<Deadline> DeadlineDates { get; set; }
        public DbSet<Intermediary> Intermediaries { get; set; } 
        public DbSet<Lender> Lenders { get; set; }  
        public DbSet<Loan> Loans { get; set; }  
        public DbSet<Repayment> Repayments { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }  
        public DbSet<Addressee> Addressees { get; set; }    
        public DbSet<LenderBorrower> LenderBorrowers { get; set; }  
        public DbSet<LoanRequestLender> LoanRequestLenders { get; set; }    
        public DbSet<LoanRequest> LoanRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<LenderBorrower>()
                .HasOne(p => p.Lender)
                .WithMany(c => c.LenderBorrower)
                .HasForeignKey(c => c.LenderId);*/
                


            modelBuilder.Entity<Lender>()
           .HasOne(u => u.Addressee)
           .WithOne(up => up.Lender)
           .HasForeignKey<Lender>(up => up.AddresseeId);

            modelBuilder.Entity<Borrower>()
          .HasOne(u => u.Addressee)
          .WithOne(up => up.Borrower)
          .HasForeignKey<Borrower>(up => up.AddresseeId);

            modelBuilder.Entity<Intermediary>()
            .HasOne(u => u.Addressee)
            .WithOne(up => up.Intermediary)
            .HasForeignKey<Intermediary>(up => up.AddresseeId);

            modelBuilder.Entity<Intermediary>()
           .HasOne(u => u.Loan)
           .WithOne(up => up.Intermediary)
           .HasForeignKey<Intermediary>(up => up.LoanId);

            modelBuilder.Entity<Borrower>()
                .HasMany(p => p.LenderBorrower)
                .WithOne(c => c.Borrower)
                .HasForeignKey(c => c.BorrowerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Loan>()
               .HasMany(p => p.LenderBorrower)
               .WithOne(c => c.Loan)
               .HasForeignKey(c => c.LoanId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Repayment>()
               .HasMany(p => p.Loan)
               .WithOne(c => c.Repayment)
               .HasForeignKey(c => c.RepaymentId)
               .OnDelete(DeleteBehavior.Cascade);
            // Optional: Configure cascade delete

            modelBuilder.Entity<Deadline>()
                .HasMany(p => p.Loan)
                .WithOne(c => c.DeadLine)
                .HasForeignKey(c => c.DeadLineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lender>()
                .HasMany(p => p.LoanRequestLender)
                .WithOne(c => c.Lender)
                .HasForeignKey(c => c.LenderId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
