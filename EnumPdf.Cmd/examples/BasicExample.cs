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
      Pdf pdf = new Pdf(mediaBox);
      pdf.AddText("Hello World!", 10, 50);

      Helpers.WriteFiles(pdf, nameof(BasicExample));
    }
  }
}
