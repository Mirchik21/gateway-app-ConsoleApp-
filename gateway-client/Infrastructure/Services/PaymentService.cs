using gateway_client.Infrastructure.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gateway_client.Infrastructure.Services
{
    public class PaymentService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string checkUrl = "https://localhost:44357/Payment/check";
        private const string paymentUrl = "https://localhost:44357/Payment/payment";

        public async Task<Result> Check(CheckDto check)
        {
            try
            {
                using StringContent jsonContent = new(JsonSerializer.Serialize(check), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(checkUrl, jsonContent);

                return await response.Content.ReadFromJsonAsync<Result>();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Ошибка при http запросе{ex.ToString()}");
            }
        }

        public async Task<Result> SavePayment(PaymentDto payment)
        {
            try
            {
                using StringContent jsonContent = new(JsonSerializer.Serialize(payment), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(paymentUrl, jsonContent);

                return await response.Content.ReadFromJsonAsync<Result>();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Ошибка при http запросе{ex.ToString()}");
            }
        }
    }
}