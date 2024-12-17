using BAL.Interface;
using DAL.Interface;
using DAL.models;

namespace BAL.Implementation
{
    public class ContactManagementService : IContactManagementService
    {
        private readonly IRepository<Contact> _contactRepository;
        public ContactManagementService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public int AddContact(Contact contact)
        {
            contact = _contactRepository.Create(contact);
            return contact.ID;
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> contactList = _contactRepository.GetAll().ToList();
            return contactList;
        }
        public Contact GetContactById(int id)
        {
            Contact contact = _contactRepository.GetById(id);
            return contact;
        }

        public void RemoveContact(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public void UpdateContact(Contact Contact)
        {
            _contactRepository.Update(Contact);
        }
    }
}
