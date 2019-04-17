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
  public class PdfTrailer : PdfObject
  {
    public PdfTrailer(PdfObject obj, int size)
    {
      this.AddKey("Size", size);
      this.AddKey("Root", obj.PdfObjectReference());
    }
  }
}


//  pdf.Append("trailer\n  << /Root " + pdfObjects[0].GetPdfReference() + "\n   /Size "
//           + (pdfObjects.Count + 1) + "\n  >>\n" + "%%EOF");