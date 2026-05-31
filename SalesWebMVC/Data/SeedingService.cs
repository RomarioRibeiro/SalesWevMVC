using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;
        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() || _context.VendasRecords.Any() || _context.Vendedores.Any())
            {
                return; //DB já foi populado
            }
            Departamento d1 = new Departamento(1, "Computador");
            Departamento d2 = new Departamento(2, "Eletronico");
            Departamento d3 = new Departamento(3, "Suporte");

            Vendedores v1 = new Vendedores(1, "Bob Brown", "bob@gmail.com.br", new DateTime(1998, 4, 21), 1000.0, d1);

            VendasRecord vr1 = new VendasRecord(1, new DateTime(2026, 5, 31), 11000.00, SaleStatus.Faturado, v1);

            _context.Departamento.AddRange(d1, d2, d3);
            _context.Vendedores.AddRange(v1);
            _context.VendasRecords.AddRange(vr1);
            _context.SaveChanges();
        }
    }
}
