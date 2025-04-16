using Microsoft.EntityFrameworkCore;

namespace simple_social_board_server.Data
{
    public class MainDbContext : DbContext
    {
        //Constructor that accepts DbContextOptions and passes it to the base class
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options){}


        // Add other DbSet properties for your entities here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints here
            // Example:
            // modelBuilder.Entity<User>()
            //     .HasMany(u => u.Posts)
            //     .WithOne(p => p.User)
            //     .HasForeignKey(p => p.UserId);
        }
    }
}