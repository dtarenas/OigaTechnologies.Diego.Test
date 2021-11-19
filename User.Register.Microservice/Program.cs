using DAL.DatabaseContext;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<OigaDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("OigaTestDb"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("OigaTestDb"))));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
