using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Entities
{
    public class LoanDBContext : DbContext
    {
        public LoanDBContext(DbContextOptions<LoanDBContext> options) : base(options)
        {

        }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<AdminMaster> AdminMaster { get; set; }
        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public DbSet<LoanCardMaster> LoanCardMaster { get; set; }
        public DbSet<EmployeeIssue> EmployeeIssue { get; set; }
        public DbSet<EmployeeCard> EmployeeCard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=WINDOWS-BVQNF6J;database=Loan;trusted_connection=true;encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCard>()
                   .HasKey(c => new { c.LoanId, c.EmployeeId });
        }

    }
}
