using System;
using PipeSharp.UnitTests.TestClasses;
using Shouldly;
using Xunit;

namespace PipeSharp.UnitTests
{
    public class PipeManager_Tap_Tests
    {
        [Fact]
        public void Should_Change_Current_Object()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Musa",
                Surname = "Demir"
            };

            string newSurName = "DEMIR";

            person.Tap(p => { p.Surname = newSurName; });
            person.Surname.ShouldBe(newSurName);
        }

        [Fact]
        public void Should_Not_Break_Pipe()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Musa",
                Surname = "Demir",
                ExtensionData = "T"
            };

            var result = person
                .Pipe(p =>
                {
                    p.Id = 1;
                    p.ExtensionData = "T";
                    return p;
                })
                .Tap(p => { p.ExtensionData += "E"; })
                .Pipe(
                    CreateAndGetStudent,
                    s =>
                    {
                        s.ShouldNotBeNull();
                        s.StudentNumber.ShouldBe($"{person.Name}.{person.Surname}");
                        return s;
                    },
                    CreateAndGetBankAccount
                )
                .Tap(ba =>
                {
                    ba.IsActive.ShouldBeFalse();
                    ba.StudentId.ShouldBe(3);
                })
                .Tap(OpenBankAccount);

            result.ShouldNotBeNull();
            result.IsActive.ShouldBeTrue();
            result.StudentId.ShouldBe(3);
            result.ExtensionData.ShouldBe("TEST");//Taps were not break pipe
        }

        private Student CreateAndGetStudent(Person p)
        {
            return new Student()
            {
                Id = 3,
                PersonId = p.Id,
                StudentNumber = $"{p.Name}.{p.Surname}",
                ExtensionData = p.ExtensionData + "S"
            };
        }

        private BankAccount CreateAndGetBankAccount(Student s)
        {
            return new BankAccount()
            {
                Id = 1,
                Balance = 100,
                StudentId = s.Id,
                ExtensionData = s.ExtensionData + "T"
            };
        }
        private void OpenBankAccount(BankAccount account)
        {
            account.IsActive = true;
        }

    }
}
