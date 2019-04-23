// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Text;
// using EnumPdf.Models;
// using EnumPdf.Cmd;

// namespace EnumPdf.Cmd.Examples
// {
//   public class ImageExample
//   {
//     public static void Create()
//     {
//       var mediaBox = new MediaBox(0, 0, 200, 200);
//       PdfFont font = new PdfFont("Times-Roman");
//       PdfImage image = new PdfImage("images/image.jpg", 100, 100, 40, 40);

//       var pages = new PdfPages();
//       var page = new PdfPage(pages, mediaBox);
//       page.AddContent(image);
//       pages.AddPage(page);

//       PdfCatalog catalog = new PdfCatalog(pages);

//       Pdf pdf = new Pdf(
//         catalog,
//         pages,
//         page,
//         font,
//         image);

//       Helpers.WriteFiles(pdf, nameof(ImageExample));
//     }
//   }
// }
