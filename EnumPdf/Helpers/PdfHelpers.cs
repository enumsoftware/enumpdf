using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Helpers
{
  public class PdfHelpers
  {
    public static Encoding Encoding
    {
      get
      {
        return System.Text.Encoding.Default;
      }
    }

    public static float ScreenPosition(float value, float size)
    {
      return size - value;
    }
  }
}
