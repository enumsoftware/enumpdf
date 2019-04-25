using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using EnumPdf.Extensions;
using EnumPdf.Helpers;

namespace EnumPdf.Models
{
  public class PdfMetadata : PdfObject
  {
    public string Title { get; set; }
    public string Author { get; set; }
    public string Subject { get; set; }
    public string Keywords { get; set; }
    public string Creator { get; set; }
    public string Producer { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModDate { get; set; }
    
    public PdfMetadata(
      string title,
      string author,
      string subject,
      string keywords,
      string creator,
      DateTime creationDate,
      DateTime modDate)
    {
      Title = title;
      Author = author;
      Subject = subject;
      Keywords = keywords;
      Creator = creator;
      CreationDate = CreationDate;
      ModDate = ModDate;

      var version = "1.0.0"; // TODO: read version from csproj or something
      Producer = $"EnumPdf Version:{version}";

      Dictionary.Add(nameof(Title), $"({Title})");
      Dictionary.Add(nameof(Author), $"({Author})");
      Dictionary.Add(nameof(Subject), $"({Subject})");
      Dictionary.Add(nameof(Keywords), $"({Keywords})");
      Dictionary.Add(nameof(Creator), $"({Creator})");
      Dictionary.Add(nameof(Producer), $"({Producer})");
      Dictionary.Add(nameof(CreationDate), $"({CreationDate.ToAsnDate()})");
      Dictionary.Add(nameof(ModDate), $"({ModDate.ToAsnDate()})");
    }

    public void UpdateObjectNumber(int objectNumber)
    {
      this.ObjectNumber = objectNumber;
    }
  }
}
