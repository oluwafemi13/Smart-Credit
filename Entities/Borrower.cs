using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Credit.Entities;

public class Borrower
{
	public int Id { get; set; }	
    public string firstName { get; set; }
    public string lastName { get; set; }    
	public int? AddresseeId { get; set; }
    //[ForeignKey("AddresseeId")]
    public Addressee Addressee { get; set; }
    public IEnumerable<LenderBorrower> LenderBorrower { get; set; }
    

}
