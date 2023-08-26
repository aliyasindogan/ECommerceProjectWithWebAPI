using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        IHttpContextAccessor _httpContextAccessor;
        public EfBaseRepository()
        {
            _httpContextAccessor = (IHttpContextAccessor)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(IHttpContextAccessor)); ;
        }
        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                var createDate = entity.GetType().GetProperty("CreatedDate");
                if (!Equals(createDate, null))
                {
                    var dateValue = entity.GetType().GetProperty("CreatedDate").GetValue(entity);
                    entity.GetType().GetProperty("CreatedUserId").SetValue(entity, Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
                    if (!Equals(createDate, null))
                    {
                        if (Convert.ToDateTime(dateValue) == DateTime.MinValue)
                            entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
                    }
                }
                using (TContext context = new TContext())
                {
                    await context.Set<TEntity>().AddAsync(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
            }
            catch (Exception ex)
            {

                string exx = ex.Message;
                return entity;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var createDate = entity.GetType().GetProperty("UpdatedDate");
            if (!Equals(createDate, null))
            {
                var dateValue = entity.GetType().GetProperty("UpdatedDate").GetValue(entity);
                entity.GetType().GetProperty("UpdatedUserId").SetValue(entity, Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
                if (!Equals(createDate, null))
                {
                    if (Convert.ToDateTime(dateValue) == DateTime.MinValue)
                        entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.Now);
                } 
            }
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = await context.Set<TEntity>().FindAsync(id);
                context.Set<TEntity>().Remove(deleteEntity);
                var data = await context.SaveChangesAsync();
                if (data > 0)
                    return true;
                return false;
            }
        }

        public async Task<List<TEntity>> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                var query = context.Set<TEntity>().ToList();
                foreach (var include in includes)
                    query = context.Set<TEntity>().Include(include).ToList();
                return query.ToList();
            }
        }
    }
}