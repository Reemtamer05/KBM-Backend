using KBM.Application.DTOs;

namespace KBM.Application.Interfaces
{
    public interface ITokenService
    {
        
        AuthResponseDto CreateToken(Guid userId, string email, IList<string> roles);
    }
}
