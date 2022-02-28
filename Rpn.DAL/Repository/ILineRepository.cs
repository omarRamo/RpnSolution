using Rpn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rpn.DAL.Repository
{
    public interface ILineRepository
    {
        IEnumerable<TLine> GetAll();

        void Insert(TLine line);

        public void DeleteAll();

        TLine GetLastInStack();

        void DeleteElement(TLine line);

        void updateStack(double value);
    }
}
