namespace contact_management_system.BusinessLogic.Interface
{
    public interface IContactManagementService
    {
        int AddContact(CreateContactRequest contactRequest);
        void UpdateContact(UpdateContactRequest contact, int id);
        void RemoveContact(int id);
        List<Contact> GetAllContacts();
        Contact? GetContactById(int id);
    }
}
