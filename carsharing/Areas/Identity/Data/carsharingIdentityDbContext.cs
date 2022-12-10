using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace carsharing.Areas.Identity.Data;

public class carsharingIdentityDbContext : IdentityDbContext<User>
{
    public carsharingIdentityDbContext(DbContextOptions<carsharingIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
