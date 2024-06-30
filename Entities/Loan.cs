using smart_credit.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Credit.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateOnly LoanDate { get; set; }
        public int RepaymentId { get; set; }
        [ForeignKey("RepaymentId")]
        public Repayment Repayment { get; set; }
        public int DeadLineId { get; set; }
        [ForeignKey("DeadLineId")]
        public Deadline DeadLine { get; set; }

        public IEnumerable<LenderBorrower> LenderBorrower { get; set; }
        public Intermediary Intermediary { get; set; }

    }
}
