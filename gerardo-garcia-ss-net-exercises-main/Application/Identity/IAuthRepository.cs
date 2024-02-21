using Common.Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public interface IAuthRepository : IAuthRepositoryBase
    {
        Task<User> Add(User user);
        T Remove<T>(T entity) where T : Entity;
        T Update<T>(T entity) where T : Entity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        User FindUser(string email, string password);
    }
}
