using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Presentation.Dto;

namespace Application.Presentation.Interfaces
{
    public interface IInstituicoesService
    {
        Task<DadosInstituicaoGov> ObterDadosDoGoverno(string cnpj);
    }
}