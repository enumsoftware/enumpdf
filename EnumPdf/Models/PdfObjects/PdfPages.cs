using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  /// <summary>
  /// Page Tree 7.7.3.2 Pdf spec - Table 29
  /// </summary>
  public class PdfPages : PdfObject
  {
    const string Kids = "Kids";
    const string Count = "Count";

    public List<PdfPage> Pages { get; } = new List<PdfPage>();
    public PdfPages() : base("Pages")
    {
      Dictionary.Add(Kids, null);
      Dictionary.Add(Count, null);
    }

    public void AddPage(PdfPage pdfPage)
    {
      Pages.Add(pdfPage);

      Dictionary[Kids] = PdfArrayOfReferences();
      Dictionary[Count] = Pages.Count;
    }

    // Maybe make this a helper
    private string PdfArrayOfReferences()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("[");
      Pages.ForEach(page =>
      {
        sb.Append($" {page.PdfReference()} "); // TODO: make this work for array of kids
      });
      sb.Append(" ]");
      return sb.ToString();
    }
  }
}
