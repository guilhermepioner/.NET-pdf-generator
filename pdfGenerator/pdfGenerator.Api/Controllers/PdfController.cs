using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using pdfGenerator.Utility;

namespace pdfGenerator.Controllers;

[ApiController]
[Route("[controller]")]
public class PdfController : ControllerBase
{
    private readonly IConverter _converter;

    public PdfController(IConverter converter)
    {
        _converter = converter;
    }

    /// <summary>
    /// Creates a browser page that renderizes the PDF
    /// </summary>
    /// <returns>A PDF file on browser</returns>
    /// <remarks>The PDF won't be shown on Swagger UI</remarks>
    [HttpGet("[action]")]
    public IActionResult CreatePdfToBrowser()
    {
        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "PDF Report"
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHtmlString(),
            WebSettings =
            {
                DefaultEncoding = "utf-8",
                UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css")
            },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Center = "Report Footer", Line = true }
        };

        var pdf = new HtmlToPdfDocument
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        var file = _converter.Convert(pdf);

        return File(file, "application/pdf");
    }

    /// <summary>
    /// Creates a PDF to be downloaded
    /// </summary>
    /// <returns>A PDF download link</returns>
    [HttpGet("[action]")]
    public IActionResult CreatePdfToDownload()
    {
        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "PDF Report"
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHtmlString(),
            WebSettings =
            {
                DefaultEncoding = "utf-8",
                UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css")
            },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Center = "Report Footer", Line = true }
        };

        var pdf = new HtmlToPdfDocument
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        var file = _converter.Convert(pdf);
        
        // To make the route download the PDF, its only needed to add the file name as an extra argument on the File type return 
        return File(file, "application/pdf", "EmployeeReport.pdf");
    }
}