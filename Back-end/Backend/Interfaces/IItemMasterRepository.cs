using Backend.Entities;
using Backend.Model;

namespace Backend.Services
{
    public interface IItemMasterRepository
    {
        ItemMasters GetItem(string id);
        void AddItem(ItemMasters itemMasters);
        void EditItem(ItemMasters itemMasters);
        void DeleteItem(string id);
    }
}
