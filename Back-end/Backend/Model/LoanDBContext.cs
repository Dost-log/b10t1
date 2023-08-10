using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Entities
{
    public class LoanDBContext : DbContext
    {

        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<AdminMaster> AdminMasters { get; set; }
        public DbSet<EmployeeMaster> EmployeeMasters { get; set; }
        public DbSet<LoanCardMaster> LoanCardMasters { get; set; }
        public DbSet<EmployeeIssue> EmployeeIssues { get; set; }
        public DbSet<EmployeeCard> EmployeeCards { get; set; }

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
