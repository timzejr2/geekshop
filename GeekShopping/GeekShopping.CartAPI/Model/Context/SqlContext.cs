﻿using GeekShopping.CartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Model.Context
{
    public class SqlContext : DbContext
    {

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }

        
    }
}
