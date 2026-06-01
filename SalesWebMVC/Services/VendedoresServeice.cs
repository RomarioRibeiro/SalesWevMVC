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


    }
}
