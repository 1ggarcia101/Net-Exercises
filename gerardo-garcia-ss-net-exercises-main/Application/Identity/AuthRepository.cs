using Common.Domain;
using Common.Persistence;
using Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Identity
{
    public class AuthRepository : IAuthRepository
    {
        private readonly GenericRepository<User> _userRepository;

        public AuthRepository(AuthDbContext context)
        {
            _userRepository = new GenericRepository<User>(context);
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public User FindUser(string email, string password)
        {
            // Implement your user authentication logic here using _userRepository
            return _userRepository.FindAsync(u => u.Email == email && u.Password == password).Result;
        }

        public async Task<User> FindUserByFirstnameAsync(string firstname)
        {
            return await _userRepository.FindAsync(u => u.FirstName == firstname);
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _userRepository.FindAsync(u => u.Email == email);
        }

        public async Task<User> Add(User entity)
        {
            await _userRepository.AddAsync(entity);
            return entity;
        }


        public T Remove<T>(T entity) where T : Entity
        {
            return _userRepository.Remove(entity as User) as T;
        }

        public T Update<T>(T entity) where T : Entity
        {
            return _userRepository.Update(entity as User) as T;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _userRepository.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _userRepository.Query<User>() as IQueryable<T>;
        }

        public async Task<T?> GetAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : Entity
        {
            return await _userRepository.FindAsync<T>(id);
        }

        // Implement additional user-related operations as needed
    }
}
