
using System;
using System.Collections.Generic;
using System.Text;

namespace EnumPdf.Models
{
  public class Pdf
  {
    public int ObjectNumber { get; set; } = 1;
    public string Version { get; private set; }

    public List<PdfObject> PdfObjects { get; private set; } = new List<PdfObject>();
    public PdfPages Pages { get; private set; }
    public PdfCatalog Catalog { get; private set; }
    public PdfPage CurrentPage { get; private set; }
    public PdfMetadata PdfMetadata { get; private set; }
    public PdfMetadata PdfMetadataDefaultValue
    {
      get
      {
        return new PdfMetadata(
          "EnumPdf",
          "EnumPdf",
          "EnumPdf",
          "EnumPdf",
          "EnumPdf",
          DateTime.Now,
          DateTime.Now);
      }
    }

    public MediaBox MediaBoxDefaultValue
    {
      get { return new MediaBox(0, 0, 595.28f, 841.89f); }
    }

    public Pdf(MediaBox mediaBox = null, string version = "1.7", PageLayout pageLayout = PageLayout.SinglePage, PdfMetadata pdfMetadata = null)
    {
      Version = version;

      Pages = new PdfPages(ObjectNumber); // Move to function
      PdfObjects.Add(Pages);
      ObjectNumber++;

      Catalog = new PdfCatalog(ObjectNumber, this.Pages, pageLayout); // Move to function
      PdfObjects.Add(Catalog);
      ObjectNumber++;

      this.AddPage(mediaBox);
    }

    public string Build()
    {
      PdfMetadata = ValueOrDefault(PdfMetadata, PdfMetadataDefaultValue);
      AddMetadata(PdfMetadata);

      StringBuilder sb = new StringBuilder();
      sb.Append($"%PDF-{Version}\n%%EOF\n\n");

      foreach (PdfObject pdfObject in PdfObjects)
      {
        sb.Append(pdfObject.Build());
      }

      var untilXRef = sb.ToString(); // Temp pdf so that we can calculate position to Reference table

      var xref = new PdfReferenceTable(untilXRef, PdfObjects);
      sb.Append($"{xref.ToString()}");

      var trailer = new PdfTrailer(this.Catalog, PdfObjects.Count, PdfMetadata);
      sb.Append(trailer.Build());

      // Tells pdf where to find xref table
      sb.Append("startxref\n");
      sb.Append($"{untilXRef.Length}\n");
      sb.Append("%%EOF");

      return sb.ToString();
    }

    public void AddPage(MediaBox mediaBox = null)
    {
      mediaBox = ValueOrDefault<MediaBox>(mediaBox, MediaBoxDefaultValue);
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

      PdfObject procSet = new PdfObject(ObjectNumber);
      procSet.Dictionary.Add("ProcSet", $"[/PDF /Text]");
      procSet.Dictionary.Add("Font", $"<< {font.Name} {font.PdfReference()} >>");
      PdfObjects.Add(procSet);
      ObjectNumber++;

      PdfText textObj = new PdfText(ObjectNumber, text, x, y);
      CurrentPage.AddContent(textObj);
      PdfObjects.Add(textObj);
      ObjectNumber++;
    }

    public void AddImage(string fileName, int x, int y, int width, int height)
    {
      // TODO: add image support
      PdfImage image = new PdfImage(ObjectNumber, fileName, width, height);
      PdfObjects.Add(image);
      ObjectNumber++;

      PdfObject procSet = new PdfObject(ObjectNumber);
      procSet.Dictionary.Add("ProcSet", $"[/PDF /ImageC]");
      procSet.Dictionary.Add("XObject", $"<< /I0 {image.PdfReference()} >>");
      PdfObjects.Add(procSet);
      ObjectNumber++;

      PdfImageTransform pdfImageTransform = new PdfImageTransform(ObjectNumber, fileName);
      CurrentPage.AddResources(procSet);
      CurrentPage.AddContent(pdfImageTransform);
      PdfObjects.Add(pdfImageTransform);
      ObjectNumber++;

      ObjectNumber++;
    }

    private void AddMetadata(PdfMetadata pdfMetadata)
    {
      PdfMetadata = pdfMetadata;
      pdfMetadata.UpdateObjectNumber(ObjectNumber);
      PdfObjects.Add(pdfMetadata);
      ObjectNumber++;
    }

    public T ValueOrDefault<T>(object currentValue, T defaultValue)
    {
      return currentValue == null ? defaultValue : default(T);
    }
  }
}