using CompanySubmission.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CompanySubmission.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CompanyInfo> Companies { get; set; }
    }
}
