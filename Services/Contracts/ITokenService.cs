using Shop.Models;

namespace Shop.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}