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
      pdf.AddText("Hello World!", 10, 50);
      pdf.AddPage();
      pdf.AddText("Hello World!", 10, 50);

      pdf.SaveFile(nameof(MultiplePagesExample));
    }
  }
}
