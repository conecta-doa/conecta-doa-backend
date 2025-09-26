using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Conecta.Doa.Application.Presentation.Infra.Models;
using Application.Presentation.Interfaces;
using Conecta.Doa.Application.Presentation.Controllers;
using Application.Presentation.Domain.Enums; // Adicione este using para o seu enum

namespace Conecta.Doa.Application.Presentation.Controllers
{
    [Route("api/establishment")]
    public class EstablishmentController : MainController
    {
        private readonly ICompanyLookupService _institutionApiService;

        public EstablishmentController(ICompanyLookupService brasilApiService)
        {
            _institutionApiService = brasilApiService;
        }

        [HttpGet("check/{document}")]
        public async Task<IActionResult> CheckEstablishment( string document)
        {
            var DataComplete = await _institutionApiService.GetAsync(document);

            if (DataComplete == null)
            {
                return NotFound("CNPJ não encontrado");
            }
            
           
            //EEstablishmentRegistrationStatus situacao = EEstablishmentRegistrationStatus.Unknown; // Valor padrão


            var resumo = new CompanyValidation
            {
                Cnpj = DataComplete.Cnpj,
                LegalName = DataComplete.LegalName,
                TradeName = DataComplete.TradeName, 
                PostalCode = DataComplete.PostalCode,
              RegistrationStatus = DataComplete.RegistrationStatus,
                
                OpeningDate = DataComplete.OpeningDate,
            };
            
            return Ok(resumo);
        }
    }
}