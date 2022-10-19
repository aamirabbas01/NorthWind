using DALNorthWind.Data;
using DALNorthWind.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALNorthWind.Repository
{
    public class DALSupplier : IRepository<Supplier>
    {
        private readonly ApplicationDBContext _context;

        public DALSupplier(ApplicationDBContext context)
        {
            _context = context;
        }

        public DbSet<Supplier> Entities => _context.Set<Supplier>();

        public async Task<Supplier> Create(Supplier _object)
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

        public async Task<int> Delete(Supplier _object)
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

        public async Task<IEnumerable<Supplier>> GetAll()
        {

            try
            {
                var obj = await Entities.ToListAsync();
                if (obj != null) return obj;
                else return null;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Supplier> GetById(int? Id)
        {
            try
            {
                if (Id != 0)
                {
                    var Obj = await Entities.FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<int> Update(Supplier _object)
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
