using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions):base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(m =>
            {
                m.HasOne(o => o.Producer).WithMany(m => m.Movies).HasForeignKey(f => f.ProducerId);
                m.HasOne(o => o.Cinema).WithMany(m => m.Movies).HasForeignKey(f => f.CinemaId);
                
            });

            modelBuilder.Entity<ActorMovie>(m => {
                m.HasKey(k => new
                {
                    k.MovieId,
                    k.ActorId
                });
                m.HasOne(o => o.Movie).WithMany(m => m.ActorMovies).HasForeignKey(f => f.MovieId);
                m.HasOne(o => o.Actor).WithMany(m => m.ActorMovies).HasForeignKey(f => f.ActorId);

            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
