// DESAFIO: Sistema de Pagamentos Multi-Gateway
// PROBLEMA: Uma plataforma de e-commerce precisa integrar com múltiplos gateways de pagamento
// (PagSeguro, MercadoPago, Stripe) e cada gateway tem componentes específicos (Processador, Validador, Logger)
// O código atual está muito acoplado e dificulta a adição de novos gateways

using src.Interfaces;
using src.MercadoPago;
using src.PagSeguro;
using src.Stripe;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pagamentos ===\n");

            // Problema: Cliente precisa saber qual gateway está usando
            // e o código de processamento está todo acoplado
            
            IPaymentGatewayFactory paymentAbstractFactory = new PagSeguroFactory();

            IPaymentService pagSeguroService = new PaymentService(paymentAbstractFactory);
            pagSeguroService.ProcessPayment(150.00m, "1234567890123456");

            Console.WriteLine();


            IPaymentGatewayFactory mercadoPagoFactory = new MercadoPagoFactory();

            var mercadoPagoService = new PaymentService(mercadoPagoFactory);
            mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");


            Console.WriteLine();

            IPaymentGatewayFactory stripeFactory = new StripeFactory();

            var stripeService = new PaymentService(stripeFactory);
            stripeService.ProcessPayment(170.00m, "238214398127429743");

            
            // Pergunta para reflexão:
            // - Como adicionar um novo gateway sem modificar PaymentService?
            // - Como garantir que todos os componentes de um gateway sejam compatíveis entre si?
            // - Como evitar criar componentes de gateways diferentes acidentalmente?
        }
    }
}
