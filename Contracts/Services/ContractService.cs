using Contracts.Entities;
using System.Runtime.CompilerServices;

namespace Contracts.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contracts, int Month)
        {
            double valueMonthly = contracts.TotalValue / Month;

            for (int i =0; i < Month; i++)
            {
                DateTime date = contracts.Date.AddMonths(i+1);
                double updateValue = valueMonthly + _onlinePaymentService.Interest(valueMonthly, i+1);
                double fullValue = updateValue + _onlinePaymentService.PaymentFee(updateValue);
                contracts.AddIntallment(new Installment(date, fullValue));
            }
            



        }





    }
}
