using Microsoft.EntityFrameworkCore;
using smart_credit.Entities;
using Smart_Credit.Entities;

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
        
    }
}
