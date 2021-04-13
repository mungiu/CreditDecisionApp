using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditDecisionAPI.Models.Validators
{
    public class DecisionInputValidator : AbstractValidator<DecisionInput>
    {
        public DecisionInputValidator()
        {
            try
            {
                RuleFor(x => decimal.Parse(x.AppliedAmount))    
                    .LessThan(0).WithMessage("The ApliedAmount must be greather than zero.");
                RuleFor(x => x.AppliedAmount)
                    .NotEmpty().WithMessage("The AppliedAmount cannot be blank.")
                    .Length(0, 29).WithMessage("The AppliedAmount cannot be more than 29 characters.");

                RuleFor(x => decimal.Parse(x.TotalCurrentDebt)) 
                    .LessThan(0).WithMessage("The TotalCurrentDebt must be greather than zero.");
                RuleFor(x => x.TotalCurrentDebt)
                    .NotEmpty()
                    .WithMessage("The TotalCurrentDebt cannot be blank.");

                RuleFor(x => x.MonthsRepaymentTerm)
                    .LessThan(1).WithMessage("The MonthsRepaymentTerm must be greather than zero.")
                    .NotEmpty().WithMessage("The MonthsRepaymentTerm cannot be blank.")
                    .GreaterThan(12).WithMessage("The MonthsRepaymentTerm must be maximum twelve.");
            }
            catch (Exception e)
            {
                Console.Write("DecisionInputValidator: " + e.Message);
            }
        }
    }
}
