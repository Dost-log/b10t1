using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Repositories
{
    public class AdminMastersRepository:IAdminMastersRepository
    {
        private readonly LoanDBContext _dbconnect;
        public AdminMastersRepository(LoanDBContext _dbconnect)
        {
            this._dbconnect =_dbconnect;    
        }
        public AdminMasters GetAdmin(string id)
        {
            var adminmaster = _dbconnect.AdminMasters.FirstOrDefault(x => x.EmployeeId == id);
            return adminmaster;
        }
        public void AddAdmin(AdminMasters adminmasters)
        {
            _dbconnect.AdminMasters.Add(adminmasters);
            _dbconnect.SaveChanges();
        }
        
        public void DeleteAdmin(string id)
        {
            AdminMasters adminmaster = _dbconnect.AdminMasters.Find(id);
            _dbconnect.AdminMasters.Remove(adminmaster);
            _dbconnect.SaveChanges();
        }
        public void EditAdmin(AdminMasters adminmaster)
        {
            _dbconnect.AdminMasters.Update(adminmaster);
            _dbconnect.SaveChanges();
        }
        public AdminMasters LoginAdminMasters(string id, string password)
        {
            var adminmaster = _dbconnect.AdminMasters.FirstOrDefault(x => x.EmployeeId == id);
            return adminmaster;
        }
    }
}
