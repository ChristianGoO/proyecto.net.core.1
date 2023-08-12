using com.adtek.br.Configuration;
using com.adtek.br.Models;
using com.adtek.br.Repository;
using com.adtek.br.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowSpecificOrigins = "myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7032").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<AdtekDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), builder =>
{
    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10),null);
}));

builder.Services.AddTransient(typeof(AdtekConfigManager));
builder.Services.AddTransient(typeof(TodoItemService));
builder.Services.AddTransient(typeof(TodoItemRepository));
builder.Services.AddTransient(typeof(MailService));

builder.Services.AddTransient(typeof(TokenService));
builder.Services.AddTransient(typeof(ContenidoRepository));
builder.Services.AddTransient(typeof(UsuarioService));
builder.Services.AddTransient(typeof(UsuarioRepository));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
