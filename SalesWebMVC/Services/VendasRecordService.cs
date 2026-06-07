using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class VendasRecordService
    {

        private readonly SalesWebMVCContext _context;

        public VendasRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<VendasRecord>> FindByDataAsync(DateTime? minData, DateTime? maxData )
        {
            var result = from obj in _context.VendasRecords select obj;
            if (minData.HasValue)
            {
                result = result.Where(x => x.Data >= minData.Value);
            }
            if (maxData.HasValue)
            {
                result = result.Where(x => x.Data <= maxData.Value);
            }

            return await result
                .Include(x => x.Vendedores)
                .Include(x => x.Vendedores.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, VendasRecord>>> FindByDataGroupAsync(DateTime? minData, DateTime? maxData)
        {
            var result = from obj in _context.VendasRecords select obj;
            if (minData.HasValue)
            {
                result = result.Where(x => x.Data >= minData.Value);
            }
            if (maxData.HasValue)
            {
                result = result.Where(x => x.Data <= maxData.Value);
            }

            return await result
                .Include(x => x.Vendedores)
                .Include(x => x.Vendedores.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedores.Departamento)
                .ToListAsync();
        }

    }
}
