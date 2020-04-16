using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExistis(string document);
        bool EmailExists(string email);
        void CreateSunscription(Student student);
    }
}