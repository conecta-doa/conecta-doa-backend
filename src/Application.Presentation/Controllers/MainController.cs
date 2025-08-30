using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Doa.Application.Presentation.Controllers;

public abstract class MainController : ControllerBase
{
    protected string GetUserDocument(ClaimsPrincipal claimsPrincipal)
    {
        var document = claimsPrincipal.FindFirst("document")?.Value;

        return document;
    }
}