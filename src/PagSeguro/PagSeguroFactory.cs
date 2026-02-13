using src.Interfaces;

namespace src.PagSeguro;

public class PagSeguroFactory : IPaymentGatewayFactory
{
    public IPaymentValidator CreateValidator() => new PagSeguroValidator();
    public IPaymentProcessor CreateProcessor() => new PagSeguroProcessor();
    public IPaymentLogger CreateLogger() => new PagSeguroLogger();
}
