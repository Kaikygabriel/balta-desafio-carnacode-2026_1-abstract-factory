namespace src.Interfaces;

  public interface IPaymentService
{
    void ProcessPayment(decimal amount, string cardNumber);
}