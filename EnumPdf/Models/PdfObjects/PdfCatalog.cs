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
  public class PdfCatalog : PdfObject
  {
    public PdfCatalog(PdfPages pdfPages) : base("Catalog")
    {
      Dictionary.Add("Pages", pdfPages.PdfReference());
    }
  }
}
