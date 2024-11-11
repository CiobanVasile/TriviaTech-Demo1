using TriviaTech.Components.domain;
using Microsoft.EntityFrameworkCore;
namespace TriviaTech.Components.repository;

public class YourAppDbContext : DbContext
{
    public YourAppDbContext(DbContextOptions<YourAppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<UserGame> UserGames { get; set; }
    public DbSet<GameQuestion> GameQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserGame>()
            .HasKey(ug => new { ug.UserId, ug.GameId });

        modelBuilder.Entity<GameQuestion>()
            .HasKey(gq => new { gq.GameId, gq.QuestionId });
    }
}