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

app.MapPost("/ResolveSpaces", async (PartsDbContext dbContext) =>
{
    int batchSize = 10000;
    int skip = 0;
    List<Part> parts;
    var totalCount = await dbContext.Parts
                               .Where(x => x.Description.Contains("  This part replaces"))
                               .OrderBy(x => x.Id)
                               .CountAsync();
    Console.WriteLine($"Total Count {totalCount}");
    do
    {
        parts = await dbContext.Parts
                               .Where(x => x.Description.Contains("  This part replaces"))
                               .OrderBy(x => x.Id)
                               .Skip(skip)
                               .Take(batchSize)
                               .ToListAsync();

        foreach (var part in parts)
        {
            part.Description = string.Join(' ', part.Description.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                                 .Select(x => x.Trim())
                                                                 .Where(x => !string.IsNullOrEmpty(x)));
        }

        dbContext.UpdateRange(parts);
        await dbContext.SaveChangesAsync();

        skip += batchSize;
        Console.WriteLine($"Total Processed {skip}");
    } while (parts.Count > 0);

    return Results.Ok();
})
.WithName("ResolveSpaces")
.WithOpenApi();

app.Run();
