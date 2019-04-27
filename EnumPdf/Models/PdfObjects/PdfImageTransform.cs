using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using ExifLib;
using EnumPdf.Helpers;

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
      // TABLE 4.7 Pdf Spec 1.4  4.3.3 Graphics state operators
      // https://www.tallcomponents.com/blog/pdf-graphics-basics-and-edit 
      // Rotation transformation matrix jsPDF example addImage.js line 364
      
      var stream = "0.57 w 0 G q 2.83 0 0 2.83 28.35 810.71 cm /I0 Do Q";
      var count = PdfHelpers.Encoding.GetByteCount(stream);
      Dictionary["Length"] = count;
      this.Stream = $"\nstream\n{stream}\nendstream";
    }
  }
}
