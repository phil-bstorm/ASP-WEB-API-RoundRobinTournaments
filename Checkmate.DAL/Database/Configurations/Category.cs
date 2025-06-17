using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Checkmate.Domain.Models;

namespace Checkmate.DAL.Database.Configurations
{
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories");

			// COLUMNS
			builder.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.MinAge)
				.HasColumnName("min_age")
				.IsRequired();

			builder.Property(x => x.MaxAge)
				.HasColumnName("max_age")
				.IsRequired();

			// CONSTRAINTS
			builder.HasKey(x => x.Id);

			// RELATIONSHIPS

			// MM_Tournament_category is in the TournamentConfig
		}
	}
}
