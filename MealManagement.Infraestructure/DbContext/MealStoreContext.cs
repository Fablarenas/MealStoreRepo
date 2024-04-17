using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagement.Infraestructure.DbContext
{
    using MealManagement.Infraestructure.Entities;
    using Microsoft.EntityFrameworkCore;

    public class MealStoreContext : DbContext
    {
        public MealStoreContext(DbContextOptions<MealStoreContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
