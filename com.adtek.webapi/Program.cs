using com.adtek.br.Configuration;
using com.adtek.br.Models;
using com.adtek.br.Repository;
using com.adtek.br.Services;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddTransient(typeof(ContenidoRepository));


builder.Services.AddTransient(typeof(UsuarioService));
builder.Services.AddTransient(typeof(UsuarioRepository));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
