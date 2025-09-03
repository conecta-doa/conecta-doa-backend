using Conecta.Doa.Application.Presentation.Dto;
using Conecta.Doa.Application.Presentation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Doa.Application.Presentation.Controllers;

public class DonatorController(IDonatorAppService donatorAppService) : MainController
{
    private readonly IDonatorAppService _donatorAppService = donatorAppService;

    [HttpPost("generate-qr-code")]
    public async Task<IActionResult> CreateQrCodePayment(PixPayloadDto payload)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        (string qrCodeResponse, string copyPasteCode) = _donatorAppService.CreatePixPayment(payload);

        return Ok(new
        {
            QrCode = qrCodeResponse,
            CopyPaste = copyPasteCode
        });     
    }   
}