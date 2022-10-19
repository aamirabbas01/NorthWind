﻿using DALNorthWind.Data;
using DALNorthWind.Models;
using DALNorthWind.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLNorthWind.BL
{
    public class BLOrder : IBLWorkService<Order>
    {
        public readonly IRepository<Order> _repository;
        public BLOrder(IRepository<Order> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Order>> GetAll()
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

        public async Task<Order> GetById(int? Id)
        {
            try
            {
                if (Id != 0)
                {
                    Order obj = await _repository.GetById(Id);
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Order> Create(Order _object)
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

        public async Task<int> Update(Order _object)
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
        public async Task<int> Delete(Order _obj)
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
