using FinStock.Models;

namespace FinStock.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}