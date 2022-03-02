using Rpn.API.Messages;
using Rpn.DAL.Repository;
using System;
using System.Linq;
using Rpn.API.Constants;
using Rpn.API.Helper;
using System.Threading.Tasks;

namespace Rpn.API.BusinessLogic
{
    public class RpnService : IRpnService
    {
        private readonly ILineRepository _lineRepository;

        public RpnService(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        public async Task AddToStack(RpnRequest req)
        {
            await _lineRepository.Insert(new DAL.Entities.TLine()
            {
                value = req.Value,
                ModifiedOn = DateTime.Now
            });
        }

        /// <summary>
        /// Get all stack elements
        /// </summary>
        /// <returns></returns>
        public async Task<RpnResponse> GetStack()
        {
            var tab = await _lineRepository.GetAll();
            var result = String.Join(" | ", Array.ConvertAll<double, String>(tab.Select(t => t.value).ToArray(), Convert.ToString));

            return new RpnResponse() { Stack = result };
        }

        /// <summary>
        /// Get the operators
        /// </summary>
        /// <returns></returns>
        public string GetOps() 
        {
            return ConstantsKeys.ops;
        }
            
        public async Task<EvaluationResponse> Eval(string op)
        {
            var stackArrayAsync = await _lineRepository.GetAll();
            var stackArray = stackArrayAsync.ToArray();
            double updateValue = 0;
            if (!Enum.IsDefined(typeof(OperatorsEnum), op.ToUpper()))
            {
                return new EvaluationResponse()
                {
                    isError = true,
                    Message = ConstantsKeys.evaluationError
                };
            }
            else
            {
                var opp = (OperatorsEnum)Enum.Parse(typeof(OperatorsEnum), op.ToUpper());
                switch (opp)
                {
                    case OperatorsEnum.ADD:
                        updateValue = CalculationHelper.Calculate(stackArray, OperatorsEnum.ADD);
                        break;
                    case OperatorsEnum.SOUS:
                        updateValue = CalculationHelper.Calculate(stackArray, OperatorsEnum.SOUS);
                        break;
                    case OperatorsEnum.MUL:
                        updateValue = CalculationHelper.Calculate(stackArray, OperatorsEnum.MUL);
                        break;
                    case OperatorsEnum.DIV:
                        if (stackArray[stackArray.Length - 1].value == 0)
                        {
                            return new EvaluationResponse()
                            {
                                isError = true,
                                Message = ConstantsKeys.messageErrorDiveByZero
                            };
                        }
                        updateValue = updateValue = CalculationHelper.Calculate(stackArray, OperatorsEnum.DIV);
                        break;
                    default:
                        break;
                }
            }
                
            //Update the stack to persiste the update values
            await _lineRepository.updateStack(updateValue);

            return new EvaluationResponse()
            {
                isError = false,
                Message = ConstantsKeys.evaluationMessage
            };
        }
        /// <summary>
        /// Reset the stack
        /// </summary>
        public async Task DeleteStack()
        {
           await _lineRepository.DeleteAll();
        }
            
    }
}
