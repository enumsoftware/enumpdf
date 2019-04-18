using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  // MediaBox
  // There are 4 types of boxes
  // https://www.prepressure.com/pdf/basics/page-boxes 
  // 14.11.2 Page Boundaries in PDF manual
  public class PdfReferenceTable
  {
    public List<PdfObject> PdfObjects { get; set; }
    public string Pdf { get; set; }
    public PdfReferenceTable(string pdf, List<PdfObject> pdfObjects)
    {
      this.Pdf = pdf;
      this.PdfObjects = pdfObjects;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"xref\n");
      sb.Append($"{0} {PdfObjects.Count}\n");

      // Format
      //0000000000 65535 f
      int i = 0;

      sb.Append($"0000000000 65535 f\n");

      PdfObjects.ForEach(obj =>
      {
        var bytes = ReadBytes(this.Pdf, obj.CrossSectionReference());
        var byteOffset = bytes.ToString().PadLeft(10, '0');
        var generationNumber = "00000";
        var flags = "n"; // f or n free or in use

        sb.Append($"{byteOffset} {generationNumber} {flags}\n");
        i++;
      });
      return sb.ToString();
    }

    // Reads bytes until it finds object reference
    public static int ReadBytes(string pdf, string str)
    {
      StringBuilder sb = new StringBuilder();
      string[] lines = pdf.Split('\n');

      var index = pdf.IndexOf(str);
      var sub = pdf.Substring(0, index);
      return sub.Length;
    }
  }
}
