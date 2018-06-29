using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySlipDemo.BusinessObjects.BindingModel;
using PaySlipDemo.BusinessObjects.ViewModel;

namespace PaySlipDemo.BusinessObjects.Interfaces
{
    public interface IPaySlipService
    {
        PaySlipViewModel GetPaySlip(PaySlipBindingModel model);
    }
}
