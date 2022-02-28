using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpn.API.Constants
{
    public static class ConstantsKeys
    {
        public const string ops = "[ADD,SOUS,MUL,DIV]";

        public const string messageErrorDiveByZero = "Erreur dans l''évaluation, on ne peut pas diviser par 0 !!!";

        public const string evaluationMessage = "Evaluation effectuée avec succès.";

        public const string evaluationError = "Erreur, Cet opérateur n''est pas supporté dans notre API";
    }
}
