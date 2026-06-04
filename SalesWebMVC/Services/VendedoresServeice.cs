using SalesWebMVC.Data;
using SalesWebMVC.Models;

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
            return _context.Vendedores.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(obj);
            _context.SaveChanges();
        }

    }
}
