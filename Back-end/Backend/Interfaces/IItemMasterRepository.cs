using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IItemMasterRepository
    {
        ItemMasters GetItem(string id);
        void AddItem(ItemMasters itemMasters);
        void EditItem(ItemMasters itemMasters);
        void DeleteItem(string id);
    }
}
