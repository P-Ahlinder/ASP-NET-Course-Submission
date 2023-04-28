﻿using CourseSubmission.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseSubmission.Helpers.Repos
{
    public abstract class Repos<TEntity> where TEntity : class
    {
        private readonly DejjtabejjsContext _context;

        protected Repos(DejjtabejjsContext context)
        {
            _context = context;
        }

        public virtual async Task <TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
                return entity;

            return null!;
            
        }


        public virtual async Task<IEnumerable <TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
            

        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
     
        }

        public virtual async Task<TEntity>UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool>DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { };
            return false;
        }
    }
}
