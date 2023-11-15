using System;
using System.Globalization;
using Contracts.Entities;
using Contracts.Services;


namespace Contracts
{

    class Program
    {


        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter Contracts Data ");
            Console.Write("Number: ");
            int numberContract = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime dateContract = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract Value: ");
            double valueContract = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int numberInstallments = int.Parse(Console.ReadLine());


            Contract contract = new Contract(numberContract, dateContract, valueContract);

            ContractService contractService = new ContractService(new PaypalService());

            contractService.ProcessContract(contract, numberInstallments);

            Console.WriteLine("Installments: ");
            foreach(Installment installments in contract.Installments )
            {
                Console.WriteLine(installments);

            }




        }
    }



}