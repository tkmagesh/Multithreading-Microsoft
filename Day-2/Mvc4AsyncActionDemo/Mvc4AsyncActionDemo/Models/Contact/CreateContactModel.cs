using System.ComponentModel.DataAnnotations;

namespace Mvc4AsyncActionDemo.Models.Contact
{
    public class CreateContactModel
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}