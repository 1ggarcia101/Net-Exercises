using Domain.Entities;

namespace Application.Identity.Jwt
{
    public interface IJwtCommand
    {

        public string GenerateToken(User user);

    }
}
