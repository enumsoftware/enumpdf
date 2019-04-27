using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Other;

namespace EnumPdf.Models
{
  public class PdfCatalog : PdfObject
  {
    public PdfCatalog(int objectNumber, PdfPages pdfPages, PageLayout pageLayout = PageLayout.SinglePage) : base(objectNumber, "Catalog")
    {
      Dictionary.Add("Pages", pdfPages.PdfReference());
      Dictionary.Add("PageLayout", $"/{pageLayout.ToString()}");
    }
  }


}
