using Microsoft.EntityFrameworkCore;
using Registration.Business.Mappers;
using Registration.Infrastructure.Data;
using Registration.Infrastructure.IRepositories;
using Registration.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("RegistrationConnString"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
