using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using Server.Dtos;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PdfController : ControllerBase
{
    [HttpPost("create-pdf")]
    public async Task<IActionResult> PostPdf([FromBody] ReceiptDto dto)
    {
        string templatePath = Path.Combine("wwwroot", "Templates", "modelo.html");
        string outputPath = Path.Combine("wwwroot", "Templates", "result.pdf");

        string htmlContent = await System.IO.File.ReadAllTextAsync(templatePath);

        htmlContent = htmlContent.Replace("{{name}}", dto.Name)
                                 .Replace("{{receiptId}}", dto.ReceiptId)
                                 .Replace("{{price1}}", dto.Price1.ToString("F2"))
                                 .Replace("{{price2}}", dto.Price2.ToString("F2"))
                                 .Replace("{{total}}", (dto.Price1 + dto.Price2).ToString("F2"))
                                 .Replace("{{date}}", DateTime.Now.ToString("dd/MM/yyyy"));

        var converter = new HtmlToPdf();
        converter.Options.PdfPageSize = PdfPageSize.A4;
        converter.Options.MarginLeft = 20;
        converter.Options.MarginRight = 20;
        converter.Options.MarginTop = 20;
        converter.Options.MarginBottom = 20;

        PdfDocument pdf = converter.ConvertHtmlString(htmlContent, Path.GetFullPath("wwwroot"));
        pdf.Save(outputPath);
        pdf.Close();

        return StatusCode(201, new { message = "PDF criado com sucesso", filePath = "result.pdf" });
    }

    [HttpGet("fetch-pdf")]
    public async Task<IActionResult> GetPdf()
    {
        try
        {
            string pdfPath = Path.Combine("wwwroot", "Templates", "result.pdf");
            string absolutePdfPath = Path.GetFullPath(pdfPath);

            return PhysicalFile(absolutePdfPath, "application/pdf", "result.pdf");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar PDF: {ex.Message}");
        }
    }
}