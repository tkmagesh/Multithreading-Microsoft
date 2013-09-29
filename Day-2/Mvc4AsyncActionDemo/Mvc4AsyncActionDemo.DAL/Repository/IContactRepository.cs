using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mvc4AsyncActionDemo.DAL.Entities;

namespace Mvc4AsyncActionDemo.DAL.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync(CancellationToken cancellationToken=default(CancellationToken));
        Task CreateAsync(Contact contact, CancellationToken cancellationToken=default(CancellationToken));
        Task DeleteAsync(long id, CancellationToken cancellationToken=default(CancellationToken));
    }
}