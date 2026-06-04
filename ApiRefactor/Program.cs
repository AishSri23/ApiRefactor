using ApiRefactor.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ApiRefactor.Repositories;
using ApiRefactor.Data;
using ApiRefactor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//Authentication and Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //ValidIssuer = "https://localhost:7038",
            //ValidAudience = "https://localhost:7038",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                                                    "ThisIsSecretKeyForCodingAssessmentOnRefactoringWebapi"))
        };


    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Write", policy =>
    {
        policy.RequireClaim(
            "scope",
            "write");
    });
});

//Exception Handling
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

//Database Context
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlite(@"Data Source=C:\Users\mukun\Downloads\ApiRefactor 7\ApiRefactor 6\ApiRefactor\App_Data\waves.db"));

//Repository
builder.Services.AddScoped<IWaveRepository, WaveRepository>();
//Services
builder.Services.AddScoped<WaveService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();

/*app.MapGet("/api/wave", () => new Waves())
    .WithName("GetWaves")
    .WithOpenApi();

app.MapGet("/api/wave/{id}", (Guid id) => new Wave(id))
    .WithName("GetWaveById")
    .WithOpenApi();

app.MapPost("/api/wave", (Wave wave) => { wave.Save(); })
    .WithName("UpsertWave")
    .WithOpenApi(); */

app.Run();
