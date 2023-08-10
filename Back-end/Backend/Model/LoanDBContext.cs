using Microsoft.EntityFrameworkCore;

namespace Backend.Entities
{
    public class LoanDBContext : DbContext
    {

        public DbSet<ItemMaster> ItemMasters{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=WINDOWS-BVQNF6J;database=Loan;trusted_connection=true;encrypt=false");
        }

    }
}
