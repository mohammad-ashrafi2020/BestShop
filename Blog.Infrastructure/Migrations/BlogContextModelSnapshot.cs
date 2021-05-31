﻿// <auto-generated />
using System;
using Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Infrastructure.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Domain.Entities.BlogPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime>("DateRelease")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(110)
                        .IsUnicode(false)
                        .HasColumnType("varchar(110)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSpecial")
                        .HasColumnType("bit");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ShortLink")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<long?>("SubGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int>("TimeRequiredToStudy")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrlTitle")
                        .IsRequired()
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)");

                    b.Property<long>("Visit")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ShortLink")
                        .IsUnique();

                    b.HasIndex("SubGroupId");

                    b.HasIndex("UrlTitle")
                        .IsUnique();

                    b.ToTable("BlogPosts", "dbo");
                });

            modelBuilder.Entity("Blog.Domain.Entities.BlogPostComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("BlogPostComments", "dbo");
                });

            modelBuilder.Entity("Blog.Domain.Entities.BlogPostGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("EnglishGroupTitle")
                        .IsRequired()
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("BlogPostGroups", "dbo");
                });

            modelBuilder.Entity("Blog.Domain.Entities.BlogPost", b =>
                {
                    b.HasOne("Blog.Domain.Entities.BlogPostGroup", "Group")
                        .WithMany("MainBlogPosts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Blog.Domain.Entities.BlogPostGroup", "SubGroup")
                        .WithMany("SubBlogPosts")
                        .HasForeignKey("SubGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Group");

                    b.Navigation("SubGroup");
                });

            modelBuilder.Entity("Blog.Domain.Entities.BlogPostComment", b =>
                {
                    b.HasOne("Blog.Domain.Entities.BlogPost", "BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("Blog.Domain.Entities.BlogPostGroup", b =>
                {
                    b.HasOne("Blog.Domain.Entities.BlogPostGroup", null)
                        .WithMany("Groups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Blog.Domain.Entities.BlogPost", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Blog.Domain.Entities.BlogPostGroup", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("MainBlogPosts");

                    b.Navigation("SubBlogPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
