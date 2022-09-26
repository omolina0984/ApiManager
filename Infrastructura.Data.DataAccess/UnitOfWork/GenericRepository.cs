using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess.UnitOfWork
{
   public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T,bool>> whereCondition=null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy= null,
            string includeProperties="");

        Task CreateAsync(T entity);

    }

    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfwork;

        public GenericRepository(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;

        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _unitOfwork.Context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {

            IQueryable<T> query = _unitOfwork.Context.Set<T>();

            if(whereCondition!= null)
            {
                query = query.Where(whereCondition);

            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

      public async  Task CreateAsync(T entity)
        {
            try
            {
                await _unitOfwork.Context.Set<T>().AddAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
