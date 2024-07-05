
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Credit.Entities
{
    public class Intermediary
    {
       // [Key]
        public int Id { get; set; }

        public int? AddresseeId { get; set; }
        //[ForeignKey("AddresseeId")]
        public Addressee Addressee { get; set; }
        //[ForeignKey("LoanId")]
        public int? LoanDate { get; set; }
        public int? LoanId { get; set; }
        public Loan Loan { get; set; }
    }
} 
