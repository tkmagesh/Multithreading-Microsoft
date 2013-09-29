using System.Data.Entity;

namespace Mvc4AsyncActionDemo.DAL.Entities
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}