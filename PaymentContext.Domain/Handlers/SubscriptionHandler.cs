using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _email;


        public SubscriptionHandler(IStudentRepository repository, IEmailService email)
        {
            _repository = repository;
            _email = email;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // verificar se Documento já esta cadastrado
            if (_repository.DocumentExistis(command.Document))
                AddNotification("Document", "Esse Documento já existe");


            // verificar se email já esta cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Esse email já existe");

            // gerar os vo's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpiredDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address, email
            );

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, email, document, address, student, subscription, payment);

            // Checar
            if (Invalid)
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");

            // salvar as informações
            _repository.CreateSunscription(student);

            // Enviar e-mail de boas vindas
            _email.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo", "Sucesso na assinatura");

            // retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // verificar se Documento já esta cadastrado
            if (_repository.DocumentExistis(command.Document))
                AddNotification("Document", "Esse Documento já existe");

            // verificar se email já esta cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Esse email já existe");

            // gerar os vo's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                command.TransationCode,
                command.PaidDate,
                command.ExpiredDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address, email
            );

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, email, document, address, student, subscription, payment);

            // Checar
            if (Invalid)
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");

            // salvar as informações
            _repository.CreateSunscription(student);

            // Enviar e-mail de boas vindas
            _email.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo", "Sucesso na assinatura");

            // retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // verificar se Documento já esta cadastrado
            if (_repository.DocumentExistis(command.Document))
                AddNotification("Document", "Esse Documento já existe");

            // verificar se email já esta cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Esse email já existe");

            // gerar os vo's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
                command.CardHolderName,
                command.CardNumber,
                command.LastTransactionNumber,
                command.PaidDate,
                command.ExpiredDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address, email
            );

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, email, document, address, student, subscription, payment);

            // Checar
            if (Invalid)
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");

            // salvar as informações
            _repository.CreateSunscription(student);

            // Enviar e-mail de boas vindas
            _email.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo", "Sucesso na assinatura");

            // retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

    }
}