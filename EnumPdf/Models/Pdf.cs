
using System.Collections.Generic;
using System.Text;

namespace EnumPdf.Models
{
  public class Pdf
  {
    public string Version { get; set; } = "1.4";
    public List<PdfObject> PdfObjects { get; set; } = new List<PdfObject>();
    public Pdf(params PdfObject[] objects)
    {
      PdfObjects.AddRange(objects);
    }

    public string Build()
    {
      PdfTrailer trailer = new PdfTrailer(PdfObjects[0], PdfObjects.Count);
      PdfObjects.Add(trailer);

      StringBuilder pdf = new StringBuilder();
      pdf.Append($"%PDF-{Version}\n%%EOF\n\n");

      foreach (PdfObject pdfObject in PdfObjects)
      {
        pdf.Append(pdfObject.Build());
      }
      return pdf.ToString();
    }
  }
}