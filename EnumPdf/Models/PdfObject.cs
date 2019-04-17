using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfObject
  {
    private string type;
    private int objectNumber;
    private int generation;
    // private List<string> keys = new List<string>();
    private Dictionary<string, object> dictionary = new Dictionary<string, object>();

    private string stream;

    public PdfObject(int objectNumber, int generation, string type)
    {
      this.type = type;
      this.objectNumber = objectNumber;
      this.generation = generation;
    }

    public PdfObject(int objectNumber, int generation)
    {
      this.objectNumber = objectNumber;
      this.generation = generation;
    }

    public PdfObject()
    {
    }

    public PdfObject(string type)
    {
      this.type = type;
      this.dictionary.Add("Type", type);
    }

    public void AddKey(string key, object value)
    {
      dictionary.Add(key, value);
    }

    // Reference in format of 5 0 R
    public string PdfObjectReference()
    {
      return $"{objectNumber} {generation} R";
    }

    public void AddTextStream(string font, int fontSize, int xPos, int yPos, string text)
    {
      this.stream = $@"
stream 
BT 
  /{font} {fontSize} Tf 
  {xPos} {yPos} Td
  ({text}) Tj
ET
endstream
      ";
    }

    public void AddImageStream(byte[] byteArr, int xPos, int yPos)
    {
      var stream = Convert.ToBase64String(byteArr);
      this.stream = $@"
stream 
{stream}
endstream
      ";
    }

    public override string ToString()
    {
      return Build().ToString();
    }

    public StringBuilder Build()
    {
      StringBuilder pdfObject = new StringBuilder();
      pdfObject
        .Append(objectNumber)
        .Append(" ")
        .Append(generation)
        .Append(" obj\n  ")
        .Append(BuildObject())
        .Append("\nendobj\n\n");

      return pdfObject;
    }

    public StringBuilder BuildObject()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<<");
      dictionary.ToList().ForEach(keyValue =>
      {
        var key = keyValue.Key;
        var value = keyValue.Key;
        sb.Append($"/{key}{value}\n");
      });
      sb.Append(">>");

      if (stream != null)
      {
        sb.Append(stream);
      }
      return sb;
    }
  }
}
