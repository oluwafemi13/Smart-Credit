namespace Smart_Credit.Entities
{
    public class Deadline
    {
        public int Id { get; set; }
        public DateTime AgreedDate { get; set; }
        public IEnumerable<Loan> Loan { get; set; }
    }
}
