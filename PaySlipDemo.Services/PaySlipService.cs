using PaySlipDemo.BusinessObjects.Interfaces;
using System;
using PaySlipDemo.BusinessObjects.BindingModel;
using PaySlipDemo.BusinessObjects.Helpers;
using PaySlipDemo.BusinessObjects.ViewModel;
using PaySlipDemo.Services.Infrastructure;

namespace PaySlipDemo.Services
{
    public class PaySlipService : IPaySlipService, IPaySlipDemoService
    {
        
        public PaySlipViewModel GetPaySlip(PaySlipBindingModel model)
        {
            #region Negative values validations

            if (model.AnnualSalary <= 0)
            {
                throw new Exception("Salary should be positive value");
            }
            if (model.SuperRate < 0)
            {
                throw new Exception("Super Rate should be positive value");
            }

            #endregion

            var annualSalary = model.AnnualSalary;
            var grossIncome = annualSalary.CalculateGrossIncome();
            var incomeTax = annualSalary.GetTaxSlabAmount();
            var netIncome = (grossIncome - incomeTax).RoundOffDoller();
            var superAmount = (grossIncome * model.SuperRate / 100).RoundOffDoller();
            var viewModel = new PaySlipViewModel
            {
                Name = $"{model.FirstName} {model.LastName}",
                NetIncome = netIncome,
                GrossIncome = grossIncome,
                IncomeTax = incomeTax,
                PayPeriod = model.StartDate,
                SuperAmount = superAmount
            };
            return viewModel; 
        }
    }
}
