using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfCatalog : PdfObject
  {
    public PdfCatalog(int objectNumber, PdfPages pdfPages) : base(objectNumber,"Catalog")
    {
      Dictionary.Add("Pages", pdfPages.PdfReference());
    }
  }
}
