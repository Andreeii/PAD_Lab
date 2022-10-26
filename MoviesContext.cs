using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1
{
	public partial class MoviesContext : DbContext
	{
		public MoviesContext()
		{
		}

		public MoviesContext(DbContextOptions<MoviesContext> options)
		    : base(options)
		{
		}

		public virtual DbSet<Movie> Movies { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Movies;Integrated Security=True;Integrated Security=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>(entity =>
			{
				entity.ToTable("movie");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Director)
				 .HasMaxLength(50)
				 .HasColumnName("director");

				entity.Property(e => e.Stars).HasColumnName("stars");

				entity.Property(e => e.Title)
				 .HasMaxLength(50)
				 .HasColumnName("title");

				entity.Property(e => e.Year)
				 .HasMaxLength(50)
				 .IsUnicode(false)
				 .HasColumnName("year");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
