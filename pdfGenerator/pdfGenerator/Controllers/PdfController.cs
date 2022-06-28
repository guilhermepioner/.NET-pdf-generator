using Microsoft.AspNetCore.Mvc;

namespace pdfGenerator.Controllers;

[ApiController]
[Route("[controller]")]
public class PdfController : ControllerBase
{
    [HttpGet("[action]")]
    public IActionResult Ping()
    {
        return Ok("Pong!");
    }
}