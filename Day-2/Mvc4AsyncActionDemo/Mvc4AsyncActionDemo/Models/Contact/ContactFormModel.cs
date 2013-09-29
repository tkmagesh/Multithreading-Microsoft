using System.Collections.Generic;

namespace Mvc4AsyncActionDemo.Models.Contact
{
    public class ContactFormModel
    {
        public IEnumerable<DAL.Entities.Contact> Contacts { get; set; }
        public CreateContactModel NewContact { get; set; }
    }
}