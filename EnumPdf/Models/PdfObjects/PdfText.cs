using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnumPdf.Helpers;
using EnumPdf.Other;

namespace EnumPdf.Models
{
  public class PdfText : PdfObject
  {
    public string Text { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public MediaBox MediaBox { get; set; }
    public PdfText(int objectNumber, string text, float x, float y, MediaBox mediaBox) : base(objectNumber)
    {
      MediaBox = mediaBox;
      X = x;
      Y = PdfHelpers.ScreenPosition(y, mediaBox.Height);

      AddTextStream("F1", 18, X, Y, this.Text); // Table 5 PDF spec entries common to all stream dictionaries
    }

    public void AddTextStream(string font, int fontSize, float xPos, float yPos, string text)
    {
      var streamContent = $"BT\n /{font} {fontSize} Tf\n {xPos} {yPos} Td\n ({text}) Tj\nET";
      this.Stream = $"\nstream\n{streamContent}\nendstream";
      var length = Encoding.ASCII.GetByteCount(streamContent);
      Dictionary.Add("Length", length);
    }
  }
}
