using DAL;
using DAL.Interface;
using DAL.models;

namespace DAL.Implementation
{
    public class ContactRepository : IRepository<Contact>
    {

        public ContactRepository() { }

        public Contact Create(Contact _object)
        {
            List<Contact> contacts = JsonFileHelper.ReadFromJsonFile<Contact>();
            if (contacts == null)
                contacts = new List<Contact>();
            int nextId = contacts.Any() ? contacts.Max(x => x.ID) + 1 : 1;
            _object.ID = nextId;
            contacts.Add(_object);
            JsonFileHelper.WriteToJsonFile(contacts);
            return _object;
        }

        public void Update(Contact _object)
        {
            List<Contact> contactList = JsonFileHelper.ReadFromJsonFile<Contact>();
            Contact existingContact = contactList.First(x => x.ID == _object.ID);
            existingContact.FirstName = _object.FirstName;
            existingContact.LastName = _object.LastName;
            existingContact.Email = _object.Email;
            JsonFileHelper.WriteToJsonFile(contactList);
        }

        public IEnumerable<Contact> GetAll()
        {
            List<Contact> contactList = JsonFileHelper.ReadFromJsonFile<Contact>();
            return contactList;
        }

        public Contact GetById(int Id)
        {
            List<Contact> contactList = JsonFileHelper.ReadFromJsonFile<Contact>();
            return contactList.FirstOrDefault(x => x.ID == Id);
        }

        public void Delete(Contact _object)
        {
            List<Contact> contactList = JsonFileHelper.ReadFromJsonFile<Contact>();
            Contact existingContact = contactList.First(x => x.ID == _object.ID);
            contactList.Remove(existingContact);
            JsonFileHelper.WriteToJsonFile(contactList);
        }
    }
}
