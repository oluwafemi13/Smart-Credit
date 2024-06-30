using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Credit.Entities
{
    public class LenderBorrower
    {
        public int Id { get; set; }
        public int LenderId { get; set; }
        [ForeignKey("LenderId")]
        public Lender Lender { get; set; }
        public int BorrowerId { get; set; }
        [ForeignKey("BorrowerId")]
        public Borrower Borrower { get; set; }
        public DateTime LoanDate { get; set; }
        public float Percentage { get; set; }
        public int LoanId { get; set; }
        [ForeignKey("LoanId")]
        public Loan Loan { get; set; }
        
    }
}
