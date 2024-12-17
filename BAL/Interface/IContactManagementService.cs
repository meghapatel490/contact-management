
using DAL.models;

namespace BAL.Interface
{
    public interface IContactManagementService
    {
        int AddContact(Contact contactRequest);
        void UpdateContact(Contact existingContact);
        void RemoveContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}
