using Microsoft.EntityFrameworkCore;

namespace Backend.Entities
{
    public class LoanDBContext : DbContext
    {

        public DbSet<EmployeeMaster> EmployeeMasters{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=,database=Loan;trusted=cnnectiontrue");
        }

    }
}
