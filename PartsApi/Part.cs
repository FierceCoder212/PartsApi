using System.ComponentModel.DataAnnotations;

namespace PartsApi;

public class Part
{
    [Key]
    public int Id { get; set; }
    public string? SglUniqueModelCode { get; set; }
    public string? Section {  get; set; }
    public string? PartNumber { get; set; }
    public string? ItemNumber { get; set; }
    public string? Description { get; set; }
    public string? SectonDiagram { get; set; }
}
