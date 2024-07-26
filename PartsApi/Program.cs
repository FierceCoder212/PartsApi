using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsApi;
using PartsApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PartsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PartsDb"), options => options.CommandTimeout(300)));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapPost("/AddParts", async (PartsDbContext dbContext, [FromBody] List<Part> parts) =>
{
    await dbContext.Parts.AddRangeAsync(parts);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
})
.WithName("AddPart")
.WithOpenApi();

app.MapPost("/TempAddParts", async (PartsDbContext dbContext, [FromBody] List<TempPart> parts) =>
{
    await dbContext.TempParts.AddRangeAsync(parts);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
})
.WithName("TempAddParts")
.WithOpenApi();

app.Run();
