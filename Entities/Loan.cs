namespace Smart_Credit.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateOnly LoanDate { get; set; }
        public Repayment Repayment { get; set; }
        public DeadlineDate Deadline { get; set; }
    }
}
