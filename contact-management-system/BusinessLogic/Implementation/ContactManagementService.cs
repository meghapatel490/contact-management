using contact_management_system.BusinessLogic.Interface;
using Newtonsoft.Json;

namespace contact_management_system.BusinessLogic.Implementation
{
    public class ContactManagementService : IContactManagementService
    {
        private readonly string JsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "mock.json");

        public ContactManagementService() { }

        public int AddContact(CreateContactRequest contactRequest)
        {
            var contactDetail = ReadFromJsonFile<Contact>();
            int nextId = contactDetail.Max(x => x.ID) + 1;
            Contact newContact = new Contact();
            newContact.ID = nextId;
            newContact.FirstName = contactRequest.FirstName;
            newContact.LastName = contactRequest.LastName;
            newContact.Email = contactRequest.Email;
            contactDetail.Add(newContact);
            WriteToJsonFile(contactDetail);
            return nextId;
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> contactList = ReadFromJsonFile<Contact>();
            return contactList;
        }
        public Contact? GetContactById(int id)
        {
            List<Contact> contactList = ReadFromJsonFile<Contact>();
            return contactList.FirstOrDefault(x => x.ID == id);
        }

        public void RemoveContact(int id)
        {
            List<Contact> contactList = ReadFromJsonFile<Contact>();
            Contact existingContact = contactList.First(x => x.ID == id);
            contactList.Remove(existingContact);
            WriteToJsonFile(contactList);
        }

        public void UpdateContact(UpdateContactRequest updateContact, int id)
        {
            List<Contact> contactList = ReadFromJsonFile<Contact>();
            Contact existingContact = contactList.First(x => x.ID == id);
            existingContact.FirstName = updateContact.FirstName;
            existingContact.LastName = updateContact.LastName;
            existingContact.Email = updateContact.Email;
            WriteToJsonFile(contactList);
        }

        #region Private Methods

        public List<T> ReadFromJsonFile<T>()
        {
            using StreamReader file = File.OpenText(JsonFilePath);
            JsonSerializer serializer = new JsonSerializer();
            return (List<T>)serializer.Deserialize(file, typeof(List<T>));
        }

        public void WriteToJsonFile<T>(List<T> data)
        {
            using StreamWriter file = File.CreateText(JsonFilePath);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, data);
        }

        #endregion
    }
}
