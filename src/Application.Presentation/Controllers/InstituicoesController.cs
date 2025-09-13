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
        // Use a interface correta que a gente configurou
        private readonly IIBrasilAPI _brasilApiService;

        // Use a interface correta na injeção de dependência
        public InstituicoesController(IIBrasilAPI brasilApiService)
        {
            _brasilApiService = brasilApiService;
        }

        [HttpGet("Check/Company/{cnpj}")]
        public async Task<IActionResult> CheckInstituicoes([FromRoute] string cnpj)
        {
            // A chamada para a API que retorna o objeto completo
            var dadosCompletos = await _brasilApiService.GetAsync(cnpj);

            if (dadosCompletos == null)
            {
                return NotFound("CNPJ não encontrado");
            }

            // Crie uma nova instância do DTO de resposta
            var resumo = new ResumoEmpresaDTO
            {
                Cnpj = dadosCompletos.Cnpj,
                RazaoSocial = dadosCompletos.RazaoSocial,
                NomeFantasia = dadosCompletos.NomeFantasia,
                Cep = dadosCompletos.Cep,
                SituacaoCadastral = dadosCompletos.SituacaoCadastral,
                DataAbertura = dadosCompletos.DataAbertura,
                Bairro = dadosCompletos.Bairro,
                Municipio = dadosCompletos.Municipio,
                Uf = dadosCompletos.Uf
            };

            // Retorne apenas o DTO com os dados resumidos
            return Ok(resumo);
        }
    }
}