using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{

  //  PdfObject fontNameObj = new PdfObject("Font");
  //     fontNameObj.AddKey("Subtype", "/Type1");
  //     fontNameObj.AddKey("BaseFont", "/Times-Roman");
  //     PdfObject font = new PdfObject("Font", new PdfObject("F1", fontNameObj));
  public class PdfFont : PdfObject
  {
    public PdfFont(string fontName) : base("Font")
    {
      Dictionary.Add("Subtype", "/Type1");
      Dictionary.Add("Name", $"/{ObjectNumber}"); // /name must be unique
      Dictionary.Add("BaseFont", $"/{fontName}");
    }
  }
}
