using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LumiNYC.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange
                (
                    new Product { Name = "NMD_R1 Shoes", Description = "All White", Category = "Running Shoes", Price = 130 },
                    new Product { Name = "OZWEEGO Shoes", Description = "All Black", Category = "Running Shoes", Price = 110 },
                    new Product { Name = "ULTRABOOST Shoes", Description = "All Black", Category = "Running Shoes", Price = 180 },
                    new Product { Name = "ALPHABOOST Shoes", Description = "All White", Category = "Running Shoes", Price = 150 },
                    new Product { Name = "U_PATH RUN Shoes", Description = "All Black", Category = "Running Shoes", Price = 85 },
                    new Product { Name = "STREETBALL", Description = "White,Black, and Grey", Category = "Running Shoes", Price = 110 },
                    new Product { Name = "Zoom Pegasus Turbo 2", Description = "All Grey", Category = "Running Shoes", Price = 180 },
                    new Product { Name = "React Sertu", Description = "Tan and White", Category = "Running Shoes", Price = 150 },
                    new Product { Name = "Air Max 270 React", Description = "Pop Art", Category = "Running Shoes", Price = 150 },
                    new Product { Name = "Rodeo Drive Crew Neck", Description = "White", Category = "Graphic Tee", Price = 30 },
                    new Product { Name = "Blueface Yeah Aight", Description = "White", Category = "Graphic Tee", Price = 25 },
                    new Product { Name = "Blessed Oversized Puff", Description = "White", Category = "Graphic Tee", Price = 22 },
                    new Product { Name = "Pray For Me", Description = "Black", Category = "Graphic Tee", Price = 20 },
                    new Product { Name = "Basquiat Short Sleeve", Description = "Grey", Category = "Graphic Tee", Price = 22 },
                    new Product { Name = "Future Tie Dye", Description = "White", Category = "Graphic Tee", Price = 45 },
                    new Product { Name = "Herlo Denim", Description = "Black", Category = "Jeans", Price = 50 },
                    new Product { Name = "Tyrelle Motto", Description = "Blue", Category = "Jeans", Price = 50 },
                    new Product { Name = "Bands Skinny", Description = "Light Blue", Category = "Jeans", Price = 40 },
                    new Product { Name = "Atmosphere Skinny", Description = "Dark Blue", Category = "Jeans", Price = 35 },
                    new Product { Name = "No Pressure Skinny", Description = "Light Blue", Category = "Jeans", Price = 50 },
                    new Product { Name = "Distressed Zebra", Description = "White", Category = "Jeans", Price = 50 }
                );
                context.SaveChanges();
            }
        }
    }
}