using SPORT_STORE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SPORT_STORE.DAL
{
    public class StoreContext: DbContext
    {
        public DbSet<Produkt> Produkts { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Inventar> Inventars{ get; set; }
        public DbSet<Detaje_Porosi> Detaje_Porosis { get; set; }
        public DbSet<Porosi> Porosis { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shporta> Shportas { get; set; }
    }
}