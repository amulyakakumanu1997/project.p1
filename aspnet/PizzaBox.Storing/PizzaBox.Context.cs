using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

public class PizzaBoxContext : DbContext
{
    public DbSet<Store> Store { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Crust> Crust { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<APizzaModel> Pizza { get; set; }
    public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Store>().HasKey(store => store.EntityId);
        builder.Entity<Store>().HasMany(store => store.Orders).WithOne(order => order.store);

        builder.Entity<Order>().HasKey(order => order.EntityId);

        builder.Entity<Customer>().HasKey(u => u.EntityId);

        builder.Entity<APizzaModel>().HasKey(pizza => pizza.EntityId);
        builder.Entity<APizzaModel>().OwnsOne(pizza => pizza.Crust);
        builder.Entity<APizzaModel>().OwnsOne(pizza => pizza.Size);
        builder.Entity<APizzaModel>().HasMany(pizza => pizza.Toppings);

        builder.Entity<Topping>().HasKey(topping => topping.EntityId);


        SeedData(builder);
    }
    private void SeedData(ModelBuilder builder)
    {
        builder.Entity<Store>().HasData(new List<Store>
            {
                new Store(){Name = "Dominos",EntityId = 1},
                new Store(){Name = "Pizza Hut",EntityId = 2},
                new Store() {Name = "Davannis", EntityId = 3}
            }
        );
        builder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer(){Name = "Amulya",EntityId = 1},
            new Customer(){Name = "Fred",EntityId = 2},
            new Customer(){Name = "Sam",EntityId = 3}
        });

        
    }


}