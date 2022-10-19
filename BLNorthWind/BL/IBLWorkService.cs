using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLNorthWind.BL
{
    public interface IBLWorkService<T> where T : class
    {
        public Task<T> Create(T _object);
        public Task<int> Delete(T _object);
        public Task<int> Update(T _object);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int? Id);

    }
}
