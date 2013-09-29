using Microsoft.Build.Framework;

namespace Mvc4AsyncActionDemo.DAL.Entities
{
    public class Contact
    {
        [Required]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}