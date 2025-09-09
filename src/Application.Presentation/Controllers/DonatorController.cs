using Conecta.Doa.Application.Presentation.Interfaces;
using Conecta.Doa.Application.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Doa.Application.Presentation.Controllers;

public class DonatorController(IDonatorAppService donatorAppService) : MainController
{
    private readonly IDonatorAppService _donatorAppService = donatorAppService;

    [HttpPost("generate-qr-code")]
    public async Task<IActionResult> CreateQrCodePayment(PixPayloadDto payload)
    {
        if (!ModelState.IsValid)
            return BadRequest(new PixPayloadRespone
            {
                IsSuccess = false
            });
            
        var respone = await _donatorAppService.CreatePixPayment(payload);

        if (respone is null)
            return BadRequest(new PixPayloadRespone
            {
                IsSuccess = false
            });

        return Ok(new PixPayloadRespone
        {
            IsSuccess = true,
            CopyPaste = respone.CopyPaste,
            QrCode = respone.QrCode
        });
    }
}