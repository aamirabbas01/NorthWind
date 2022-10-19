using DALNorthWind.Data;
using DALNorthWind.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DALNorthWind.Repository
{
    public class DALProduct : IRepository<Product>
    {
        private readonly ApplicationDBContext _context;

        public DALProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public DbSet<Product> Entities => _context.Set<Product>();

        public async Task<Product> Create(Product _object)
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

        public async Task<int> Delete(Product _object)
        {
            try
            {
                if (_object != null)
                {
                    var obj = Entities.Remove(_object);
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

        public async Task<IEnumerable<Product>> GetAll()
        {

            try
            {
                var obj = await Entities.Include(p => p.Supplier).ToListAsync();
                if (obj != null) return obj;
                else return null;
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
                    var Obj = await Entities.Include(p => p.Supplier).FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<int> Update(Product _object)
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
