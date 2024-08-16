using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;




namespace TicketSystemTask.Services
{
    public class TicketImage 
    {

        public async Task<string> ConvertHtmlToImageAsync(string htmlContent, string fileName)
        {
           
            var imagesFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            Directory.CreateDirectory(imagesFolderPath);

            var filePath = Path.Combine(imagesFolderPath, $"{fileName}.jpg");

            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            using var page = await browser.NewPageAsync();
            await page.SetContentAsync(htmlContent);
            await page.ScreenshotAsync(filePath, new ScreenshotOptions
            {
                Type = ScreenshotType.Jpeg,
                Quality = 80,
                FullPage = true
            });

            return $"/Images/{fileName}.jpg";
        }
    }
}
