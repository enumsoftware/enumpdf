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
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public MediaBox(int x, int y, int width, int height)
    {
      X = X;
      Y = y;
      Width = width;
      Height = height;
    }

    public override string ToString()
    {
      return $"[{X} {Y} {Width} {Height}]";
    }
  }
}
