using src.Interfaces;

namespace src.PagSeguro;

public class PagSeguroValidator : IPaymentValidator
{
    public bool ValidateCard(string cardNumber) 
    {
        Console.WriteLine("PagSeguro: Validando cartão...");
        return cardNumber.Length == 16;
    }
}