using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Fakes;
using PaymentContext.Domain.Handlers;

namespace PaymentContext.Test
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenBoletoDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Document = "38184776047",
                Email = "suporte2@fyr3.com.br",
                BarCode = "123456789",
                BoletoNumber = "123456789",
                PaymentNumber = "121231321",
                PaidDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "WAYNE CORP",
                PayerDocument = "12345678912124",
                PayerDocumentType = EDocumentType.CNPJ,
                PayerEmail = "batman@fyr3.com.br",
                Street = "Rua Mato Grosso",
                Number = "12",
                Neighborhood = "Parolin",
                City = "Curitiba",
                State = "PR",
                Country = "Brazil",
                ZipCode = "80220123"
            };

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenBoletoEmailExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Document = "38184776049",
                Email = "suporte@fyr3.com.br",
                BarCode = "123456789",
                BoletoNumber = "123456789",
                PaymentNumber = "121231321",
                PaidDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "WAYNE CORP",
                PayerDocument = "12345678912124",
                PayerDocumentType = EDocumentType.CNPJ,
                PayerEmail = "batman@fyr3.com.br",
                Street = "Rua Mato Grosso",
                Number = "12",
                Neighborhood = "Parolin",
                City = "Curitiba",
                State = "PR",
                Country = "Brazil",
                ZipCode = "80220123"
            };

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}

