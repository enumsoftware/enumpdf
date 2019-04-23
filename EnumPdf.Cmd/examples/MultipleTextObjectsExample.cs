// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Text;
// using EnumPdf.Models;
// using EnumPdf.Cmd;

// namespace EnumPdf.Cmd.Examples
// {
//   public class MultipleTextObjectsExample
//   {
//     public static void Create()
//     {
//       var mediaBox = new MediaBox(0, 0, 200, 200);
//       PdfFont font = new PdfFont("Times-Roman");
//       PdfText text1 = new PdfText("Hello World!", 10, 50);
//       PdfText text2 = new PdfText("Hello World!", 10, 100);

//       var pages = new PdfPages();
//       var page = new PdfPage(pages, mediaBox);
//       page.AddContent(text1);
//       page.AddContent(text2);
//       pages.AddPage(page);

//       PdfCatalog catalog = new PdfCatalog(pages);

//       Pdf pdf = new Pdf(
//         catalog,
//         pages,
//         page,
//         font,
//         text1,
//         text2);

//       Helpers.WriteFiles(pdf, nameof(MultipleTextObjectsExample));
//     }
//   }
// }
