using Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;

namespace Conecta.Doa.Application.Presentation.Domain.Entities;

public class User
{
    public string Document { get; private set; }
    public EDocumentType DocumentType { get; private set; }
    public string Password { get; private set; }

    public User(string document, EDocumentType documentType, string password)
    {
        Document = document;
        DocumentType = documentType;
        Password = password;
    }
}

public enum EDocumentType
{
    CNPJ = 1,
    CPF
}