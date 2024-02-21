using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public interface IAuthRepositoryBase
    {
        IQueryable<T> Query<T>() where T : Entity;
        Task<T?> GetAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : Entity;
    }
}
