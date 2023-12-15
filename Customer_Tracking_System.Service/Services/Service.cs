using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Core.Services;
using Customer_Tracking_System.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Service.Services
{
    public class Service<T> : IServices<T> where T : class
    {
        private readonly IGenericRepository<T> genericRepository;
        private readonly IUnitOfWork unitOfWork;

        public Service(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
        {
            this.genericRepository = genericRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await genericRepository.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity)
        {
            await genericRepository.AddRangeAsync(entity);
            await unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await genericRepository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await genericRepository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await genericRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            genericRepository.Remove(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entity)
        {
            genericRepository.RemoveRange(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            genericRepository.Update(entity);
            await unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return genericRepository.Where(expression);
        }
    }
}
