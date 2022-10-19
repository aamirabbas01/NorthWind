using DALNorthWind.Data;
using DALNorthWind.Models;
using DALNorthWind.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLNorthWind.BL
{
    public class BLProduct : IBLWorkService<Product>
    {
        public readonly IRepository<Product> _repository;
        public BLProduct(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetById(int? Id)
        {
            try
            {
                if (Id != 0)
                {
                    Product obj = await _repository.GetById(Id);
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> Create(Product _object)
        {
            try
            {
                if (_object == null)
                {
                    throw new ArgumentNullException(nameof(_object));
                }
                else
                {
                    return await _repository.Create(_object);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(Product _object)
        {
            try
            {
                if (_object != null) return await _repository.Update(_object);
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> Delete(Product _obj)
        {
            try
            {
                if (_obj != null)
                {
                    return await _repository.Delete(_obj);
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
