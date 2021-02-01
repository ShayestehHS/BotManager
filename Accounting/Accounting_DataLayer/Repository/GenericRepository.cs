using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Accounting_DataLayer.Context;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;



namespace Accounting_DataLayer.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private AccountingEntities _db;

        private DbSet<TEntity> _dbSet;

        public GenericRepository(AccountingEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if(where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }

        public virtual TEntity GetByID(object ID)
        {
            return _dbSet.Find(ID);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(object ID)
        {
            var entity = GetByID(ID);
            Delete(entity);
        }
    }
}
