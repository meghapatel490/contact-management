using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace contact_management_system
{
    public class CreateContactRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
