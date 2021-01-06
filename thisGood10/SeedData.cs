using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models;
using static System.Net.Mime.MediaTypeNames;

namespace thisGood10
{
    public class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Sketches.Any())
            {


                string iFile1 = @"F:\WebC#\thisGood10\thisGood10\wwwroot\images\sk4\11.jpg";
                string iFile2 = @"F:\WebC#\thisGood10\thisGood10\wwwroot\images\sk4\18.jpg";
                string iFile3 = @"F:\WebC#\thisGood10\thisGood10\wwwroot\images\sk4\28.png";

                string base64_1 = Convert.ToBase64String(File.ReadAllBytes(iFile1));
                string base64_2 = Convert.ToBase64String(File.ReadAllBytes(iFile2));
                string base64_3 = Convert.ToBase64String(File.ReadAllBytes(iFile3));


                context.Sketches.AddRange(
                new Sketch
                {
                    sketchPrint = base64_1,
                    categoryName = "Textile",
                    sketchPrintName = "Меняю на BMW"

                },
                new Sketch
                {
                    sketchPrint = base64_2,
                    categoryName = "Textile",
                    sketchPrintName = "Я как все"


                },
                new Sketch
                {
                    sketchPrint = base64_3,
                    categoryName = "Mugs",
                    sketchPrintName = "Pikachu"


                });
                context.SaveChanges();
            }
        }

       
    }
}
