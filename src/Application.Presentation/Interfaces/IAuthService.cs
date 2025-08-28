using Conecta.Doa.Application.Presentation.Dto;

namespace Conecta.Doa.Application.Presentation.Interfaces;

public interface IAuthService
{
    // TODO Alterar para JWT 
    public Task<object> CreateRegisterAsync(UserRegisterDto dto);
    public Task<string> LoginAsync(UserLoginDto dto);
}
