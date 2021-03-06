// <auto-generated />
using System;
using AddressBookWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddressBookWebAPI.Migrations
{
    //[DbContext(typeof(AddressBookDBContext))]
    partial class AddressBookDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AddressBookWebAPI.Models.Friend", b =>
                {
                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasIndex("FriendId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("AddressBookWebAPI.Models.Parent", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FatherId")
                        .HasColumnType("int");

                    b.Property<int>("MotherId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("AddressBookWebAPI.Models.Phone", b =>
                {
                    b.Property<string>("PhonNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .IsFixedLength(true);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PhonNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("AddressBookWebAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("UserDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoneNumber")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AddressBookWebAPI.Models.Friend", b =>
                {
                    b.HasOne("AddressBookWebAPI.Models.User", "FriendNavigation")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .HasConstraintName("FK_Friends_Users")
                        .IsRequired();

                    b.Navigation("FriendNavigation");
                });

            modelBuilder.Entity("AddressBookWebAPI.Models.Parent", b =>
                {
                    b.HasOne("AddressBookWebAPI.Models.User", "User")
                        .WithOne("Parent")
                        .HasForeignKey("AddressBookWebAPI.Models.Parent", "UserId")
                        .HasConstraintName("FK_Parents_Users")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AddressBookWebAPI.Models.Phone", b =>
                {
                    b.HasOne("AddressBookWebAPI.Models.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Phones_Users")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AddressBookWebAPI.Models.User", b =>
                {
                    b.Navigation("Parent");

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
