
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
      StringBuilder sb = new StringBuilder();
      sb.Append($"%PDF-{Version}\n%%EOF\n\n");

      foreach (PdfObject pdfObject in PdfObjects)
      {
        sb.Append(pdfObject.Build());
        // maybe calculate bytes here and add it to xref table
      }

      var untilXRef = sb.ToString(); // Temp pdf so that we can calculate Reference table

      var xref = new PdfReferenceTable(untilXRef, PdfObjects);
      sb.Append($"{xref.ToString()}");

      var trailer = new PdfTrailer(PdfObjects[0], PdfObjects.Count);
      sb.Append(trailer.Build());

      // Tells pdf where to find xref table
      sb.Append("startxref\n");
      sb.Append($"{untilXRef.Length}\n");
      sb.Append("%%EOF");

      return sb.ToString();
    }
  }
}