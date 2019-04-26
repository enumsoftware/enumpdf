using System;
using System.IO;
using System.Text;
using EnumPdf.Models;

namespace EnumPdf.Cmd
{
  public static class Helpers
  {
    public static void WriteFiles(Pdf pdf, string filename)
    {
      // DirectoryInfo di = new DirectoryInfo("pdf");
      // foreach (FileInfo file in di.GetFiles())
      // {
      //   file.Delete();
      // }

      var txtStream = File.CreateText($"pdf/{filename}.txt");
      var stream = File.Create($"pdf/{filename}.pdf");
      var pdfString = pdf.Build();
      var bytes = Encoding.Default.GetBytes(pdfString);
      var count = Encoding.Default.GetByteCount(pdfString);

      var bla = pdfString.Split("\n");
      // foreach (var line in bla)
      // {
      //   txtStream.WriteLine(line);
      // }
      // txtStream.Flush();

      stream.Write(bytes, 0, count);
      stream.Flush();

      Console.WriteLine($"Done generating pdf: ({filename})");
    }
  }
}
