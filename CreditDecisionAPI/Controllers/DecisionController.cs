﻿using CreditDecisionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CreditDecisionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecisionController : Controller
    {
        [HttpGet]
        public ActionResult Index([FromBody] DecisionInput decisionInput)
        {
            try
            {
                if (decimal.Parse(decisionInput.AppliedAmount) <= 0 || decimal.Parse(decisionInput.TotalCurrentDebt) <= 0)
                {
                    return BadRequest("The 'Applied Amount' and 'Total Future Debt' must be greater than zero.");
                }
                DecisionOutput decisionOutput = Decide(decisionInput);
                string json = JsonSerializer.Serialize(decisionOutput);

                return Ok(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("DecisionController: " + e.Message);
            }


            return BadRequest();
        }

        private DecisionOutput Decide(DecisionInput decisionInput)
        {
            DecisionOutput decisionOutput = new DecisionOutput
            {
                TheDecision = (
               decimal.Parse(decisionInput.AppliedAmount) >= DecisionEnums.MIN_APPLICATION_AMOUNT &&
               decimal.Parse(decisionInput.AppliedAmount) <= DecisionEnums.MAX_APPLICATION_AMOUNT) ?
               "Yes" : "No",

                InterestRatePercentage = decimal.Parse(decisionInput.TotalCurrentDebt) switch
                {
                    decimal TotalFutureDebt when TotalFutureDebt + decimal.Parse(decisionInput.AppliedAmount) 
                    < 20000 => 3.ToString(),
                    decimal TotalFutureDebt when TotalFutureDebt + decimal.Parse(decisionInput.AppliedAmount) 
                    < 40000 => 4.ToString(),
                    decimal TotalFutureDebt when TotalFutureDebt + decimal.Parse(decisionInput.AppliedAmount) 
                    < 60000 => 5.ToString(),
                    _ => 6.ToString(),
                }
            };

            return decisionOutput;
        }

    }
}
