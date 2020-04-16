using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Fakes
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSunscription(Student student)
        {
            throw new System.NotImplementedException();
        }

        public bool DocumentExistis(string document)
        {
            if (document == "38184776047")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
             if (email == "suporte@fyr3.com.br")
                return false;
                
            return true;
        }
    }
}