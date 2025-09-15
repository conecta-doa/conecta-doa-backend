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
            
            
            var resumo = new CompanySummaryDTO
            {
                Cnpj = dadosCompletos.Cnpj,
                LegalName = dadosCompletos.RazaoSocial,
                TradeName = dadosCompletos.NomeFantasia, 
                PostalCode  = dadosCompletos.Cep  ,
                RegistrationStatus  = dadosCompletos.SituacaoCadastral,
                OpeningDate  = dadosCompletos.DataAbertura,
            };

          
            return Ok(resumo);
        }
    }
}