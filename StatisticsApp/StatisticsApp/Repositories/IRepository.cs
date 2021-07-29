using StatisticsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<int> CreateAsync(T entity);
    }
}
