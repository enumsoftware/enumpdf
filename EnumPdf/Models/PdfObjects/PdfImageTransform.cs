using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using ExifLib;

namespace EnumPdf.Models
{
  public class PdfImageTransform : PdfObject
  {
    public string FileName { get; set; }


    public PdfImageTransform(int objectNumber, string fileName) : base(objectNumber)
    {
      this.FileName = fileName;
      this.AddImageStream();
    }

    private void AddImageStream()
    {
      var stream = "0.57 w\n0 G\nq 113.39 0 0 113.39 42.52 615.12 cm /I0 Do Q";
      Dictionary["Length"] = stream.Length;
      this.Stream = $"\nstream\n{stream}\nendstream";
    }
  }
}
