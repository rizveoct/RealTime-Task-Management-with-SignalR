using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.HasMany(p => p.Boards)
            .WithOne()
            .HasForeignKey(b => b.ProjectId);

        builder.Navigation(p => p.Boards).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Ignore(p => p.Members);
    }
}
