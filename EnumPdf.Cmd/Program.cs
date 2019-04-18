using System;
using System.IO;
using System.Text;
using EnumPdf.Models;

namespace EnumPdf.Cmd
{
  public class Program
  {
    static void Main(string[] args)
    {
      var mediaBox = new MediaBox(0, 0, 200, 200);
      PdfFont font = new PdfFont("Times-Roman");
      PdfText text = new PdfText("Hello World!");
      PdfTemp temp = new PdfTemp();

      var pages = new PdfPages();
      var page = new PdfPage(pages, mediaBox);
      page.AddContent(text);
      pages.AddPage(page);

      PdfCatalog catalog = new PdfCatalog(pages);

      // Console.WriteLine(catalog.ToString());
      // Console.WriteLine(pages.ToString());
      // Console.WriteLine(page.ToString());
      // Console.WriteLine(font.ToString());
      // Console.WriteLine(text.ToString());
      // Console.WriteLine(trailer.ToString());


      Pdf pdf = new Pdf(
        catalog,
        pages,
        page,
        font,
        text,
        temp);

      WriteFiles(pdf);
    }

    private static void WriteFiles(Pdf pdf)
    {
      DirectoryInfo di = new DirectoryInfo("pdf");
      foreach (FileInfo file in di.GetFiles())
      {
        file.Delete();
      }

      var filename = "testfile";
      var txtStream = File.CreateText($"pdf/{filename}.txt");
      var stream = File.Create($"pdf/{filename}.pdf");
      var pdfString = pdf.Build();
      var bytes = Encoding.ASCII.GetBytes(pdfString);
      var count = Encoding.ASCII.GetByteCount(pdfString);

      var bla = pdfString.Split("\n");
      foreach (var line in bla)
      {
        txtStream.WriteLine(line);
      }
      txtStream.Flush();

      stream.Write(bytes, 0, count);
      stream.Flush();

      Console.WriteLine("Done generating pdf");
    }
  }
}
