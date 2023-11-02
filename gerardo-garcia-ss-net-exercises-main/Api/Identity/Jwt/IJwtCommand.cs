using Domain.Entities;

namespace Api.Identity.Jwt
{
    public interface IJwtCommand
    {

        public string GenerateToken(User user);

    }
}
