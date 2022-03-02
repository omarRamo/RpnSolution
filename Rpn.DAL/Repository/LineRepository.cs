using Microsoft.EntityFrameworkCore;
using Rpn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpn.DAL.Repository
{
    public class LineRepository : ILineRepository
    {
        private readonly RpnCalculationDbContext _rpnCalculationDbContext;

        public LineRepository(RpnCalculationDbContext rpnCalculationDbContext)
        {
            _rpnCalculationDbContext = rpnCalculationDbContext;
        }

        public async Task<IEnumerable<TLine>> GetAll()
        {
          return await _rpnCalculationDbContext.TLines
                           .Select(l => new TLine() { 
                               Id = l.Id,
                               ModifiedOn = l.ModifiedOn,
                               value = l.value
                           })
                           .ToListAsync();
        }

        public async Task Insert(TLine line)
        {
            await _rpnCalculationDbContext.AddAsync(line);
            await _rpnCalculationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAll()
        {
            var lines = await _rpnCalculationDbContext.TLines.ToListAsync();
            _rpnCalculationDbContext.TLines.RemoveRange(lines);
            await _rpnCalculationDbContext.SaveChangesAsync();
        }

        public async Task<TLine> GetLastInStack()
        {
            return await _rpnCalculationDbContext.TLines.OrderByDescending(l => l.ModifiedOn).FirstAsync();
        }

        public async Task DeleteElement(TLine line)
        {
             _rpnCalculationDbContext.Remove(line);
            await _rpnCalculationDbContext.SaveChangesAsync();
        }

        public async Task updateStack(double value)
        {
            var last = await this.GetLastInStack();
            await DeleteElement(last);

            var beforeLast = await this.GetLastInStack();
            await DeleteElement (beforeLast);

            await Insert(new TLine() { value = value, ModifiedOn = DateTime.Now  });
        }
    }
}
