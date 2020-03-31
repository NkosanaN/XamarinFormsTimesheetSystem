using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using App3.Helpers;

namespace App3.Views.Mock
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pdf : ContentPage
    {
        //private string root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        public Pdf()
        {
            InitializeComponent();
        }


		private async void generatePDF(object sender, EventArgs e)
        {            
            // Granted storage permission
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
                storageStatus = results[Permission.Storage];
            }
            string date = DateTime.Now.ToShortDateString();
            date = date.Replace("/", "_");
            var path = DependencyService.Get<IExportFilesToLocation>().GetFolderLocation() + "chilimobile" + date + ".pdf";
            /* Path.Combine(root, $"{Guid.NewGuid().ToString("N")}.pdf");*/

            var metadata = new SKDocumentPdfMetadata
            {
                Author = "Cool Developer",
                Creation = DateTime.Now,
                Creator = "Cool Developer Library",
                Keywords = "SkiaSharp, Sample, PDF, Developer, Library",
                Modified = DateTime.Now,
                Producer = "SkiaSharp",
                Subject = "SkiaSharp Sample PDF",
                Title = "Sample PDF",
            };

            using (var stream = new SKFileWStream(path)) 
            using (var document = SKDocument.CreatePdf(stream, metadata))
            using (var paint = new SKPaint())
            {
                paint.TextSize = 64.0f;
                paint.IsAntialias = true;
                paint.Color = (SKColor)0xFF9CAFB7;
                paint.IsStroke = true;
                paint.StrokeWidth = 3;
                paint.TextAlign = SKTextAlign.Left;

                var width = 840;
                var height = 1188;

                // draw page 1
                using (var pdfCanvas = document.BeginPage(width, height))
                {
                    // draw button
                    var nextPagePaint = new SKPaint
                    {
                        IsAntialias = true,
                        TextSize = 16,
                        Color = SKColors.OrangeRed
                    };
                    var nextText = "Next Page >>";
                    var btn = new SKRect(width - nextPagePaint.MeasureText(nextText) - 24, 0, width, nextPagePaint.TextSize + 24);
                    pdfCanvas.DrawText(nextText, btn.Left + 12, btn.Bottom - 12, nextPagePaint);
                    // make button link
                    pdfCanvas.DrawLinkDestinationAnnotation(btn, "next-page");

                    // draw contents
                    pdfCanvas.DrawText("Invoice ", width / 2, 50, paint);
                    pdfCanvas.DrawText("To", width / 2, 100, paint);
                    pdfCanvas.DrawText("Peter Smith", width / 2, 150, paint);
                    pdfCanvas.DrawText("89 Summer Street", width / 2, 200, paint);
                    //pdfCanvas.DrawText("Sandton \n", width / 2, height / 4, paint);
                    //pdfCanvas.DrawText("Tel: 012 987 6543 \n", width / 2, height / 4, paint);
                    //pdfCanvas.DrawText("Email: Nushca@datasaint.com \n", width / 2, height / 4, paint);
                    document.EndPage();
                }
                //// draw page 2
                //using (var pdfCanvas = document.BeginPage(width, height))
                //{
                //    // draw link destintion
                //    pdfCanvas.DrawNamedDestinationAnnotation(SKPoint.Empty, "next-page");

                //    // draw contents
                //    pdfCanvas.DrawText("...PDF 2/2...", width / 2, height / 4, paint);
                //    document.EndPage();
                //}

                // end the doc
                document.Close();
            }
            //SkiaSharp.SKDocument.CreatePdf(path, 12.0f);

            //FileStream myDir = new FileStream(root, FileMode.CreateNew);
            //StreamReader r = new StreamReader(myDir);



            // display to the user
            //SkiaSharpSample.OnOpenFile(path);
        }
    }
}