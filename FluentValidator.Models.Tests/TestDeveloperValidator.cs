using System;
using System.Linq;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using FluentValidator.Models.FluentValidators;
using NUnit.Framework;

namespace FluentValidator.Models.Tests
{
    [TestFixture]
    public class TestDeveloperValidator
    {
        private DeveloperValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new DeveloperValidator();
        }

        [TearDown]
        public void TearDown()
        {
            _validator = null;
        }

        [Test]
        public void Should_have_error_when_val_is_Null()
        {
            // Arrange 
            var model = new Developer { FirstName = null };
            // Act
            var result = _validator.Validate(model);
            // Assert
            Assert.That(result.Errors.Any(o => o.PropertyName == "FirstName"));
        }

        [Test]
        public void Should_have_InvalidModel_when_val_is_Null()
        {
            // Arrange 
            var model = new Developer { FirstName = null };
            // Act
            // Assert
            _validator.Validate(model).IsValid.Should().BeFalse();
        }

        [Test]
        public void Given_FirstNameIsEmpty_When_Validating_Then_Error()
        {
            _validator.ShouldHaveValidationErrorFor(d => d.FirstName, string.Empty);
        }

        [Test]
        public void Given_FirstNameIsToLong_When_Validating_Then_Error()
        {
            _validator.ShouldHaveValidationErrorFor(d => d.FirstName,
                "Random_Long_Test_More_Than_25_Characters");
        }

        [Test]
        public void Should_have_error_when_Name_is_null()
        {
            // Arrange 
            var model = new Developer { FirstName = null };
            // Act
            var result = _validator.TestValidate(model);
            // Assert
            result.ShouldHaveValidationErrorFor(d => d.FirstName);
        }

        [Test]
        public void Should_not_have_error_when_name_is_specified()
        {
            // Arrange 
            var model = new Developer { FirstName = "Tester" };
            // Act
            var result = _validator.TestValidate(model);
            // Assert
            result.ShouldNotHaveValidationErrorFor(d => d.FirstName);
        }

        [Test]
        public void ShouldNotHaveValidationErrorsWhenValidModelIsSupplied()
        {
            // Arrange
            var model = new Developer
            {
                FirstName = "firstname",
                LastName = "lastname",
                DateOfBirth = new DateTime(1990, 02, 02),
                Email = "lindo1@ymail.com",
                Experience = 6
            };
            // Act
            var validationResult = _validator.Validate(model);
            // Assert
            validationResult.IsValid.Should().BeTrue();
        }
    }
}
