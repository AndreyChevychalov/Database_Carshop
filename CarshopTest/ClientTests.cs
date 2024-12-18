// <copyright file="ClientTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace CarshopTest
{
    using System;
    using Carshop;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Client"/>.
    /// </summary>
    [TestFixture]
    public sealed class ClientTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange & Act
            var client = new Client("Иван Иванов", "ivanov@example.com");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(client.Name, Is.EqualTo("Иван Иванов"));
                Assert.That(client.ContactInfo, Is.EqualTo("ivanov@example.com"));
                Assert.That(client.Id, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_NullName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Client(null!));
        }

        [Test]
        public void Ctor_EmptyName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Client(string.Empty));
        }

        [TestCase("Иван Иванов", null, "Иван Иванов (Контактная информация отсутствует)")]
        [TestCase("Мария Смирнова", "maria@example.com", "Мария Смирнова (maria@example.com)")]
        public void ToString_ValidData_ReturnsExpected(string name, string? contact, string expected)
        {
            // Arrange
            var client = new Client(name, contact);

            // Act
            var actual = client.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateContactInfo_ValidData_Success()
        {
            // Arrange
            var client = new Client("Иван Иванов", "ivanov@example.com");

            // Act
            client.UpdateContactInfo("new_email@example.com");

            // Assert
            Assert.That(client.ContactInfo, Is.EqualTo("new_email@example.com"));
        }

        [Test]
        public void UpdateContactInfo_NullData_SetsNull()
        {
            // Arrange
            var client = new Client("Иван Иванов", "ivanov@example.com");

            // Act
            client.UpdateContactInfo(null);

            // Assert
            Assert.That(client.ContactInfo, Is.Null);
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var client1 = new Client("Иван Иванов", "ivanov@example.com");
            var client2 = new Client("Иван Иванов", "ivanov@example.com");

            // Act & Assert
            Assert.That(client1, Is.Not.EqualTo(client2), "Clients with the same data but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentClients_ReturnsDifferentHashCodes()
        {
            // Arrange
            var client1 = new Client("Иван Иванов", "ivanov@example.com");
            var client2 = new Client("Мария Смирнова", "maria@example.com");

            // Act
            var hash1 = client1.GetHashCode();
            var hash2 = client2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}