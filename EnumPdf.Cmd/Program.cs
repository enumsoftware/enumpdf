using System;
using System.IO;
using System.Text;
using EnumPdf.Models;

namespace EnumPdf.Cmd
{
  class Program
  {
    static void Main(string[] args)
    {
      PdfFont font = new PdfFont();
      Console.WriteLine(font.DebugTxt());

      PdfPage page = new PdfPage();
      Console.WriteLine(font.DebugTxt());

      //   PdfObject fontName = new PdfObject("Font");
      //   fontName.AddKey("Subtype", "/Type1");
      //   fontName.AddKey("BaseFont", "/Times-Roman");
      //   PdfObject font = new PdfObject("Font", new PdfObject("F1", fontName));

      //   PdfObject text = new PdfObject(4, 0);
      //   var hello = "Hello World";
      //   text.AddKey("Length", Encoding.ASCII.GetByteCount(hello).ToString());
      //   text.AddTextStream("F1", 18, 10, 50, "Hello World");

      //   PdfObject image = new PdfObject(5, 0);
      //   var imageFile = File.ReadAllBytes("images/image.jpg");
      //   image.AddKey("Length", imageFile.Length.ToString());
      //   image.AddImageStream(imageFile, 20, 20);

      //   PdfObject page = new PdfObject(3, 0, "Page");
      //   page.AddObjectKey("Resources", font);
      //   page.AddObjectReferenceKey("Contents", text);

      //   PdfObject pages = new PdfObject(2, 0, "Pages");
      //   pages.AddKey("Count", "1");
      //   pages.AddKey("MediaBox", "[0 0 300 144]");
      //   pages.AddObjectReferenceArrayKey("Kids", page);

      //   page.AddObjectReferenceKey("Parent", pages);

      //   Pdf pdf = new Pdf(root, pages, page, text);

      //   System.IO.DirectoryInfo di = new DirectoryInfo("pdf");

      //   foreach (FileInfo file in di.GetFiles())
      //   {
      //     file.Delete();
      //   }

      //   var filename = Guid.NewGuid().ToString();
      //   var txtStream = File.CreateText($"pdf/{filename}.txt");
      //   var stream = File.Create($"pdf/{filename}.pdf");
      //   var pdfString = pdf.Build();
      //   var bytes = Encoding.ASCII.GetBytes(pdfString);
      //   var count = Encoding.ASCII.GetByteCount(pdfString);

      //   var bla = pdfString.Split("\n");
      //   foreach (var line in bla)
      //   {
      //     txtStream.WriteLine(line);
      //   }
      //   txtStream.Flush();

      //   stream.Write(bytes, 0, count);
      //   stream.Flush();

      //   Console.WriteLine("Done generating pdf");
    }
  }
}
