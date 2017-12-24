using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServer.Host.Models;

namespace IdentityServer.Host.Data
{
    public class PasswordHistoryDbContext : DbContext
    {
        public PasswordHistoryDbContext(DbContextOptions<PasswordHistoryDbContext> options) : base(options) { }
        public PasswordHistoryDbContext() { }

        public DbSet<PasswordHistory> PasswordHistory { get; set; }
    }
}
