using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditDecisionAPI.Models
{
    public class DecisionOutput
    {
        public string TheDecision { get; set; }
        public string InterestRatePercentage { get; set; }
    }
}
