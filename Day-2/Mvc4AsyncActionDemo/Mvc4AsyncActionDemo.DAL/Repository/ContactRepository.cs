using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Mvc4AsyncActionDemo.DAL.Entities;

namespace Mvc4AsyncActionDemo.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        public async Task<List<Contact>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var context = new ContactContext())
            {
                return await context.Contacts.ToListAsync(cancellationToken);
            }
        }

        public async Task CreateAsync(Contact contact, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var context = new ContactContext())
            {
                context.Contacts.Add(contact);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var context = new ContactContext())
            {
                var contact = await context.Contacts.FindAsync(cancellationToken, id);
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
