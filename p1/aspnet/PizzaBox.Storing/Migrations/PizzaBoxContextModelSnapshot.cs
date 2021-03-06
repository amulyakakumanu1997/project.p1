﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxContext))]
    partial class PizzaBoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizzaModel", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderEntityId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityId");

                    b.HasIndex("OrderEntityId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Amulya"
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Fred"
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Sam"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CustomerEntityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("StoreEntityId")
                        .HasColumnType("bigint");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("EntityId");

                    b.HasIndex("CustomerEntityId");

                    b.HasIndex("StoreEntityId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Dominos"
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Pizza Hut"
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Davannis"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("APizzaModelEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.HasIndex("APizzaModelEntityId");

                    b.ToTable("Topping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizzaModel", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderEntityId");

                    b.OwnsOne("PizzaBox.Domain.Models.Crust", "Crust", b1 =>
                        {
                            b1.Property<long>("APizzaModelEntityId")
                                .HasColumnType("bigint");

                            b1.Property<long>("EntityId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("Price")
                                .HasColumnType("float");

                            b1.HasKey("APizzaModelEntityId");

                            b1.ToTable("Crust");

                            b1.WithOwner()
                                .HasForeignKey("APizzaModelEntityId");
                        });

                    b.OwnsOne("PizzaBox.Domain.Models.Size", "Size", b1 =>
                        {
                            b1.Property<long>("APizzaModelEntityId")
                                .HasColumnType("bigint");

                            b1.Property<long>("EntityId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("Price")
                                .HasColumnType("float");

                            b1.HasKey("APizzaModelEntityId");

                            b1.ToTable("Size");

                            b1.WithOwner()
                                .HasForeignKey("APizzaModelEntityId");
                        });

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Store", "store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizzaModel", null)
                        .WithMany("Toppings")
                        .HasForeignKey("APizzaModelEntityId");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizzaModel", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
