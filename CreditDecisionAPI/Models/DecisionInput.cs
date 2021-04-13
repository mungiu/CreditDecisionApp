using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditDecisionAPI.Models
{
    public class DecisionInput
    {
        public string AppliedAmount  { get; set; }
        public int MonthsRepaymentTerm { get; set; }
        public string TotalCurrentDebt { get; set; }
    }
}
