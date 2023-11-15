

namespace Contracts.Services
{
    internal interface IOnlinePaymentService
    {

        double Interest(double amount, int month);
        double PaymentFee(double amount);


        
      




    }
}
