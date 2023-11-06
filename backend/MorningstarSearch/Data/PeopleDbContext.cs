using Microsoft.EntityFrameworkCore;
using MorningstarSearch.Models;

namespace MorningstarSearch.Data;

public class PeopleDbContext : DbContext
{
    public DbSet<Person> Notes { get; set; }

    public PeopleDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}