using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) // Pass options to the base class
        {

        }

        public DbSet<Activity> /* The entity that we want to work with */ Activities /*Name of the Table*/ { get; set; } // DbSet is a collection of entities that can be queried from the database

    }

}