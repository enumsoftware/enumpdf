
using System.Collections.Generic;
using System.Text;

namespace EnumPdf.Models
{
  public class Pdf
  {
    private List<PdfObject> pdfObjects = new List<PdfObject>();

    public Pdf(params PdfObject[] objects)
    {
      pdfObjects.AddRange(objects);
    }
    

    public string Build()
    {
      StringBuilder pdf = new StringBuilder();
      pdf.Append("%PDF-1.1\n\n");

      foreach (PdfObject pdfObject in pdfObjects)
      {
        pdf.Append(pdfObject.Build());
      }

      pdf.Append("trailer\n  << /Root " + pdfObjects[0].PdfObjectReference() + "\n   /Size "
          + (pdfObjects.Count + 1) + "\n  >>\n" + "%%EOF");

      return pdf.ToString();
    }
  }
}