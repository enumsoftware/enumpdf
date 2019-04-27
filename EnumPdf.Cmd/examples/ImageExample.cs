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
      pdf.AddImage("images/cube.jpg", 100, 100, 40, 40);
      pdf.SaveFile(nameof(ImageExample));
    }
  }
}

