using Rpn.DAL.Entities;

namespace Rpn.API.Helper
{
    public static class CalculationHelper
    {
        public static double Calculate(TLine[] stackArray, OperatorsEnum op)
        {
            switch (op)
            {
                case OperatorsEnum.ADD:
                    return stackArray[stackArray.Length - 1].value + stackArray[stackArray.Length - 2].value;
                case OperatorsEnum.SOUS:
                    return stackArray[stackArray.Length - 1].value - stackArray[stackArray.Length - 2].value;
                case OperatorsEnum.MUL:
                    return stackArray[stackArray.Length - 1].value * stackArray[stackArray.Length - 2].value;
                case OperatorsEnum.DIV:
                    return stackArray[stackArray.Length - 1].value / stackArray[stackArray.Length - 2].value;
                default:
                    return 0;
            }
        
        }
    }
}
