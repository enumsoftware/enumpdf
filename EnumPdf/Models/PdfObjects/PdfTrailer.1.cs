using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfTemp : PdfObject
  {
    public PdfTemp()
    {
      Dictionary.Add("ProcSet[/PDF/Text]", "");
      Dictionary.Add("Font", "<</F1 1 0 R >>");
    }
  }
}