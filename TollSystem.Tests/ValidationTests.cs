using Moq;
using NUnit.Framework;
using TollSystemServices;
using TollSystemServices.Enums;

namespace TollSystem.Tests
{
    public class ValidationTests
    {
        [Test]
        public void Validation_ReturnValidFunctions()
        {
            //String functions returning true
            Assert.IsTrue(Validation.CheckForValidString("ValidString"));
            Assert.IsTrue(Validation.IsValidEmail("test@email.com"));
            Assert.IsTrue(Validation.CheckStringIsDigitOnly("123456"));
            Assert.IsTrue(Validation.RandomString(5) is string);
            Assert.IsTrue(Validation.RandomString(5).Length == 5);
            Assert.IsTrue(Validation.CheckForValidString(Validation.RandomString(5)));

            //String functions should be returning false
            Assert.IsFalse(Validation.CheckForValidString("   "));
            Assert.IsFalse(Validation.CheckForValidString(""));
            Assert.IsFalse(Validation.IsValidEmail("test@emailcom"));
            Assert.IsFalse(Validation.IsValidEmail("testemail.com"));
            Assert.IsFalse(Validation.CheckStringIsDigitOnly("123456 "));
            Assert.IsFalse(Validation.CheckStringIsDigitOnly("12345a"));
        }

        [Test]
        public void Validation_ReturnValidHelperFunctions()
        {
            //Password Strength Tests
            Assert.That(Validation.CheckPasswordStrength("") == PasswordScore.Blank);
            Assert.That(Validation.CheckPasswordStrength("asd") == PasswordScore.VeryWeak);
            Assert.That(Validation.CheckPasswordStrength("asdaasdsaasdaa") == PasswordScore.Weak);
            Assert.That(Validation.CheckPasswordStrength("Password123.") == PasswordScore.Strong);

            //Hashing of the password tests
            Assert.That(Validation.HashPassword("password") != "password");
        }
    }
}