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

        public List<Vendedores> FindAll()
        {
            return _context.Vendedores.ToList();
        }

        public void Insert(Vendedores vendedores)
        {
            _context.Add(vendedores);
            _context.SaveChanges();
        }

        public Vendedores FindById(int id)
        {
            return _context.Vendedores.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedores vendedores)
        {
            if (!_context.Vendedores.Any(obj => obj.Id == vendedores.Id))
            {
                throw new NotFountException("Id não existe");
            }
            try
            {
            _context.Update(vendedores);
            _context.SaveChanges();

            }catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}