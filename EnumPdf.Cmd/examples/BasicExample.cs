using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Models;
using EnumPdf.Cmd;

namespace EnumPdf.Cmd.Examples
{
  public class BasicExample
  {
    public static void Create()
    {
      var mediaBox = new MediaBox(0, 0, 200, 200);
      PdfFont font = new PdfFont("Times-Roman");
      PdfText text = new PdfText("Hello World!", 10, 50);

      var pages = new PdfPages();
      var page = new PdfPage(pages, mediaBox);
      page.AddContent(text);
      pages.AddPage(page);

      PdfCatalog catalog = new PdfCatalog(pages);

      Pdf pdf = new Pdf(
        catalog,
        pages,
        page,
        font,
        text);

      Helpers.WriteFiles(pdf, nameof(BasicExample));
    }
  }
}
