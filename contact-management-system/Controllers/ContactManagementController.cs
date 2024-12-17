using BAL.Interface;
using DAL.models;
using Microsoft.AspNetCore.Mvc;

namespace contact_management_system.Controllers
{
    [Route("api/v1/contact")]
    [ApiController]
    public class ContactManagementController : ControllerBase
    {
        private readonly ILogger<ContactManagementController> _logger;
        private readonly IContactManagementService _contactManagementService;

        public ContactManagementController(ILogger<ContactManagementController> logger, IContactManagementService contactManagementService)
        {
            _logger = logger;
            _contactManagementService = contactManagementService;
        }

        /// <summary>
        /// Get contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<Contact> contacts = new List<Contact>();
            contacts = _contactManagementService.GetAllContacts();
            return Ok(contacts);
        }

        /// <summary>
        /// Get contactRequest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contact? existingContact = _contactManagementService.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            return Ok(existingContact);
        }

        /// <summary>
        /// Add new contactRequest
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddContact([FromBody] CreateContactRequest contact)
        {
            Contact newContact = new Contact();
            newContact.FirstName = contact.FirstName;
            newContact.LastName = contact.LastName;
            newContact.Email = contact.Email;
            var newContactId = _contactManagementService.AddContact(newContact);
            return CreatedAtAction(nameof(AddContact), new { id = newContactId });
        }

        /// <summary>
        /// Update contactRequest details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateContact(int id, [FromBody] UpdateContactRequest contactRequest)
        {
            Contact? existingContact = _contactManagementService.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound();
            }
            existingContact.FirstName = contactRequest.FirstName;
            existingContact.LastName = contactRequest.LastName;
            existingContact.Email = contactRequest.Email;
            _contactManagementService.UpdateContact(existingContact);
            return NoContent();
        }

        /// <summary>
        /// Delete contactRequest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            Contact? existingContact = _contactManagementService.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound();
            }
            _contactManagementService.RemoveContact(existingContact);
            return NoContent();
        }
    }
}
