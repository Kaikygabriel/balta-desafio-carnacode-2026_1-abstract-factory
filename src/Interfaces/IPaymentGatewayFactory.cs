
namespace src.Interfaces;
public interface IPaymentGatewayFactory
{
    src.Interfaces.IPaymentValidator CreateValidator();
    src.Interfaces.IPaymentProcessor CreateProcessor();
    src.Interfaces.IPaymentLogger CreateLogger();
}