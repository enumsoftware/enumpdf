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
    private List<string> keys = new List<string>();
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

    public PdfObject(string type)
    {
      this.type = type;
    }

    public PdfObject(string key, PdfObject obj)
    {
      AddObjectKey(key, obj);
    }

    public void AddKey(string key, string value)
    {
      keys.Add($"/{key} {value}");
    }

    // Reference in format of 5 0 R
    public string GetPdfReference()
    {
      return $"{objectNumber} {generation} R";
    }

    public void AddObjectKey(string key, PdfObject value)
    {
      var str = value.BuildObject().ToString();
      keys.Add($"/{key}\n{str}");
    }

    public void AddObjectReferenceKey(string key, PdfObject value)
    {
      keys.Add("/" + key + " " + value.GetPdfReference());
    }

    public void AddObjectReferenceArrayKey(string key, params PdfObject[] values)
    {
      string finalVal = "/" + key + " [";
      values.ToList().ForEach(m =>
      {
        finalVal = finalVal + m.GetPdfReference();
      });
      finalVal = finalVal + "]";
      keys.Add(finalVal);
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
      StringBuilder pdfObject = new StringBuilder();
      pdfObject.Append("<< ");
      if (type != null)
      {
        pdfObject.Append("/Type /").Append(type).Append("\n");
      }
      foreach (string key in keys)
      {
        pdfObject.Append("     ").Append(key).Append("\n");
      }
      pdfObject.Append("  >>");

      if (stream != null)
      {
        pdfObject.Append(stream);
      }

      return pdfObject;
    }

    public string DebugTxt()
    {
      return Build().ToString();
    }
  }
}
