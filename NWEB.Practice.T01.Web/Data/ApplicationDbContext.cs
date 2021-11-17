using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NWEB.Practice.T01.Web.Models;

namespace NWEB.Practice.T01.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flower>()
            .HasOne<Category>(f => f.Categories)
            .WithMany(c => c.Flowers)
            .HasForeignKey(f => f.CategoryId);
        }

        public DbSet<NWEB.Practice.T01.Web.Models.CategoryVM> CategoryVM { get; set; }

        public DbSet<NWEB.Practice.T01.Web.Models.FlowerVM> FlowerVM { get; set; }
    }
}
