using labb3_Blazor.Components;
using labb3_Blazor.Services;
using labb3_Blazor.Data;
using labb3_Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace labb3_Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Razor components
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Lägg till HttpClient med bas-URL
            var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

            // Lägg till ApiService
            builder.Services.AddScoped<ApiService>();

            // Lägg till EF Core och AppDbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // ✅ Skapa databasen och lägg till testdata
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();

                if (!db.Certificates.Any())
                {
                    db.Certificates.AddRange(new[]
                    {
                        new Certificate
                        {
                            Title = "AZ-900",
                            Status = "Klar",
                            DateAchieved = DateTime.Now.AddMonths(-1),
                            CredentialUrl = "",
                            ImageUrl = ""
                        },
                        new Certificate
                        {
                            Title = "SC-900",
                            Status = "Pågående",
                            ImageUrl = ""
                        }
                    });

                    db.Tech.Add(new Technology
                    {
                        Name = "Docker",
                        SkillLevel = "Medel",
                        YearsOfExperience = 1,
                        ImageUrl = ""
                    });

                    db.Experiences.Add(new Experience
                    {
                        Company = "Didup AB",
                        Role = "Cloud Intern",
                        Date = "2025-04 - Pågående",
                        ImageUrl = ""
                    });

                    db.SaveChanges();
                }
            }

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
