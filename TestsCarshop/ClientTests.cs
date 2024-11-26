// <copyright file="ClientTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace TestsCarshop
{
    using System;
    using Carshop;
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
                () => _ = new Client(name: "Зимин Иван Алексеевич", contact_info: "+1 123 123 12 12"));
        }

        [Test]
        public void Ctor_NullSurNameData_Success()
        {
            Assert.DoesNotThrow(
                () => _ = new Client(name: "Зимин Иван Алексеевич", contact_info: "123"));
        }

        [TestCase(null, "123")]
        [TestCase("Зимин Иван Алексеевич", null)]
        [TestCase(null, null)]
        public void Ctor_WrongData_ThrowException(string? name, string? contact_info)
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new Client(name: name!, contact_info: contact_info!));
        }

        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var client = new Client(name: "Зимин Иван Алексеевич", contact_info: "1 123 123 12 12");
            var expected = "Зимин Иван Алексеевич 1 123 123 12 12";

            // Act
            var actual = client.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_SameData_Equal()
        {
            // Arrange
            var client1 = new Client(name: "Зимин Иван Алексеевич", contact_info: "1 123 123");
            var client2 = new Client(name: "Зимин Иван Алексеевич", contact_info: "1 123 123");

            // Act & Assert
            Assert.That(client1, Is.EqualTo(client2));
        }

        [Test]
        public void Equals_SameDataDifferentContact_Info_NotEqual()
        {
            // Arrange
            var client1 = new Client(name: "Зимин Иван Алексеевич", contact_info: "1 123 123");
            var client2 = new Client(name: "Зимин Иван Алексеевич", contact_info: "3 321 321");

            // Act & Assert
            Assert.That(client1, Is.Not.EqualTo(client2));
        }

        [Test]
        public void Equals_SameDataDifferentName()
        {
            // Arrange
            var client1 = new Client(name: "Зимин Иван Алексеевич", contact_info: "1 123 123");
            var client2 = new Client(name: "Иванов Николай Петрович", contact_info: "1 123 123");

            // Act & Assert
            Assert.That(client1, Is.Not.EqualTo(client2));
        }
    }
}
