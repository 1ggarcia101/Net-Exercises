using Domain.Entities;

namespace Application.Identity.Jwt
{
    public interface IJwtCommand
    {

         string GenerateToken(User user);

    }
}
