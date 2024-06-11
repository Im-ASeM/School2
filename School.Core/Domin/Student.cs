public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string ClassName { get; set; }
    public bool isPass {
        get
        {
            int counte = 0;
            foreach (Score item in Score)
            {
                if (!item.isPass) { counte++; }
            }
            return counte > 3 ? false : true;
        }
    }
    public decimal avreage
    {
        get
        {
            decimal counte = 0;
            foreach (Score item in Score)
            {
                counte += item.Point;
            }
            return Math.Truncate(counte / Score.Count *100) / 100;
        }
    }
    public List<Score> Score { get; set; }
}
