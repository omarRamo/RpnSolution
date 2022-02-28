using System;
using System.Collections.Generic;
using System.Text;

namespace Rpn.DAL.Entities
{
    public partial class TLine
    {
        public int Id { get; set; }
        public double value { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
