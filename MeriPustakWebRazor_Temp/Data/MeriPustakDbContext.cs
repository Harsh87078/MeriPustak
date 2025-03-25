using MeriPustakWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeriPustakWebRazor_Temp.Data
{
    public class MeriPustakDbContext : DbContext
    {
        public MeriPustakDbContext(DbContextOptions<MeriPustakDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Fiction",
                    DiasplayOrder = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Non-Fiction",
                    DiasplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Name = "Science",
                    DiasplayOrder = 3
                },
                new Category
                {
                    Id = 4,
                    Name = "Mathematics",
                    DiasplayOrder = 4
                }
            );
        }
    }
}
