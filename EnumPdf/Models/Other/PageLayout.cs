using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumPdf.Models
{
  // PageLayout
  // TA in PDF manual
  public enum PageLayout
  {
    SinglePage,
    OneColumn,
    TwoColumnLeft,
    TwoColumnRight,
    TwoPageLeft,
    TwoPageRight
  }
}
