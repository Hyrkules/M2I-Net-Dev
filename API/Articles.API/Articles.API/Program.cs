using Articles.API.MiddleWares;
using Articles.API.Repositories;
using Articles.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Articles",
        Version = "v1",
        Description = "Api de gestion des articles avec auth JWT"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Entrez votre token JWT. \nExemple : eyJHdfgdDSFDfd..."
    });

    options.AddSecurityRequirement(document =>
    {
        var requirements = new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
        };

        return requirements;
    });

    });

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IAuteurRepository, AuteurRepository>();


builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IAuteurService, AuteurService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var secretKey = builder.Configuration["jwtSettings:SecretKey"]
                ?? throw new InvalidOperationException("JWT Settings:SecretKey manque dans appSettings.json");

var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
 {
     options.RequireHttpsMetadata = false;

     options.SaveToken = true;

     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(key),

         ValidateIssuer = false,

         ValidateAudience = false,

         ClockSkew = TimeSpan.Zero,
     };
 });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Articles V1");
    });

    app.MapGet("/", () => Results.Redirect("/Swagger"));
}

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
