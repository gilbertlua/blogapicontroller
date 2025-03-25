using blogapicontroller.Models;
using Microsoft.EntityFrameworkCore;
namespace blogapicontroller.Data;

public class BlogApiContext: DbContext
{
    public BlogApiContext(DbContextOptions<BlogApiContext> options)
        : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<ActivityLog> ActivityLogs { get; set; }
}