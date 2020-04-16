using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            string transationCode,
            DateTime paidDate, 
            DateTime expiredDate, 
            decimal total, 
            decimal totalPaid, 
            string payer, 
            Document document, 
            Address address, 
            Email email):base(
                paidDate, 
                expiredDate, 
                total, 
                totalPaid, 
                payer, 
                document, 
                address, 
                email)
        {
            TransationCode = transationCode;
        }

        public string TransationCode { get; private set; }
    }
}