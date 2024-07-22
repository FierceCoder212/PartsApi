using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PartsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PartsDb")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/AddParts", async (PartsDbContext dbContext, [FromBody] List<Part> parts) =>
{
    await dbContext.Parts.AddRangeAsync(parts);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
})
.WithName("AddPart")
.WithOpenApi();

app.Run();