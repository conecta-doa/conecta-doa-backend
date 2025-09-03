using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Presentation.Interfaces; 

namespace Application.Presentation.Controllers
{
    [ApiController]
   [Route("api/Instituicoes")]
    public class InstituicoesController : ControllerBase
    {
        private readonly IInstituicoesService _instituicoesService;

        public InstituicoesController(IInstituicoesService instituicoesService)
        {
            _instituicoesService = instituicoesService;
        }

        [HttpHead]
        public async Task<IActionResult> CheckInstituicoes([FromQuery] string cnpj)
        {
            try
            {
                var dados = await _instituicoesService.ObterDadosDoGoverno(cnpj);

                Response.Headers.Add("X-Razao-Social", dados.RazaoSocial);
                Response.Headers.Add("X-Nome-Fantasia", dados.NomeFantasia);
                Response.Headers.Add("X-Cnpj-Valido", dados.CnpjValido.ToString());
                Response.Headers.Add("X-Endereco", dados.Endereco);
                Response.Headers.Add("X-Email-Institucional", dados.EmailInstitucional);
                
                return Ok();
            }
            catch (System.Exception ex)
            {
                // Retorna 404 Not Found se a instituição não for encontrada ou 
                // outro erro acontecer na chamada ao governo.
                return NotFound(ex.Message);
            }
        }
    }
}