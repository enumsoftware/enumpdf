using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfTrailer : PdfObject
  {
    public PdfTrailer(PdfObject rootObj, int size, PdfMetadata metadata)
    {
      Dictionary.Add("Size", size);
      Dictionary.Add("Root", rootObj.PdfReference());
      Dictionary.Add("Info", metadata.PdfReference());
    }

    public override StringBuilder Build()
    {
      StringBuilder pdfObject = new StringBuilder();
      pdfObject
        .Append("trailer\n")
        .Append($"{BuildObject()}\n");

      return pdfObject;
    }

    public override StringBuilder BuildObject()
    {
      var TWO_SPACES = "  ";
      StringBuilder sb = new StringBuilder();
      sb.Append("<<\n");
      Dictionary.ToList().ForEach(keyValue =>
      {
        sb.Append(TWO_SPACES).Append($"/{keyValue.Key} {keyValue.Value.ToString()}\n");
      });
      sb.Append(">>");
      return sb;
    }
  }
}