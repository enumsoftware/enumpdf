using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Extensions
{
  public static class PdfExtensions
  {
    public static void FromAsnDate(this DateTime time, string asnDate)
    {
      throw new NotImplementedException();
    }

    // TODO: Double check this write tests
    // 7.9.4 PDF Spec 
    // (D:YYYYMMDDHHmmSSOHH'mm')
    // (D:20190425004039+02'00')
    public static string ToAsnDate(this DateTime time)
    {
      string start = time.ToUniversalTime().ToString("yyyyMMddHHmmss");
      return $"D:{start}Z";
    }
  }
}
