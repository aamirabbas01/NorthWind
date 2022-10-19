using DALNorthWind.Data;
using DALNorthWind.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DALNorthWind.Repository
{
    public class DALOrder : IRepository<Order>
    {
        private readonly ApplicationDBContext _context;

        public DALOrder(ApplicationDBContext context)
        {
            _context = context;
        }

        public DbSet<Order> Entities => _context.Set<Order>();

        public async Task<Order> Create(Order _object)
        {
            try
            {
                if (_object != null)
                {
                    var obj = Entities.Add(_object);
                    await _context.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Delete(Order order)
        {
            try
            {
                if (order != null)
                {
                    var obj = Entities.Remove(order); ;//await Entities.Include(o => o.OrderItem).FirstOrDefaultAsync(o => o.Id == _object.Id);
                    if (obj != null)
                    {
                        return await _context.SaveChangesAsync();
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {

            try
            {
                var obj = await Entities.Include(o => o.Customer).ToListAsync();
                if (obj != null) return obj;
                else return null;
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
                    var Obj = await Entities.Include(o => o.Customer).Include(o => o.OrderItem).Include("OrderItem.Product")
                .FirstOrDefaultAsync(m => m.Id == Id);
                    if (Obj != null) return Obj;
                    else return null;
                }
                else
                {
                    return null;
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
                if (_object != null)
                {
                    var obj = Entities.Update(_object);
                    if (obj != null) return await _context.SaveChangesAsync();
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
