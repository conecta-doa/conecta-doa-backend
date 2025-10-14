using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Presentation.Domain.Service;
using Application.Presentation.Domain.Models;

namespace Conecta.Doa.Application.Presentation.Controllers
{
    [Route("api/establishment")]
    [ApiController]
    public class EstablishmentController : MainController
    {
        private readonly InstitutionValidation _institutionValidation;

        public EstablishmentController(InstitutionValidation institutionValidation)
        {
            _institutionValidation = institutionValidation;
        }

        [HttpGet("check/{cnpj}")]
        public async Task<IActionResult> CheckEstablishment(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return BadRequest("CNPJ inválido.");

            var company = await _institutionValidation.ValidateCompanyAsync(cnpj);

            if (company == null)
                return NotFound("Empresa não encontrada ou não está ativa.");

            return Ok(company);
        }
    }
}
