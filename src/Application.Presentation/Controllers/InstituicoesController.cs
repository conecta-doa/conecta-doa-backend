using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Presentation.Dto;
using Application.Presentation.Interfaces;
using Conecta.Doa.Application.Presentation.Controllers;

namespace Application.Presentation.Controllers
{
    [Route("api/Document")]
    public class InstituicoesController : MainController
    {
        private readonly ICorporation_information _brasilApiService;

        public InstituicoesController(ICorporation_information brasilApiService)
        {
            _brasilApiService = brasilApiService;
        }

        [HttpGet("Check/Company/{cnpj}")]
        public async Task<IActionResult> CheckInstituicoes([FromRoute] string cnpj)
        {
            
            var dadosCompletos = await _brasilApiService.GetAsync(cnpj);

           
            if (dadosCompletos == null)
            {
               
                return NotFound("CNPJ não encontrado");
            }
            
            
            var resumo = new ResumoEmpresaDTO
            {
                Cnpj = dadosCompletos.Cnpj,
                LegalName = dadosCompletos.LegalName,
                TradeName = dadosCompletos.TradeName, 
                PostalCode  = dadosCompletos.PostalCode ,
                RegistrationStatus  = dadosCompletos.RegistrationStatus,
                OpeningDate  = dadosCompletos.OpeningDate,
            };

          
            return Ok(resumo);
        }
    }
}