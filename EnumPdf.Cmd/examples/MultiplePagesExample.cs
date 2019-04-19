using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Models;
using EnumPdf.Cmd;

namespace EnumPdf.Cmd.Examples
{
  public class MultiplePagesExample
  {
    public static void Create()
    {
      var mediaBox = new MediaBox(0, 0, 200, 200);

      PdfFont font = new PdfFont("Times-Roman");
      PdfText text1 = new PdfText("Page1", 10, 50);
      PdfText text2 = new PdfText("Page2", 10, 50);

      var pages = new PdfPages();
      var page1 = new PdfPage(pages, mediaBox);
      page1.AddContent(text1);
      pages.AddPage(page1);

      var page2 = new PdfPage(pages, mediaBox);
      page2.AddContent(text2);
      pages.AddPage(page2);

      PdfCatalog catalog = new PdfCatalog(pages);

      Pdf pdf = new Pdf(
        catalog,
        pages,
        page1,
        page2,
        font,
        text1,
        text2);

      Helpers.WriteFiles(pdf, nameof(MultiplePagesExample));
    }
  }
}
