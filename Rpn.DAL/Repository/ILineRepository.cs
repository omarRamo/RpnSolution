using Rpn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rpn.DAL.Repository
{
    public interface ILineRepository
    {
        Task<IEnumerable<TLine>> GetAll();

        Task Insert(TLine line);

        Task DeleteAll();

        Task<TLine> GetLastInStack();

        Task DeleteElement(TLine line);

        Task updateStack(double value);
    }
}
