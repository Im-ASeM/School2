using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{
    public DbSet<Scores> ScoresTbl { get; set; }
    public DbSet<Students> StudentsTbl { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.\\SQL2019;database=School2;trusted_connection=true;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }
}