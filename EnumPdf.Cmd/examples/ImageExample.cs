using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Models;
using EnumPdf.Cmd;

namespace EnumPdf.Cmd.Examples
{
  public class ImageExample
  {
    public static void Create()
    {
      Pdf pdf = new Pdf();
      pdf.AddImage("images/cube.jpg", 10, 50, 40, 40);
      Helpers.WriteFiles(pdf, nameof(ImageExample));
    }
  }
}

