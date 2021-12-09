using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AddressBookWebAPI.Models
{
    public partial class AddressBookDBContext : DbContext
    {
        public AddressBookDBContext()
        {
        }

        public AddressBookDBContext(DbContextOptions<AddressBookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=AddressBookDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasOne(d => d.FriendNavigation)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friends_Users1");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Parent)
                    .HasForeignKey<Parent>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parents_Users");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.PhonNumber).IsFixedLength(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phones_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserPhoneNumber).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
