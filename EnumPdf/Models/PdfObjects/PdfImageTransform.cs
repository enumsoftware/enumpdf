using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using ExifLib;
using EnumPdf.Helpers;
using EnumPdf.Other;

namespace EnumPdf.Models
{
  public class PdfImageTransform : PdfObject
  {
    public string FileName { get; set; }

    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public string ImageName { get; set; }

    public PdfImageTransform(
      int objectNumber,
      string fileName,
      string imageName,
      float x,
      float y,
      float width,
      float height,
      MediaBox mediaBox) : base(objectNumber)
    {
      FileName = fileName;
      ImageName = imageName;
      Width = width;
      Height = height;
      X = x;
      Y = PdfHelpers.ScreenPosition(y, mediaBox.Height);

      AddImageStream();
    }

    private void AddImageStream()
    {
      // TABLE 4.7 Pdf Spec 1.4  4.3.3 Graphics state operators 
      // Example 4.23 1.4 Pdf Spec
      // https://www.tallcomponents.com/blog/pdf-graphics-basics-and-edit 
      // Rotation transformation matrix jsPDF example addImage.js line 364

      var translationMatrix = $"1 0 0 1 {X} {Y} cm";
      // var rotationMatrix = "1 1 1 -1 0 0 cm";
      var scaleMatrix = $"{Width} 0 0 {Height} 0 0 cm";

      // var translationMatrix = $"1 0 0 1 100 200 cm";
      // var rotationMatrix = "0.7 0.7 -0.7 0.7 0 0 cm";
      // var scaleMatrix = $"40 0 0 40 0 0 cm";

      var paintimage = $"{ImageName} Do";

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("q");
      sb.AppendLine(translationMatrix);
      // sb.AppendLine(rotationMatrix); // TODO: figure out how this works
      sb.AppendLine(scaleMatrix);
      sb.AppendLine(paintimage);
      sb.AppendLine("Q");

      var stream = sb.ToString();
      var count = PdfHelpers.Encoding.GetByteCount(stream);

      Dictionary["Length"] = count;
      Stream = $"\nstream\n{stream}\nendstream";
    }
  }
}
