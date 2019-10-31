using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repositorio.Repositories
{
    public class GenericRepository<AlmacenModelo> where AlmacenModelo : class
    {
        private readonly DBContextDB context;
        private readonly DbSet<AlmacenModelo> dbSet;

        public GenericRepository(DBContextDB context)
        {
            this.context = context;
            this.dbSet = context.Set<AlmacenModelo>();
        }
        public void Create(AlmacenModelo entity)
        {
            dbSet.Add(entity);
        }
        public void CreateRange(IEnumerable<AlmacenModelo> entities)
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }
        public async Task<AlmacenModelo> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }
        public virtual IQueryable<AlmacenModelo> SelectQuery(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).AsQueryable();
        }
        public void Update(AlmacenModelo entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(AlmacenModelo entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public async Task Delete(params object[] id)
        {
            AlmacenModelo entity = await this.FindAsync(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }
        public IQueryable<AlmacenModelo> Queryable()
        {
            return dbSet;
        }
    }
}