using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Other;

namespace EnumPdf.Models
{
  public class PdfPage : PdfObject
  {
    public List<PdfObject> Contents { get; } = new List<PdfObject>();
    public MediaBox MediaBox { get; }
    public PdfPage(int objectNumber, PdfObject parent, MediaBox mediaBox) : base(objectNumber, "Page")
    {
      MediaBox = mediaBox;
      
      Dictionary.Add("Parent", parent.PdfReference());
      Dictionary.Add("MediaBox", MediaBox);
      Dictionary.Add("Resources", "<< >>");
    }

    public void AddContent(PdfObject pdfObject)
    {
      Contents.Add(pdfObject);
      Dictionary["Contents"] = PdfArrayOfReferences();
    }

    public void AddResources(PdfObject pdfObject)
    {
      Dictionary["Resources"] = pdfObject.PdfReference();
    }

    // Maybe make this a helper
    private string PdfArrayOfReferences()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("[");
      Contents.ForEach(page =>
      {
        sb.Append($" {page.PdfReference()}"); // TODO: make this work for array of kids
      });
      sb.Append(" ]");
      return sb.ToString();
    }
  }
}
