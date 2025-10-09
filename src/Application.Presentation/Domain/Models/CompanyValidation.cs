using Application.Presentation.Domain.Enums;
using Application.Presentation.Infra.Enum;

namespace Conecta.Doa.Application.Presentation.Domain.Models;

    public class CompanyValidation
    {
        public string Cnpj { get; init; }
        public string LegalName { get; init; }
        public string TradeName { get; init; }
        public string PostalCode { get; init; }
        public Enum_corporation RegistrationStatus { get; init; }
        public string OpeningDate { get; init; }

    }
