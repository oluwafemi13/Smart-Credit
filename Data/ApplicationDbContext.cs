namespace Smart_Credit.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DeadlineDate> DeadlineDates { get; set; }
        
    }
}
