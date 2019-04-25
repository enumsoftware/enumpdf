using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Models;
using EnumPdf.Cmd;

namespace EnumPdf.Cmd.Examples
{
  public class MetadataExample
  {
    public static void Create()
    {
      var mediaBox = new MediaBox(0, 0, 200, 200);
      Pdf pdf = new Pdf(mediaBox);
      pdf.AddText("Hello World!", 10, 50);
      pdf.AddMetadata(new PdfMetadata(
        "Title",
        "Author",
        "Subject",
        "Keywords, One, Two",
        "Creator",
        DateTime.Now,
        DateTime.Now));

      Helpers.WriteFiles(pdf, nameof(MetadataExample));
    }
  }
}
