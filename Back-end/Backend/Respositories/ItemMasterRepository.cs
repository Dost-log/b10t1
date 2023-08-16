using Backend.Model;
using Backend.Entities;

namespace Backend.Services
{
    public class ItemMasterRepository : IItemMasterRepository
    {
        private readonly LoanDBContext _dbconnect;
        public ItemMasterRepository(LoanDBContext _dbconnect)
        {
            this._dbconnect =_dbconnect;    
        }
        public ItemMasters GetItem(string id)
        { 
            var itemMasters = _dbconnect.ItemMasters.FirstOrDefault(x => x.itemId == id);
            return itemMasters;
        }

        public void AddItem(ItemMasters itemMasters)
        {
            _dbconnect.ItemMasters.Add(itemMasters);
            _dbconnect.SaveChanges();
        }
        
        public void DeleteItem(string id)
        {
            ItemMasters itemMasters = _dbconnect.ItemMasters.Find(id);
            _dbconnect.ItemMasters.Remove(itemMasters);
            _dbconnect.SaveChanges();
        }
        public void EditItem(ItemMasters itemMasters)
        {
            _dbconnect.ItemMasters.Update(itemMasters);
            _dbconnect.SaveChanges();
        }
    }
}
