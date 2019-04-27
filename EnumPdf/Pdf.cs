
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EnumPdf.Helpers;
using EnumPdf.Models;
using EnumPdf.Other;

namespace EnumPdf
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
          $"Document {Guid.NewGuid().ToString()}",
          "EnumPdf",
          "Document",
          "Document",
          "EnumPdf",
          DateTime.Now,
          DateTime.Now);
      }
    }

    public MediaBox MediaBoxDefaultValue
    {
      get { return new MediaBox(0, 0, 595.28f, 841.89f); }
    }

    public Pdf(
      MediaBox mediaBox = null,
      string version = "1.7",
      PageLayout pageLayout = PageLayout.OneColumn,
      PdfMetadata pdfMetadata = null)
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
      sb.Append($"%PDF-{Version}\n");
      sb.Append(BinaryComment());

      foreach (PdfObject pdfObject in PdfObjects)
      {
        sb.Append(pdfObject.Build());
      }

      var pdfFileUpUntilXref = sb.ToString(); // Temp pdf so that we can calculate position to Reference table

      var xref = new PdfReferenceTable(pdfFileUpUntilXref, PdfObjects);
      var xrefPosition = PdfHelpers.Encoding.GetByteCount(pdfFileUpUntilXref);
      sb.Append($"{xref.ToString()}");

      var trailer = new PdfTrailer(this.Catalog, PdfObjects.Count + 1, PdfMetadata);
      sb.Append(trailer.Build());

      // Tells pdf where to find xref table
      sb.Append("startxref\n");
      sb.Append($"{xrefPosition}\n");
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

    public void AddImage(string fileName, float x, float y, float width, float height)
    {
      PdfFont font = new PdfFont(ObjectNumber, "Times-Roman");
      PdfObjects.Add(font);
      ObjectNumber++;

      // TODO: add image support
      PdfImage image = new PdfImage(ObjectNumber, fileName, width, height);
      PdfObjects.Add(image);
      ObjectNumber++;

      PdfObject procSet = new PdfObject(ObjectNumber);
      procSet.Dictionary.Add("ProcSet", $"[/PDF /Text /ImageB /ImageC /ImageI]");
      procSet.Dictionary.Add("Font", $"<< {font.Name} {font.PdfReference()} >>");
      procSet.Dictionary.Add("XObject", $"<< {image.Name} {image.PdfReference()} >>");
      PdfObjects.Add(procSet);
      ObjectNumber++;

      PdfImageTransform pdfImageTransform = new PdfImageTransform(ObjectNumber, fileName, image.Name, x, y, width, height, CurrentPage.MediaBox);
      PdfObjects.Add(pdfImageTransform);
      ObjectNumber++;

      CurrentPage.AddResources(procSet);
      CurrentPage.AddContent(pdfImageTransform);
    }

    private void AddMetadata(PdfMetadata pdfMetadata)
    {
      PdfMetadata = pdfMetadata;
      pdfMetadata.UpdateObjectNumber(ObjectNumber);
      PdfObjects.Add(pdfMetadata);
      ObjectNumber++;
    }

    public void SaveFile(string filename)
    {
      var stream = File.Create($"pdf/{filename}.pdf");

      var pdfString = Build();
      var bytes = PdfHelpers.Encoding.GetBytes(pdfString);
      var count = PdfHelpers.Encoding.GetByteCount(pdfString);
      stream.Write(bytes, 0, count);
      stream.Flush();
      stream.Close();

      Console.WriteLine($"Done generating pdf: ({filename})");
    }

    /// <summary>
    /// Returns specified value or if it is null returns currentValue
    /// </summary>
    /// <param name="currentValue"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T ValueOrDefault<T>(T currentValue, T defaultValue)
    {
      return currentValue == null ? defaultValue : currentValue;
    }

    /// <summary>
    /// The presence of encoded character byte values greater 
    /// than decimal 127 near the beginning of a file 
    /// is used by various software tools and protocols to 
    /// classify the file as containing 8-bit binary 
    /// data that should be preserved during processing.
    /// </summary>
    /// <returns>Binary encoded comment</returns>
    private string BinaryComment()
    {
      var binaryComment = new byte[] { 255, 170, 234, 128 };
      var binaryString = PdfHelpers.Encoding.GetString(binaryComment);
      return $"%{binaryString}\n\n";
    }
  }
}