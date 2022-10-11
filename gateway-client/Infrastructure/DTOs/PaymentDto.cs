using System;

namespace gateway_client.Infrastructure.DTOs
{
    public record PaymentDto(int ClientId, string Account, decimal Amount, DateTime Date);
}