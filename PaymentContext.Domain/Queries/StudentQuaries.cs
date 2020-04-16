using System;
using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Quaries
{
    public sealed class StudentQuaries
    {
        public static Expression<Func<Student, bool>> GetStudentInfo(string document)
        {            
            return x => x.Document.Number == document;
        }
    }
}