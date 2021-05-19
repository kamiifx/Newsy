using System;
using Microsoft.EntityFrameworkCore;
using Newsy.Model;

namespace Newsy.Data
{
    public class NewsyDbContex : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }

        public NewsyDbContex(DbContextOptions<NewsyDbContex> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFavorite>()
                .HasOne(u => u.User)
                .WithMany(uf => uf.UserFavorites)
                .HasForeignKey(ui => ui.UserId);

            modelBuilder.Entity<UserFavorite>()
                .HasOne(f => f.Favorite)
                .WithMany(fa => fa.UserFavorites)
                .HasForeignKey(fi => fi.FavoriteId);
        }
    }
}
