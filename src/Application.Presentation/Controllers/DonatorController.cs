using Conecta.Doa.Application.Presentation.Interfaces;
using Conecta.Doa.Application.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Doa.Application.Presentation.Controllers;

public class DonatorController(IDonatorAppService donatorAppService) : MainController
{
    private readonly IDonatorAppService _donatorAppService = donatorAppService;

    [HttpPost("generate-qr-code")]
public async Task<IActionResult> CreateQrCodePayment([FromBody] PixPayloadDto dto)
{
    if (!ModelState.IsValid)
        return BadRequest(new PixPayloadDto.PixPayloadResponse { IsSuccess = false, Error = "Dados inválidos" });

    var response = await _donatorAppService.CreatePixPayment(dto);

    if (response is null || !response.IsSuccess)
        return BadRequest(response ?? new PixPayloadDto.PixPayloadResponse { IsSuccess = false, Error = "Erro ao processar" });

    return Ok(response);
}
}