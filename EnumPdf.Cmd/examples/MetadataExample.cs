using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Models;
using EnumPdf.Cmd;
using EnumPdf.Other;

namespace EnumPdf.Cmd.Examples
{
  public class MetadataExample
  {
    public static void Create()
    {
      var metadata = new PdfMetadata(
        "Title",
        "Author",
        "Subject",
        "Keywords, One, Two",
        "Creator",
        DateTime.Now,
        DateTime.Now);

      var mediaBox = new MediaBox(0, 0, 200, 200);
      Pdf pdf = new Pdf(mediaBox, pdfMetadata: metadata);
      pdf.AddText("Hello World!", 10, 50);

      pdf.SaveFile(nameof(MetadataExample));
    }
  }
}
