using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private readonly IList<Payment> _payments;
        public Subscription(DateTime? expiredDate)
        {
            Active = true;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpiredDate = expiredDate;
            _payments = new List<Payment>();        
        }

        public bool Active { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpiredDate { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "Data de pagamento deve ser futura")
            );

            // só adiciona se for valido
            // if(Valid)            
            _payments.Add(payment);
        }

        public void Activate(){
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate(){
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}