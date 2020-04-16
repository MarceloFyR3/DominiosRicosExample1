using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;

namespace PaymentContext.Domain.Fakes
{
    public class FakeEmailService : IEmailService
    {
        void IEmailService.Send(string to, string email, string subject, string boby)
        {
            
        }
    }
}