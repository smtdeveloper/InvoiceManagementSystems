using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FaturaYönetimSistemleri.Models.Entities;

namespace FaturaYönetimSistemleri.Models.DB
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<ElectricityBill> ElectricityBills { get; set; }
        public DbSet<NaturalGasBill> NaturalGasBills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WaterBill> WaterBills { get; set; }
        public DbSet<Todo> Todos { get; set; }
        
    }
}