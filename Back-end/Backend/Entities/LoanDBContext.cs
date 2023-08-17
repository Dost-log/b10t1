using Microsoft.EntityFrameworkCore;

namespace Backend.Entities
{
    public class LoanDBContext : DbContext
    {
        public LoanDBContext(DbContextOptions<LoanDBContext> dbContextOptions): base(dbContextOptions) 
        { }  
        public DbSet<AdminMasters> AdminMasters { get; set; }
        public DbSet<ItemMasters> ItemMasters { get; set; }
        public DbSet<EmployeeMasters> EmployeeMasters { get; set; }
        public DbSet<LoanCardMasters> LoanCardMasters { get; set; }
        public DbSet<EmployeeIssues> EmployeeIssues { get; set; }
        public DbSet<EmployeeCards> EmployeeCards { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=WINDOWS-BVQNF6J;database=Loan;trusted_connection=true;encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EmployeeCards>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });
        }

    }
}
