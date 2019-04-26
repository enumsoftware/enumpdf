using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using ExifLib;

namespace EnumPdf.Models
{
  // PDF Image - Example 209 page of documentation
  // XObject Do Operator table 87
  public class PdfImage : PdfObject
  {
    public string FileName { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public PdfImage(int objectNumber, string fileName, int width, int height) : base(objectNumber,"XObject")
    {
      this.FileName = fileName;

      Dictionary["Subtype"] = "/Image";
      Dictionary["Height"] = height;
      Dictionary["Width"] = width;
      Dictionary["ColorSpace"] = "/DeviceRGB";
      Dictionary["BitsPerComponent"] = 8;
      Dictionary["Filter"] = "/DCTDecode";

      this.AddImageStream();
    }

    private void AddImageStream()
    {
      var bytes = File.ReadAllBytes(this.FileName);
      Dictionary["Length"] = bytes.Length;
      var str = Encoding.Default.GetString(bytes);
      this.Stream = $"\nstream\n{str}\nendstream";
    }

    private void ReadExifInfo()
    {
      Dictionary["Height"] = ReadTag<int>(ExifTags.YResolution);
      Dictionary["Width"] = ReadTag<int>(ExifTags.XResolution);
      Dictionary["ColorSpace"] = ReadTag<string>(ExifTags.ColorSpace);
      Dictionary["BitsPerComponent"] = ReadTag<int>(ExifTags.BitsPerSample);
      Dictionary["Length"] = ReadTag<int>(ExifTags.ImageLength);
      Dictionary["Filter"] = "/DCTDecode";
    }

    private T ReadTag<T>(ExifTags tag)
    {
      var stream = File.OpenRead(this.FileName);
      using (ExifReader reader = new ExifReader(stream))
      {
        T temp;
        if (reader.GetTagValue<T>(tag, out temp))
        {
          return temp;
        }
        return default(T);
      }
    }
  }
}
