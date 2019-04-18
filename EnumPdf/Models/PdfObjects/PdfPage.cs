using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfPage : PdfObject
  {
    public PdfPage(PdfObject parent, MediaBox mediaBox) : base("Page")
    {
      Dictionary.Add("Parent", parent.PdfReference());
      Dictionary.Add("MediaBox", mediaBox);
      // Dictionary.Add("Resources", "REFERENCE");
    }

    public void AddContent(PdfObject pdfObject)
    {
      Dictionary.Add("Contents", pdfObject.PdfReference());
    }
  }
}
