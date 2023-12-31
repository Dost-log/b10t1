﻿using Backend.Entities;
using Backend.DTO;

namespace Backend.Interfaces
{
    public interface IItemMasterRepository
    {
        ItemMasters GetItem(string id);
        void AddItem(ItemMasters itemMasters);
        void EditItem(ItemMasters itemMasters);
        void DeleteItem(string id);
        List<ItemMasters> GetAllItemMasters();
    }
}
