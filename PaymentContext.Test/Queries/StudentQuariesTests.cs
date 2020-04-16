using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Quaries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test
{
    [TestClass]
    public class StudentQuariesTests
    {
        // Red, Green, Refactor
        private IList<Student> _students = new List<Student>();

        public StudentQuariesTests()
        {
            for (var i = 0; i < 10; i++)
            {
                  _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1234567891" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@balta.io")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentNotExists()
        {
            var exp = StudentQuaries.GetStudentInfo("00281163212");
            var studant = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studant);
        }

        [TestMethod]
        public void ShouldReturnStudentNullWhenDocumentExists()
        {
            var exp = StudentQuaries.GetStudentInfo("12345678910");
            var studant = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studant);
        }
    }
}
