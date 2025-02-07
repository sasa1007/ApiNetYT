using Api.Data;
using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 3;
}).AddEntityFrameworkStores<AplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
                options.DefaultScheme =
                    options.DefaultSignInScheme =
                        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SignigKey"]))
    };
});

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "My API V1"); });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();