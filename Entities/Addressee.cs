namespace Smart_Credit.Entities;

public class Addressee
{
	public int Id { get; set; }	
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Address { get; set; }
    public Intermediary Intermediary { get; set; }
    public Lender Lender { get; set; }
    public Borrower Borrower { get; set; }
    
}
