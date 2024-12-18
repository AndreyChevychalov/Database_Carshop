// <copyright file="CarTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace CarshopTest
{
    using System;
    using Carshop;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Car"/>.
    /// </summary>
    [TestFixture]
    public sealed class CarTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange
            var clientId = Guid.NewGuid();

            // Act
            var car = new Car("Toyota", "Corolla", 2020, clientId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(car.Mark, Is.EqualTo("Toyota"));
                Assert.That(car.Model, Is.EqualTo("Corolla"));
                Assert.That(car.Year, Is.EqualTo(2020));
                Assert.That(car.ClientId, Is.EqualTo(clientId));
                Assert.That(car.Id, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_NullMake_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Car(null!, "Corolla", 2020, Guid.NewGuid()));
        }

        [Test]
        public void Ctor_EmptyMake_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Car(string.Empty, "Corolla", 2020, Guid.NewGuid()));
        }

        [Test]
        public void Ctor_NullModel_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Car("Toyota", null!, 2020, Guid.NewGuid()));
        }

        [Test]
        public void Ctor_EmptyModel_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Car("Toyota", string.Empty, 2020, Guid.NewGuid()));
        }

        [Test]
        public void Ctor_InvalidYear_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Car("Toyota", "Corolla", 1899, Guid.NewGuid()));
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Car("Toyota", "Corolla", DateTime.Now.Year + 2, Guid.NewGuid()));
        }

        [Test]
        public void ToString_ValidData_ReturnsExpected()
        {
            // Arrange
            var car = new Car("Toyota", "Corolla", 2020, Guid.NewGuid());

            // Act
            var result = car.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("Toyota Corolla (2020)"));
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var car1 = new Car("Toyota", "Corolla", 2020, Guid.NewGuid());
            var car2 = new Car("Toyota", "Corolla", 2020, Guid.NewGuid());

            // Act & Assert
            Assert.That(car1, Is.Not.EqualTo(car2), "Cars with the same data but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentCars_ReturnsDifferentHashCodes()
        {
            // Arrange
            var car1 = new Car("Toyota", "Corolla", 2020, Guid.NewGuid());
            var car2 = new Car("Honda", "Civic", 2021, Guid.NewGuid());

            // Act
            var hash1 = car1.GetHashCode();
            var hash2 = car2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}