using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

#nullable disable

namespace CSharp_Project.Models
{
    public partial class C_ProjectDBContext : DbContext
    {
        public C_ProjectDBContext()
        {

        }
         
       
        public C_ProjectDBContext(DbContextOptions<C_ProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryTable> CategoryTables { get; set; }
        public virtual DbSet<CommentTable> CommentTables { get; set; }
        public virtual DbSet<NewsTable> NewsTables { get; set; }
        public virtual DbSet<RoleTable> RoleTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*optionsBuilder
                    .LogTo(Console.WriteLine, LogLevel.Debug, DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();*/
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                .AddJsonFile("appsettings.json")
                                                .Build();
                                                
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<CategoryTable>(entity =>
            {
                entity.ToTable("category_table");

                entity.HasIndex(e => e.Code, "UQ__category__357D4CF98E97379F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CommentTable>(entity =>
            {
                entity.ToTable("comment_table");

                entity.HasIndex(e => e.CreateBy, "IX_comment_table_createBy");

            entity.HasIndex(e => e.NewsId);//, "IX_comment_table_newsId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.ModifiedBy).HasColumnName("ModifiedBy");

                entity.Property(e => e.ModifiedDate).HasColumnName("ModifiedDate");

                entity.Property(e => e.NewsId).HasColumnName("newsId");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.CommentTables)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment_t__creat__31EC6D26");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.CommentTables)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.ClientCascade);
                    //.HasConstraintName("FK__comment_t__newsI__32E0915F");
            });

            modelBuilder.Entity<NewsTable>(entity =>
            {
                entity.ToTable("news_table");

                entity.HasIndex(e => e.CategoryId, "IX_news_table_categoryId");

                entity.HasIndex(e => e.CreateBy, "IX_news_table_createBy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.ModifiedBy).HasColumnName("ModifiedBy");

                entity.Property(e => e.ModifiedDate).HasColumnName("ModifiedDate");

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("shortDescription");

                entity.Property(e => e.Thumbnail)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("thumbnail");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.NewsTables)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__news_tabl__categ__2E1BDC42");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.NewsTables)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__news_tabl__creat__2F10007B");
            });

            modelBuilder.Entity<RoleTable>(entity =>
            {
                entity.ToTable("role_table");

                entity.HasIndex(e => e.Code, "UQ__role_tab__357D4CF9E303D637")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("user_table");

                entity.HasIndex(e => e.RoleId, "IX_user_table_roleId");

                entity.HasIndex(e => e.Username, "UQ__user_tab__F3DBC5720A716196")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_tabl__roleI__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        
    }
}
