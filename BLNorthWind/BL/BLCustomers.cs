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
    public class BLCustomers : IBLWorkService<Customer>
    {
        public readonly IRepository<Customer> _repository;
        public BLCustomers(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Customer>> GetAll()
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

        public async Task<Customer> GetById(int? Id)
        {
            try
            {
                if (Id != 0)
                {
                    Customer obj = await _repository.GetById(Id);
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Customer> Create(Customer _object)
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

        public async Task<int> Update(Customer _object)
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
        public async Task<int> Delete(Customer _obj)
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
