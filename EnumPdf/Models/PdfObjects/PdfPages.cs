using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfPages : PdfObject
  {
    public List<PdfPage> Pages { get; } = new List<PdfPage>();
    public PdfPages() : base("Pages")
    {
    }

    public void AddPage(PdfPage pdfPage)
    {
      Pages.Add(pdfPage);
      Dictionary.Add("Kids", PdfArrayOfReferences());
      Dictionary.Add("Count", 1);
    }

    // Maybe make this a helper
    private string PdfArrayOfReferences()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("[");
      Pages.ForEach(page =>
      {
        sb.Append($" {page.PdfReference()}"); // TODO: make this work for array of kids
      });
      sb.Append(" ]");
      return sb.ToString();
    }
  }
}
