using Microsoft.EntityFrameworkCore;
using cheffy_dotnet.Repositories;
using cheffy_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RecipeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("localdb")));
builder.Services.AddScoped<IRecipeRepository, SQLRecipeRepository>();
builder.Services.AddScoped<RecipeService>();

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
