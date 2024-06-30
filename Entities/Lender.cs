using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Credit.Entities
{
    public class Lender
    {
        public int Id { get; set; }
        public string LenderName { get; set; }
        public int AddresseeId { get; set; }
        [ForeignKey("AddresseeId")]
        public Addressee Addressee { get; set; }
        public IEnumerable<LoanRequestLender> LaonRequestLender { get; set; }
        public IEnumerable<LenderBorrower> LenderBorrower { get; set; }
    }
}
