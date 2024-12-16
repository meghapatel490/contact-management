using contact_management_system.BusinessLogic.Interface;
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

        [HttpGet]
        public IActionResult Get()
        {
            List<Contact> contacts = new List<Contact>();
            contacts = _contactManagementService.GetAllContacts();
            return Ok(contacts);
        }

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


        [HttpPost]
        public IActionResult AddContact([FromBody] CreateContactRequest contact)
        {
            var newContactId = _contactManagementService.AddContact(contact);
            return CreatedAtAction(nameof(AddContact), new { id = newContactId });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContact(int id, [FromBody] UpdateContactRequest contact)
        {
            Contact? existingContact = _contactManagementService.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound();
            }
            _contactManagementService.UpdateContact(contact, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            Contact? existingContact = _contactManagementService.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound();
            }
            _contactManagementService.RemoveContact(id);
            return NoContent();
        }
    }
}
