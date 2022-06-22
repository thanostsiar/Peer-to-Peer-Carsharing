using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace carsharing.Models
{
    public partial class unipicarsContext : DbContext
    {
        public unipicarsContext()
        {
        }

        public unipicarsContext(DbContextOptions<unipicarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostComment> PostComments { get; set; } = null!;
        public virtual DbSet<PostImage> PostImages { get; set; } = null!;
        public virtual DbSet<RentedVehicle> RentedVehicles { get; set; } = null!;
        public virtual DbSet<Renter> Renters { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owners");

                entity.HasIndex(e => e.Email, "owners_email_key")
                    .IsUnique();

                entity.Property(e => e.OwnerId)
                    .HasColumnName("owner_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.VehicleId, "posts_vehicle_id_key")
                    .IsUnique();

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.MaxDaysOfRent).HasColumnName("max_days_of_rent");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posts_owner_id_fkey");

                entity.HasOne(d => d.Vehicle)
                    .WithOne(p => p.Post)
                    .HasForeignKey<Post>(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posts_vehicle_id_fkey");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("post-comments_pkey");

                entity.ToTable("post-comments");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.RenterId).HasColumnName("renter_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post-comments_post_id_fkey");

                entity.HasOne(d => d.Renter)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.RenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post-comments_renter_id_fkey");
            });

            modelBuilder.Entity<PostImage>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("post-images_pkey");

                entity.ToTable("post-images");

                entity.Property(e => e.ImageId)
                    .HasColumnName("image_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostImages)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post-images_post_id_fkey");
            });

            modelBuilder.Entity<RentedVehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("rented-vehicles_pkey");

                entity.ToTable("rented-vehicles");

                entity.Property(e => e.VehicleId)
                    .ValueGeneratedNever()
                    .HasColumnName("vehicle_id");

                entity.Property(e => e.DayOfReturn).HasColumnName("day_of_return");

                entity.Property(e => e.DayRented).HasColumnName("day_rented");

                entity.Property(e => e.RenterId).HasColumnName("renter_id");

                entity.Property(e => e.TimeOfReturn).HasColumnName("time_of_return");

                entity.Property(e => e.TimeRented).HasColumnName("time_rented");

                entity.HasOne(d => d.Renter)
                    .WithMany(p => p.RentedVehicles)
                    .HasForeignKey(d => d.RenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rented-vehicles_renter_id_fkey");

                entity.HasOne(d => d.Vehicle)
                    .WithOne(p => p.RentedVehicle)
                    .HasForeignKey<RentedVehicle>(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rented-vehicles_vehicle_id_fkey");
            });

            modelBuilder.Entity<Renter>(entity =>
            {
                entity.ToTable("renters");

                entity.HasIndex(e => e.Email, "renters_email_key")
                    .IsUnique();

                entity.Property(e => e.RenterId)
                    .HasColumnName("renter_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles");

                entity.Property(e => e.VehicleId)
                    .HasColumnName("vehicle_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicles_owner_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
