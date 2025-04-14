using Microsoft.EntityFrameworkCore;
using PokeMudBlazor8.Models;
using SharedModels;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}