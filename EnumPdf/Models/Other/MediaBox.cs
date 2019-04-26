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
  public class MediaBox
  {
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    public MediaBox(float x, float y, float width, float height)
    {
      X = X;
      Y = y;
      Width = width;
      Height = height;
    }

    public override string ToString()
    {
      return $"[ {X} {Y} {Width} {Height} ]";
    }
  }
}
