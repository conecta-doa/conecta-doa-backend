using System.ComponentModel.DataAnnotations;
using Conecta.Doa.Application.Presentation.Domain.Entities;

namespace Conecta.Doa.Application.Presentation.Dto;

public class UserRegisterDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório ")]
    public string Document { get; set; }
    public EDocumentType DocumentType { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório ")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "As senhas não conferem")]
    public string PasswordConfirmed { get; set; }
}

public class UserLoginDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório ")]
    public string Document { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório ")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
    public string Password { get; set; }    
}
