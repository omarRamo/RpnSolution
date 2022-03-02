using Rpn.API.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpn.API.BusinessLogic
{
    public interface IRpnService
    {
        Task AddToStack(RpnRequest req);
        Task<RpnResponse> GetStack();
        string GetOps();
        Task<EvaluationResponse> Eval(string op);
        Task DeleteStack();

    }
}
