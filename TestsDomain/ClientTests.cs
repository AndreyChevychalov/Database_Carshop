// <copyright file="ClientTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace TestsDomain
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Класс тестов на <see cref="Client"/>.
    /// </summary>
    [TestFixture]
    public class ClientTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(
                () => _ = new Client(name: "Иван", family_name: "Зимин", surname: "Алексеевич"));
        }

        [Test]
        public void Ctor_NullSurNameData_Success()
        {
            Assert.DoesNotThrow(
                () => _ = new Client(name: "Иван", family_name: "Зимин"));
        }

        [TestCase(null, "Зимин")]
        [TestCase("Иван", null)]
        [TestCase(null, null)]
        public void Ctor_WrongData_ThrowException(string? firstName, string? familyName)
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new Client(name: firstName!, family_name: familyName!));
        }

        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var author = new Client(name: "Иван", family_name: "Зимин", surname: "Алексеевич");
            var expected = "Иван Алексеевич Зимин";

            // Act
            var actual = author.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("Алексеевич", "Алексеевич")]
        [TestCase(null, "Алексеевич")]
        [TestCase("Алексеевич", null)]
        public void Equals_SameData_Equal(string? surName1, string? surName2)
        {
            // Arrange
            var author1 = new Client(name: "Иван", family_name: "Зимин", surname: surName1);
            var author2 = new Client(name: "Иван", family_name: "Зимин", surname: surName2);

            // Act & Assert
            Assert.That(author1, Is.EqualTo(author2));
        }
    }
}
