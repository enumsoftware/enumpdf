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
      Pdf pdf = new Pdf();
      pdf.AddText("Page 1 Line 1", 10, 50);
      pdf.AddPage();
      pdf.AddText("Page 2 Line 1", 10, 50);
      pdf.AddText("Page 2 Line 2", 10, 70);
      pdf.AddImage("images/cube.jpg", 100, 100, 40, 40);

      pdf.SaveFile(nameof(MultiplePagesExample));
    }
  }
}
