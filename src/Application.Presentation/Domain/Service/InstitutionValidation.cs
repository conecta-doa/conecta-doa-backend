using System;
using System.Threading.Tasks;
using Application.Presentation.Domain.Enum;
using Application.Presentation.Interfaces; 
using Application.Presentation.Domain.Models; 
using Application.Presentation.Service; 

namespace Application.Presentation.Domain.Service
{
    public class InstitutionValidation
    {
        private readonly ICompanyLookupService _companyLookupService;

        public InstitutionValidation(ICompanyLookupService companyLookupService)
        {
            _companyLookupService = companyLookupService;
        }

        public async Task<CompanyValidation?> ValidateCompanyAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("CNPJ inválido.");

            
            var companyInfo = await _companyLookupService.GetAsync(cnpj);

            if (companyInfo == null)
                return null; 

           
            if (companyInfo.RegistrationStatus != Enum_corporation.ACTIVE)
                return new CompanyValidation
                {
                    Cnpj = companyInfo.Cnpj,
                    LegalName = null,
                    TradeName = null,
                    PostalCode = null,
                    RegistrationStatus = companyInfo.RegistrationStatus,
                    Mensagem = companyInfo.StatusMessage,
                    OpeningDate = null
                };

           
            return new CompanyValidation
            {
                Cnpj = companyInfo.Cnpj,
                LegalName = companyInfo.LegalName,
                TradeName = companyInfo.TradeName,
                PostalCode = companyInfo.PostalCode,
                RegistrationStatus = companyInfo.RegistrationStatus,
                Mensagem = companyInfo.StatusMessage,
                OpeningDate = DateTime.TryParse(companyInfo.OpeningDate, out var dt) ? dt : null
            };
        }
    }
}
