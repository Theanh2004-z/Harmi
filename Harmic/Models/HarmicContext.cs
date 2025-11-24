using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Harmic.Models
{
    public partial class HarmicContext : DbContext
    {
        public HarmicContext()
        {
        }

        public HarmicContext(DbContextOptions<HarmicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAccount> TbAccounts { get; set; }
        public virtual DbSet<TbBlog> TbBlogs { get; set; }
        public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }
        public virtual DbSet<TbCategory> TbCategories { get; set; }
        public virtual DbSet<TbContact> TbContacts { get; set; }

        public virtual DbSet<TbCustomer> TbCustomers { get; set; }
        public virtual DbSet<TbMenu> TbMenus { get; set; }
        public virtual DbSet<TbNews> TbNews { get; set; }
        public virtual DbSet<TbOrder> TbOrders { get; set; }
        public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; }
        public virtual DbSet<TbOrderStatus> TbOrderStatuses { get; set; }
        public virtual DbSet<TbProduct> TbProducts { get; set; }
        public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }
        public virtual DbSet<TbProductReview> TbProductReviews { get; set; }

        public virtual DbSet<TbRole> TbRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:HarmicDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId).HasName("PK__tb_Accou__349DA5A6E36DF0D1");
                entity.ToTable("tb_Account");

                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.FullName).HasMaxLength(150);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.LastLogin).HasColumnType("datetime");
                entity.Property(e => e.Password).HasMaxLength(200);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role).WithMany(p => p.TbAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<TbBlog>(entity =>
            {
                entity.HasKey(e => e.BlogId).HasName("PK__tb_Blog__54379E30BD083DA6");
                entity.ToTable("tb_Blog");

                entity.Property(e => e.Alias).HasMaxLength(250);
                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.Image).HasMaxLength(500);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.SeoDescription).HasMaxLength(500);
                entity.Property(e => e.SeoKeywords).HasMaxLength(250);
                entity.Property(e => e.SeoTitle).HasMaxLength(250);
                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Account).WithMany(p => p.TbBlogs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Blog_Account");
            });

            // ✅ Ánh xạ đúng bảng trong SQL Server
            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.ToTable("tb_Product");
            });

            modelBuilder.Entity<TbProductCategory>(entity =>
            {
                entity.ToTable("tb_ProductCategory");
            });

            modelBuilder.Entity<TbMenu>(entity =>
            {
                entity.ToTable("tb_Menu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
