using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMVCContext _context;

        public DepartamentoService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(departamento => departamento.Descricao).ToListAsync();
        }

        public async Task<Departamento?> FindByIdAsync(int id)
        {
            return await _context.Departamento.FirstOrDefaultAsync(departamento => departamento.Id == id);
        }

    }
}
