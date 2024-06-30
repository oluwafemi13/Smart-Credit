namespace Smart_Credit.Entities
{
    public class LoanRequest
    {
        public int Id { get; set; }
        public int BorowerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeadlineDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Payday { get; set; }
    }
}
