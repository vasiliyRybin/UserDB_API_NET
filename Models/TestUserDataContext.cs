using Microsoft.EntityFrameworkCore;

namespace UserDB_API_NET.Models;

public partial class TestUserDataContext : DbContext
{
    public TestUserDataContext()
    {
    }

    public TestUserDataContext(DbContextOptions<TestUserDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=D:\\Coding Projects\\_Python\\DataToCSVFile\\TestUserData.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.TaxId);

            entity.HasIndex(e => e.Email, "IX_Email");

            entity.HasIndex(e => e.PassNumber, "IX_PassNumber");

            entity.HasIndex(e => e.TaxId, "IX_TaxID");

            entity.Property(e => e.TaxId).HasColumnName("TaxID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
