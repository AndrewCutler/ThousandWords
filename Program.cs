using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();
builder.Services.AddSingleton<IConfiguration>(configBuilder);

var app = builder.Build();

// Add serilog

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
