namespace PaySlipDemo.BusinessObjects.ViewModel
{
    public class PaySlipViewModel
    {
        public string Name { get; set; }
        public decimal NetIncome { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public string PayPeriod { get; set; }
        public decimal SuperAmount { get; set; }
    }
}
