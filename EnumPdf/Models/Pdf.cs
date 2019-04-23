
using System.Collections.Generic;
using System.Text;

namespace EnumPdf.Models
{
  public class Pdf
  {
    public string Version { get; set; } = "1.7";
    public List<PdfObject> PdfObjects { get; set; } = new List<PdfObject>();
    public PdfPages Pages { get; set; }
    public PdfCatalog Catalog { get; set; }
    public PdfPage CurrentPage { get; set; }
    public int ObjectNumber { get; set; } = 1;

    public Pdf(MediaBox mediaBox)
    {
      Pages = new PdfPages(ObjectNumber); // Move to function
      PdfObjects.Add(Pages);
      ObjectNumber++;

      Catalog = new PdfCatalog(ObjectNumber, this.Pages); // Move to function
      PdfObjects.Add(Catalog);
      ObjectNumber++;

      this.AddPage(mediaBox);
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

    public void AddPage(MediaBox mediaBox)
    {
      CurrentPage = new PdfPage(ObjectNumber, Pages, mediaBox);
      Pages.AddPage(CurrentPage);
      PdfObjects.Add(CurrentPage);
      ObjectNumber++;
    }

    public void AddText(string text, int x, int y)
    {
      PdfFont font = new PdfFont(ObjectNumber, "Times-Roman");
      PdfObjects.Add(font);
      ObjectNumber++;

      PdfText textObj = new PdfText(ObjectNumber, text, x, y);
      CurrentPage.AddContent(textObj);
      PdfObjects.Add(textObj);
      ObjectNumber++;
    }

    public void AddImage()
    {
      // TODO: add image support
      ObjectNumber++;
    }
  }
}