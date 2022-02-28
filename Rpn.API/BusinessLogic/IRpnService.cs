using Rpn.API.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpn.API.BusinessLogic
{
    public interface IRpnService
    {
        void AddToStack(RpnRequest req);
        RpnResponse GetStack();
        string GetOps();
        void DeleteStack();
        EvaluationResponse Eval(string op);

    }
}
