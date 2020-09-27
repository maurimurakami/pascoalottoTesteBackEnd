using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraDividas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DebtCalculatorController.Controllers
{
    [Route("[controller]")]
    public class DebtCalculatorController : ControllerBase
    {
        /// <summary>
        ///     Calculadora de juros
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [Route("/calculator")]
        [HttpPost()]
        public ActionResult Calculate([FromForm]CalculatorConfig config)
        {
            try
            {
                string message = config.IsValid();

                if (!string.IsNullOrEmpty(message))
                {
                    return StatusCode(417, message);
                }

                Result result = config.ApplyRules();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Houve uma falha no sistema");
            }
        }
    }
}
