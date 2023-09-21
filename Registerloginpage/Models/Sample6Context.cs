using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registerloginpage.Models;

namespace Registerloginpage.Models;

public partial class Sample6Context : IdentityDbContext<Applicationuser>
{
    public Sample6Context()
    {
    }

    public Sample6Context(DbContextOptions<Sample6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblcategory> Tblcategories { get; set; }

    public virtual DbSet<Tblproduct> Tblproducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HRAVADA-L-5510\\SQLEXPRESS;Initial Catalog=sample6;User ID=sa;Password=Welcome2evoke@1234; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblcategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid);

            entity.ToTable("tblcategories");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname).HasColumnName("categoryname");
        });

        modelBuilder.Entity<Tblproduct>(entity =>
        {
            entity.HasKey(e => e.Productid);

            entity.ToTable("tblproducts");

            entity.HasIndex(e => e.Categoryid, "IX_tblproducts_categoryid");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Tblproducts).HasForeignKey(d => d.Categoryid);
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Registerloginpage.Models.Signup> Signup { get; set; } = default!;

    public DbSet<Registerloginpage.Models.Login> Login { get; set; } = default!;

    public DbSet<Registerloginpage.Models.ChangePassword> ChangePassword { get; set; } = default!;
}
