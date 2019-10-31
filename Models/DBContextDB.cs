namespace Repositorio.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContextDB : DbContext
    {
        public DBContextDB()
            : base("name=AlmacenModelo")
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Company)
                .IsFixedLength();
        }
    }
}
