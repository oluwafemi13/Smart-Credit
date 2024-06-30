using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Credit.Entities
{
    public class LoanRequestLender
    {
        public int Id { get; set; }
        public DateTime LoanRequestDate { get; set; }
        public int LenderId { get; set; }
        [ForeignKey("LenderId")]
        public Lender Lender { get; set; }
        public float Amount { get; set; }
        public int LoanRequestId { get; set; }
        [ForeignKey("LoanRequestId")]
        public LoanRequest LoanRequest { get; set; }
        

    }
}
