using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfFont : PdfObject
  {
    public PdfFont(string fontName) : base("Font")
    {
      Dictionary.Add("Subtype", "/Type1");
      Dictionary.Add("Name", $"/F1"); // /name must be unique
      Dictionary.Add("BaseFont", $"/Helvetica");
    }
  }
}
