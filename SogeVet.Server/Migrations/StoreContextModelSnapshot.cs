﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SogeVet.Server.Data;

#nullable disable

namespace SogeVet.Server.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SogeVet.Server.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Homme"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Femme"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Enfant"
                        });
                });

            modelBuilder.Entity("SogeVet.Server.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SogeVet.Server.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SogeVet.Server.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Color = "Blanc",
                            Description = "Description du produit 1",
                            Images = "[\"URL1.1\",\"URL1.2\",\"URL1.3\"]",
                            Name = "Produit 1",
                            Quantity = 10,
                            Size = 30,
                            UnitPrice = 20.5f
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Color = "Noir",
                            Description = "Description du produit 2",
                            Images = "[\"URL2.1\",\"URL2.2\",\"URL2.3\"]",
                            Name = "Produit 2",
                            Quantity = 12,
                            Size = 41,
                            UnitPrice = 19.58f
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Color = "Rouge",
                            Description = "Description du produit 3",
                            Images = "[\"URL3.1\",\"URL3.2\",\"URL3.3\"]",
                            Name = "Produit 3",
                            Quantity = 40,
                            Size = 52,
                            UnitPrice = 10.2f
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Color = "Rouge",
                            Description = "Description du produit 4",
                            Images = "[\"URL4.1\",\"URL4.2\",\"URL4.3\"]",
                            Name = "Produit 4",
                            Quantity = 60,
                            Size = 32,
                            UnitPrice = 40.5f
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Color = "Vert",
                            Description = "Description du produit 5",
                            Images = "[\"URL5.1\",\"URL5.2\",\"URL5.3\"]",
                            Name = "Produit 5",
                            Quantity = 100,
                            Size = 36,
                            UnitPrice = 1.58f
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Color = "Bleu",
                            Description = "Description du produit 6",
                            Images = "[\"URL6.1\",\"URL6.2\",\"URL6.3\"]",
                            Name = "Produit 6",
                            Quantity = 2,
                            Size = 38,
                            UnitPrice = 3.22f
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Color = "Violet",
                            Description = "Description du produit 7",
                            Images = "[\"URL7.1\",\"URL7.2\",\"URL7.3\"]",
                            Name = "Produit 7",
                            Quantity = 12,
                            Size = 20,
                            UnitPrice = 3.5f
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Color = "Vert",
                            Description = "Description du produit 8",
                            Images = "[\"URL8.1\",\"URL8.2\",\"URL8.3\"]",
                            Name = "Produit 8",
                            Quantity = 13,
                            Size = 27,
                            UnitPrice = 10.58f
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Color = "Marron",
                            Description = "Description du produit 9",
                            Images = "[\"URL9.1\",\"URL9.2\",\"URL9.3\"]",
                            Name = "Produit 9",
                            Quantity = 24,
                            Size = 25,
                            UnitPrice = 6.2f
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Color = "Turquoise",
                            Description = "Description du produit 10",
                            Images = "[\"URL10.1\",\"URL10.2\",\"URL10.3\"]",
                            Name = "Produit 10",
                            Quantity = 52,
                            Size = 8,
                            UnitPrice = 79.99f
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Color = "Vert",
                            Description = "Description du produit 11",
                            Images = "[\"URL11.1\",\"URL11.2\",\"URL11.3\"]",
                            Name = "Produit 11",
                            Quantity = 62,
                            Size = 10,
                            UnitPrice = 19.58f
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            Color = "Noir",
                            Description = "Description du produit 12",
                            Images = "[\"URL12.1\",\"URL12.2\",\"URL12.3\"]",
                            Name = "Produit 12",
                            Quantity = 5,
                            Size = 30,
                            UnitPrice = 3.22f
                        });
                });

            modelBuilder.Entity("SogeVet.Server.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "addressadmin1",
                            Email = "MailAdmin1",
                            FirstName = "Admin1",
                            IsAdmin = true,
                            LastName = "Admin1L",
                            Password = "PasswordAdmin1"
                        },
                        new
                        {
                            Id = 2,
                            Address = "addressadmin2",
                            Email = "MailAdmin2",
                            FirstName = "Admin2",
                            IsAdmin = true,
                            LastName = "Admin2L",
                            Password = "PasswordAdmin2"
                        },
                        new
                        {
                            Id = 3,
                            Address = "addressUser1",
                            Email = "MailUser1",
                            FirstName = "User1",
                            IsAdmin = false,
                            LastName = "User1L",
                            Password = "PasswordUser1"
                        },
                        new
                        {
                            Id = 4,
                            Address = "addressUser2",
                            Email = "MailUser2",
                            FirstName = "User2",
                            IsAdmin = false,
                            LastName = "User2L",
                            Password = "PasswordUser2"
                        },
                        new
                        {
                            Id = 5,
                            Address = "addressUser3",
                            Email = "MailUser3",
                            FirstName = "User3",
                            IsAdmin = false,
                            LastName = "User3L",
                            Password = "PasswordUser3"
                        });
                });

            modelBuilder.Entity("SogeVet.Server.Entities.Order", b =>
                {
                    b.HasOne("SogeVet.Server.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SogeVet.Server.Entities.OrderItem", b =>
                {
                    b.HasOne("SogeVet.Server.Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SogeVet.Server.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SogeVet.Server.Entities.Product", b =>
                {
                    b.HasOne("SogeVet.Server.Entities.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SogeVet.Server.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SogeVet.Server.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("SogeVet.Server.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
