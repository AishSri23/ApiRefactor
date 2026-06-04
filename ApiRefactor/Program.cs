using ApiRefactor.Middleware;
using ApiRefactor.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
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
