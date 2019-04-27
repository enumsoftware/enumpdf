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
  public class BasicExample
  {
    public static void Create()
    {
      Pdf pdf = new Pdf();
      pdf.AddText("Hello World!", 10, 50);
      pdf.SaveFile(nameof(BasicExample));
    }
  }
}
