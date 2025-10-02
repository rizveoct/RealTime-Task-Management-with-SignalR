using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

public sealed class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Description)
            .HasMaxLength(2000);

        builder.HasMany(t => t.Comments)
            .WithOne()
            .HasForeignKey(c => c.TaskId);

        builder.HasMany(t => t.Attachments)
            .WithOne()
            .HasForeignKey(a => a.TaskId);

        builder.OwnsMany(t => t.Checklist, cb =>
        {
            cb.ToTable("ChecklistItems");
            cb.WithOwner().HasForeignKey("TaskId");
            cb.Property<Guid>("Id").ValueGeneratedNever();
            cb.HasKey("Id");
            cb.Property(c => c.Text).HasMaxLength(300);
        });

        builder.Ignore(t => t.Assignees);

        builder.Navigation(t => t.Comments).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(t => t.Attachments).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(t => t.Checklist).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
