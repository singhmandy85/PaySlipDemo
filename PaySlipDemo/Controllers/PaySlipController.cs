using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using PaySlipDemo.BusinessObjects.BindingModel;
using PaySlipDemo.BusinessObjects.Helpers;
using PaySlipDemo.BusinessObjects.Interfaces;

namespace PaySlipDemo.Controllers
{
    [RoutePrefix("api/payslip")]
    public class PaySlipController : ApiController
    {
        private readonly IPaySlipService _paySlipService;

        public PaySlipController(IPaySlipService paySlipService)
        {
            _paySlipService = paySlipService;
        }
       
        [HttpPost]
        [Route("GeneratePaySlip")]
        public IHttpActionResult GeneratePaySlip(PaySlipBindingModel model)
        {
            var viewModel = _paySlipService.GetPaySlip(model);
            return Ok(viewModel);
        }
    }
}
