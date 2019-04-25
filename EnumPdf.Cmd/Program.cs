using System;
using System.IO;
using System.Text;
using EnumPdf.Cmd.Examples;
using EnumPdf.Models;

namespace EnumPdf.Cmd
{
  public class Program
  {
    static void Main(string[] args)
    {
      // BasicExample.Create();
      // MultiplePagesExample.Create();
      // MultipleTextObjectsExample.Create();
      // ImageExample.Create();

      MetadataExample.Create();
    }
  }
}
