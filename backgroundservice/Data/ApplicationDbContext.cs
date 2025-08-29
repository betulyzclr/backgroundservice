using backgroundservice.Models;
using Microsoft.EntityFrameworkCore;

namespace backgroundservice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 'Jobs' adında bir DbSet oluşturuyoruz.
        // Bu, veritabanındaki 'Jobs' tablosuna erişmek için kullanılacak.
        public DbSet<JobViewModel> Jobs { get; set; }
    }
}