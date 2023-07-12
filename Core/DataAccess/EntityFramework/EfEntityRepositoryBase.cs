using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new())
            {
                var entityToAdded=context.Entry(entity);
                entityToAdded.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new())
            {
                var entityToDeleted = context.Entry(entity);
                entityToDeleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new())
            {
                var entityToUpdated = context.Entry(entity);
                entityToUpdated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
