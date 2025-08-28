using Conecta.Doa.Application.Presentation.Domain.Entities;
using Conecta.Doa.Application.Presentation.Dto;

namespace Conecta.Doa.Application.Presentation.Extensions;

public static class UserExtensions
{
    public static UserRegisterDto ToEntity(this User user)
    {
        if (user == null)
            return null;

        return new UserRegisterDto
        {
            Document = user.Document,
            DocumentType = user.DocumentType,
            Password = user.Password
        };
    }

    public static User ToEntity(this UserRegisterDto user)
    {
        if (user == null)
            return null;

        return new User(user.Document, user.DocumentType, user.Password);
    }
}
