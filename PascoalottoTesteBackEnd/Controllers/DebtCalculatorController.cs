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
        public ActionResult Get()
        {
            return Ok("Teste do get");
        }

        [Route("/calculator")]
        [HttpPost()]
        public ActionResult Calculate([FromBody]CalculatorConfig config)
        {
            Result result = config.ApplyRules();

            return Ok(result);
        }
    }
}
