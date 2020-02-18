using EntityFrameworkPracticeBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPracticeBlog
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var testuser = new User
            {
                Id = "abc123",
                FirstName = "Luke",
                LastName = "Skywalker"
            };

            builder.Entity<User>().HasData(testuser);

            builder.Entity<Post>().HasData(new Post
            {
                Id = "def234",
                UserId = testuser.Id,
                Content = "What a piece of junk!"
            });
        }
    }
}