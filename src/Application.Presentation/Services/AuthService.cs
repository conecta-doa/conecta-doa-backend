// using Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;
// using Conecta.Doa.Application.Presentation.Domain.Entities;
// using Conecta.Doa.Application.Presentation.Domain.Interfaces;
// using Conecta.Doa.Application.Presentation.Dto;
// using Conecta.Doa.Application.Presentation.Extensions;
// using Conecta.Doa.Application.Presentation.Interfaces;
// using Microsoft.AspNetCore.Identity;

// namespace Conecta.Doa.Application.Presentation.Services;

// public class AuthService(IUserRepository userRepository) : IAuthService
// {
//     private readonly IUserRepository _userRepository = userRepository;
//     private readonly PasswordHasher<object> _hasher = new();

//     public async Task<AuthResult> CreateRegisterAsync(UserRegisterDto dto)
//     {
//         var userHasErrors = await ValidateUser(dto);

//         if (userHasErrors == null)
//         {
//             dto.Password = HashPassword(dto.Password);

//             var user = dto.ToEntity();

//             await _userRepository.SaveUserAsync(user);

//             return new { Success = true, Token = "JWT" };
//         }

//         return new { Success = false, Errors = userHasErrors };
//     }

//     public async Task<AuthResult> LoginAsync(UserLoginDto dto)
//     {
//         var userExists = await _userRepository.GetUserByDocumentAsync(dto.Document);

//         if (userExists == null)
//             return new { Success = false, Errors = userExists };

//         var isSamePassword = VerifyPassword(userExists.Password, dto.Password);

//         if (!isSamePassword)
//             return new { Success = false, Errors = userExists };

//         return new { Success = true, Token = "JWT" };
//     }

//     private async Task<List<string>> ValidateUser(UserRegisterDto user)
//     {
//         var errors = new List<string>();

//         var documentErrors = await ValidateDocumentAsync(user.Document, user.DocumentType);
//         if (documentErrors.Count > 0)
//             return errors;

//         var passwordErrors = ValidatePassword(user.Password);
//         if (passwordErrors.Count > 0)
//             return errors;

//         return null;
//     }

//     private async Task<List<string>> ValidateDocumentAsync(string document, EDocumentType documentType)
//     {
//         var errors = new List<string>();

//         if (string.IsNullOrWhiteSpace(document))
//         {
//             errors.Add("O documento não pode estar vazio");
//             return errors;
//         }

//         switch (documentType)
//         {
//             case EDocumentType.CNPJ when !CNPJ.IsValid(document):
//             case EDocumentType.CPF when !CPF.IsValid(document):
//                 errors.Add("O documento está inválido");
//                 return errors;
//         }

//         var userExists = await _userRepository.GetByDocumentAsync(document);

//         if (userExists)
//         {
//             errors.Add("Este documento já está cadastrado");
//             return errors;
//         }

//         return null;
//     }

//     private static List<string> ValidatePassword(string password)
//     {
//         var errors = new List<string>();

//         if (string.IsNullOrWhiteSpace(password))
//         {
//             errors.Add("A senha não pode estar vazia.");
//             return errors;
//         }

//         if (password.Length < 8)
//             errors.Add("A senha deve ter pelo menos 8 caracteres.");

//         if (!password.Any(char.IsUpper))
//             errors.Add("A senha deve conter pelo menos uma letra maiúscula.");

//         if (!password.Any(char.IsLower))
//             errors.Add("A senha deve conter pelo menos uma letra minúscula.");

//         if (!password.Any(char.IsDigit))
//             errors.Add("A senha deve conter pelo menos um número.");

//         if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
//             errors.Add("A senha deve conter pelo menos um caractere especial.");

//         if (errors.Count < 0)
//             return null;

//         return errors;
//     }

//     private string HashPassword(string password) => _hasher.HashPassword(null, password);

//     private bool VerifyPassword(string hashedPassword, string providedPassword)
//     {
//         var isPasswordValid = _hasher.VerifyHashedPassword(null, hashedPassword, providedPassword);

//         if (isPasswordValid == PasswordVerificationResult.Success)
//             return true;

//         return false;
//     }

//     private static AuthResult Success(string token) =>
//         new AuthResult { Success = true, Token = token, Errors = Array.Empty<string>() };

//     private static AuthResult Failure(params string[] errors) =>
//         new AuthResult { Success = false, Errors = errors };

//     private static AuthResult Failure(IEnumerable<string> errors) =>
//         new AuthResult { Success = false, Errors = errors };
// }
