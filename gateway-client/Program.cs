using gateway_client.Infrastructure.DTOs;
using gateway_client.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace gateway_client
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            PaymentService paymentService = new();

            var checkResult = await paymentService.Check(new CheckDto(18001000, "1231231231"));

            if (!checkResult.Succeed)
                Console.WriteLine($"Абонент не найден");

            var savePaymentResult = await paymentService.SavePayment(new PaymentDto(18001000, "1231231231", 15200, DateTime.Now));

            if (!savePaymentResult.Succeed)
                Console.WriteLine("Платеж не прошел");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Платеж успешно прошел");
            Console.WriteLine("Success");

            Console.ReadKey();
        }
    }
}