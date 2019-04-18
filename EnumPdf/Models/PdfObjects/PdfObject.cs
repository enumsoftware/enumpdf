using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfObject
  {
    public int ObjectNumber { get; }
    static int count = 1;
    public string Stream { get; set; }
    private string Type { get; set; }
    private int Generation { get; set; } = 0;
    public Dictionary<string, object> Dictionary { get; set; } = new Dictionary<string, object>();

    public PdfObject()
    {
      ObjectNumber = count++;
    }

    public PdfObject(string type) : this()
    {
      this.Type = type;
      this.Dictionary.Add("Type", type);
    }

    // Reference in format of 5 0 R
    public string PdfReference()
    {
      return $"{ObjectNumber} {Generation} R";
    }

    public string CrossSectionReference()
    {
      return $"{ObjectNumber} {Generation} obj";
    }

    public void AddTextStream(string font, int fontSize, int xPos, int yPos, string text)
    {
      var streamContent = $"BT\n /{font} {fontSize} Tf\n {xPos} {yPos} Td\n ({text}) Tj\nET";
      this.Stream = $"\nstream\n{streamContent}\nendstream";
      var length = Encoding.ASCII.GetByteCount(streamContent);
      Dictionary.Add("Lenght", length);
    }


    public override string ToString()
    {
      return Build().ToString();
    }

    public virtual StringBuilder Build()
    {
      StringBuilder pdfObject = new StringBuilder();
      pdfObject
        .Append($"{ObjectNumber} {Generation} obj\n")
        .Append(BuildObject())
        .Append("\nendobj\n\n");

      return pdfObject;
    }

    public virtual StringBuilder BuildObject()
    {
      var TWO_SPACES = "  ";
      StringBuilder sb = new StringBuilder();
      sb.Append("<<\n");
      Dictionary.ToList().ForEach(keyValue =>
      {
        sb.Append(TWO_SPACES).Append($"/{keyValue.Key} {keyValue.Value.ToString()}\n");
      });
      sb.Append(">>");

      if (Stream != null)
      {
        sb.Append(Stream);
      }
      return sb;
    }
  }
}
