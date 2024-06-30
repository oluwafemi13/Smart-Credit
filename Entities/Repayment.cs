using Microsoft.EntityFrameworkCore;
using Smart_Credit.Entities;
using System.ComponentModel.DataAnnotations;

namespace smart_credit.Entities
{
    public class Repayment
    {
        //public int Id { get; set; }
        [Key]
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        //public int LoanId { get; set; }
        public IEnumerable<Loan> Loan { get; set; }
    }
}   
