using Microsoft.EntityFrameworkCore;
using TriviaTech.Components.domain;
using TriviaTech.Components.repository;

namespace TriviaTech;

public class Main
{
      static async Task Mai2n(string[] args)
    {
        // Setup a Host for Dependency Injection
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Configure DbContext with PostgreSQL
                services.AddDbContext<YourAppDbContext>(options =>
                    options.UseNpgsql("Host=your_host;Port=5432;Database=your_database;Username=your_username;Password=your_password"));

                // Register repositories
                services.AddScoped<IRepository<User>, UserRepository>();
                services.AddScoped<IRepository<Game>, GameRepository>();
            })
            .Build();

        // Run the test logic in the scoped DI context
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            await TestAddEntitiesAsync(services);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    private static async Task TestAddEntitiesAsync(IServiceProvider services)
    {
        // Get the UserRepository and GameRepository from DI
        var userRepository = services.GetRequiredService<IRepository<User>>();
        var gameRepository = services.GetRequiredService<IRepository<Game>>();

        // Create and add a User
        var user = new User { Username = "test_user", Password = "securepassword" };
        await userRepository.AddAsync(user);
        Console.WriteLine("User added.");

        // Create and add a Game
        var game = new Game { Difficulty = DifficultyLevel.Easy };
        await gameRepository.AddAsync(game);
        Console.WriteLine("Game added.");

        // Verify that entities are saved in the database
        var savedUser = await userRepository.GetByIdAsync(user.Id);
        var savedGame = await gameRepository.GetByIdAsync(game.Id);

        if (savedUser != null && savedGame != null)
        {
            Console.WriteLine($"User '{savedUser.Username}' and Game with Difficulty '{savedGame.Difficulty}' added successfully.");
        }
        else
        {
            Console.WriteLine("Failed to add entities.");
        }
    }
}