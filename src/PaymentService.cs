using src.Interfaces;

namespace src;

public class PaymentService : IPaymentService
{
    private readonly IPaymentValidator _validator;
    private readonly IPaymentProcessor _processor;
    private readonly IPaymentLogger _logger;

    public PaymentService(IPaymentGatewayFactory factory)
    {
        _validator = factory.CreateValidator();
        _processor = factory.CreateProcessor();
        _logger = factory.CreateLogger();
    }

    public void ProcessPayment(decimal amount, string cardNumber)
    {
        if (!_validator.ValidateCard(cardNumber))
        {
            Console.WriteLine("Cartão inválido");
            return;
        }

        var result = _processor.ProcessTransaction(amount, cardNumber);
        _logger.Log($"Transação processada: {result}");
    }
}