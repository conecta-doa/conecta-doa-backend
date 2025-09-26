using Application.Presentation.Domain.Enums;

namespace Conecta.Doa.Application.Presentation.Infra.Models
{
    public class CompanyValidation
    {
        public string? Cnpj { get; set; }
        public string? LegalName { get; set; }
        public string? TradeName { get; set; }
        public string? PostalCode { get; set; }
        public EEstablishmentRegistrationStatus RegistrationStatus { get; set; }
        public string? OpeningDate { get; set; }

    }
}