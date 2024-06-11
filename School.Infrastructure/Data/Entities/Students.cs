using System.ComponentModel.DataAnnotations;

public class Students
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string ClassName { get; set; }
    public bool isPass { get; set; }
}