using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfImage : PdfObject
  {
    public PdfImage(StreamReader streamReader) : base("XObject")
    {
      // Dictionary.Add("Kids", PdfArrayOfReferences());
      // Dictionary.Add("Kids", PdfArrayOfReferences());


      // var stream = Convert.ToBase64String(byteArr);
      // this.Stream = $"stream\n{stream}\nendstream";
    }

    private void AddImageStream(byte[] byteArr, int xPos, int yPos)
    {

    }

  }
}
