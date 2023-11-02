using Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public class AuthRepository : AuthRepositoryBase, IAuthRepository
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

        public async Task<User> FindUserByFirstnameAsync(string firstname)
        {
            return await _userRepository.FindAsync(u => u.FirstName == firstname);
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _userRepository.FindAsync(u => u.Email == email);
        }

        // Implement additional user-related operations as needed
    }

}

