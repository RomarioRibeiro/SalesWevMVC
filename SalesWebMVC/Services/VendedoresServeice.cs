using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exception;

namespace SalesWebMVC.Services
{
    public class VendedoresServeice
    {
        private readonly SalesWebMVCContext _context;

        public VendedoresServeice(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedores>> FindAllAsyn()
        {
            return await _context.Vendedores.ToListAsync();
        }

        public async Task InsertAsync(Vendedores vendedores)
        {
            _context.Add(vendedores);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedores> FindByIdAsync(int id)
        {
            return await _context.Vendedores.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Vendedores.FindAsync(id);
            _context.Vendedores.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedores vendedores)
        {
            bool isVendedor = await _context.Vendedores.AnyAsync(obj => obj.Id == vendedores.Id);
            if (!isVendedor)
            {
                throw new NotFountException("Id não existe");
            }
            try
            {
            _context.Update(vendedores);
            await _context.SaveChangesAsync();

            }catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
