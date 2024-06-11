using System.ComponentModel.DataAnnotations;

public class Scores
{
    [Key]
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string Name { get; set; }
    public decimal Point { get; set; }
    public bool isPass { get; set; }
}
