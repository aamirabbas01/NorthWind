using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DALNorthWind.Models;

namespace DALNorthWind.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Entities { get; }

        public Task<T> Create(T _object);
        public Task<int> Delete(T _object);
        public Task<int> Update(T _object);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int? Id);
    }
}
