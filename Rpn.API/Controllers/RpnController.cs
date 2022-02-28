using Microsoft.AspNetCore.Mvc;
using Rpn.API.BusinessLogic;
using Rpn.API.Messages;

namespace Rpn.API.Controllers
{
    /// <summary>
    /// Rpn calculator Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RpnController : Controller
    {
        private readonly IRpnService _rpnService;
        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="rpnService"></param>
        public RpnController(IRpnService rpnService)
        {
            _rpnService = rpnService;
        }
        /// <summary>
        /// Retourner tous les éléments de la pile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("stack")]
        public IActionResult GetStack()
        {
            var stackResponse = _rpnService.GetStack();
            stackResponse = null;
            return Ok(stackResponse);
        }

        /// <summary>
        /// Retourner tous les opérators supportés par l'API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ops")]
        public IActionResult GetOperators()
        {
            var operatorsResponse = _rpnService.GetOps();
            return Ok(operatorsResponse);
        }
        /// <summary>
        /// Pousser un réel sur la pile
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Push/{value}")]
        public IActionResult Push(double value)
        {
            _rpnService.AddToStack(new Messages.RpnRequest()
            {
                Value =value
            });
            return Ok("Votre valeur a été poussé sur la pile");
        }

        /// <summary>
        /// Evaluer les valeurs dans la stack, veuillez donner un opérateur dans cette list [ADD,SOUS,MUL,DIV]
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("eval/{op}")]
        public IActionResult Evaluate(string op)
        {
            EvaluationResponse res = _rpnService.Eval(op);

            return Ok(res.Message);
        }
        /// <summary>
        /// Nettoyage de la pile
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("Reset")]
        public IActionResult Reset()
        {
            _rpnService.DeleteStack();
            return Ok("La pile a été nettoyé");
        }
    }
}
