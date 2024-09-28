using System.ComponentModel.DataAnnotations;

public class Word
{
    public int Id { get; set; }
    [StringLength(16)]
    public required string Text { get; set; }
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }
}
