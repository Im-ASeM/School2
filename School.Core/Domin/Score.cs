public class Score
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string Name { get; set; }
    public decimal Point { get; set; }
    public bool isPass
    {
        get
        {
            return Point>12 ? true : false;
        }
    }
}