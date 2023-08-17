using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IAdminMastersRepository
    {
        void AddAdmin(AdminMasters adminmaster);
        AdminMasters GetAdmin(string  id);
        void EditAdmin(AdminMasters adminmaster);
        void DeleteAdmin(string id);
        AdminMasters LoginAdminMasters(string id, string password);
    }
}
