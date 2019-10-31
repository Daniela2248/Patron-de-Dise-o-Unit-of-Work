using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repositorio.Repositories
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new DBContextDB();
        }
        private readonly DBContextDB context;

        private GenericRepository<Product> productsRepository;
        public GenericRepository<Product> ProductsRepository
        {
            get
            {
                if (this.productsRepository == null)
                {
                    this.productsRepository = new GenericRepository<Product>(this.context);
                }
                return this.productsRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}