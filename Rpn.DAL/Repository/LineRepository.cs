using Rpn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpn.DAL.Repository
{
    public class LineRepository : ILineRepository
    {
        private readonly RpnCalculationDbContext _rpnCalculationDbContext;

        public LineRepository(RpnCalculationDbContext rpnCalculationDbContext)
        {
            _rpnCalculationDbContext = rpnCalculationDbContext;
        }

        public IEnumerable<TLine> GetAll()
        {
            return _rpnCalculationDbContext.TLines;
        }

        public void Insert(TLine line)
        {
            _rpnCalculationDbContext.Add(line);
            _rpnCalculationDbContext.SaveChanges();
        }

        public void DeleteAll()
        {
            var lines = _rpnCalculationDbContext.TLines;
            _rpnCalculationDbContext.TLines.RemoveRange(lines);
        }

        public TLine GetLastInStack()
        {
            return _rpnCalculationDbContext.TLines.OrderByDescending(l => l.ModifiedOn).First();
        }

        public void DeleteElement(TLine line)
        {
            _rpnCalculationDbContext.Remove(line);
            _rpnCalculationDbContext.SaveChanges();
        }

        public void updateStack(double value)
        {
            var last = this.GetLastInStack();
            DeleteElement(last);

            var beforeLast = this.GetLastInStack();
            DeleteElement(beforeLast);

            Insert(new TLine()
            {
                value = value,
                ModifiedOn = DateTime.Now
            });
        }
    }
}
