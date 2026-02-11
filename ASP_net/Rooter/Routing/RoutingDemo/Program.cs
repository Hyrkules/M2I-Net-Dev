var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// Route personnalisée
app.MapControllerRoute(
    name: "blog",
    pattern: "blog/{year:int}/{month:int}/{slug}",
    defaults: new { controller = "Blog", action = "Article" }
    );

//  /nouveautes/{year}/{month}
app.MapControllerRoute(
    name: "book",
    pattern: "book/nouveautes/{year:int}/{month:int}",
    defaults: new { controller = "Book", action = "Nouveautes" }
    );

app.MapControllerRoute(
    name: "book",
    pattern: "Book/{action=Genre}/{genre?}",
    defaults: new { controller = "Book", action = "Genre" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
