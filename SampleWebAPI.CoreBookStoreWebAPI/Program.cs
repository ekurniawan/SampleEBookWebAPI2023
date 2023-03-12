using Microsoft.EntityFrameworkCore;
using SampleWebAPI.CoreBookStoreWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));

//konfigurasi EF
//menambahkan sensitive logging
builder.Services.AddDbContext<PubContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},
    LogLevel.Information));

//menambahkan DI
builder.Services.AddScoped<IAuthor, AuthorDAL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

