using lilgobguides.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lilgobguides.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
                                    : IdentityDbContext(options)
{
    public DbSet<Post> Posts { get; set; }
}
