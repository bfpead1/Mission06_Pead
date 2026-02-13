using Microsoft.EntityFrameworkCore;
using Mission06_Pead.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
    if (!db.Categories.Any())
    {
        db.Categories.AddRange(
            new Mission06_Pead.Models.Category { CategoryId = 1, Name = "Action" },
            new Mission06_Pead.Models.Category { CategoryId = 2, Name = "Comedy" },
            new Mission06_Pead.Models.Category { CategoryId = 3, Name = "Drama" },
            new Mission06_Pead.Models.Category { CategoryId = 4, Name = "Horror" },
            new Mission06_Pead.Models.Category { CategoryId = 5, Name = "Sci-Fi" });
        db.SaveChanges();
    }
    if (!db.Movies.Any())
    {
        db.Movies.AddRange(
            new Mission06_Pead.Models.Movie { CategoryId = 2, Title = "The Shawshank Redemption", Year = 1994, Director = "Frank Darabont", Rating = "R", Edited = false },
            new Mission06_Pead.Models.Movie { CategoryId = 3, Title = "Spirited Away", Year = 2001, Director = "Hayao Miyazaki", Rating = "PG", Edited = false },
            new Mission06_Pead.Models.Movie { CategoryId = 5, Title = "The Matrix", Year = 1999, Director = "Lana Wachowski, Lilly Wachowski", Rating = "R", Edited = false });
        db.SaveChanges();
    }
}

app.Run();
