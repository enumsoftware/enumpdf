using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  public class PdfText : PdfObject
  {
    public string Text { get; set; }
    public PdfText(string text, int x, int y)
    {
      this.Text = text;
      this.AddTextStream("F1", 18, x, y, this.Text); // Table 5 PDF spec entries common to all stream dictionaries
    }
  }
}
