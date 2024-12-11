// <copyright file="WorkTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace CarshopTest
{
    using System;
    using Carshop;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="ServiceJob"/>.
    /// </summary>
    [TestFixture]
    public sealed class WorkTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange
            var carId = Guid.NewGuid();
            var employeeId = Guid.NewGuid();
            var date = DateTime.Now;

            // Act
            var work = new Work("Замена масла", "Описание работы", 1500m, carId, employeeId, date);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(work.Name, Is.EqualTo("Замена масла"));
                Assert.That(work.Description, Is.EqualTo("Описание работы"));
                Assert.That(work.Price, Is.EqualTo(1500m));
                Assert.That(work.CarId, Is.EqualTo(carId));
                Assert.That(work.EmployeeId, Is.EqualTo(employeeId));
                Assert.That(work.Date, Is.EqualTo(date));
                Assert.That(work.Id, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_NullName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Work(null!, "Описание работы", 1500m, Guid.NewGuid(), Guid.NewGuid(), DateTime.Now));
        }

        [Test]
        public void Ctor_EmptyName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Work(string.Empty, "Описание работы", 1500m, Guid.NewGuid(), Guid.NewGuid(), DateTime.Now));
        }

        [Test]
        public void Ctor_NegativePrice_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Work("Замена масла", "Описание работы", -100m, Guid.NewGuid(), Guid.NewGuid(), DateTime.Now));
        }

        [Test]
        public void UpdatePrice_ValidPrice_Success()
        {
            // Arrange
            var serviceJob = new Work("Замена масла", "Описание работы", 1500m, Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);

            // Act
            serviceJob.UpdatePrice(2000m);

            // Assert
            Assert.That(serviceJob.Price, Is.EqualTo(2000m));
        }

        [Test]
        public void UpdatePrice_NegativePrice_ThrowsException()
        {
            // Arrange
            var serviceJob = new Work("Замена масла", "Описание работы", 1500m, Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => serviceJob.UpdatePrice(-100m));
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var carId = Guid.NewGuid();
            var employeeId = Guid.NewGuid();
            var date = DateTime.Now;

            var serviceJob1 = new Work("Замена масла", "Описание работы", 1500m, carId, employeeId, date);
            var serviceJob2 = new Work("Замена масла", "Описание работы", 1500m, carId, employeeId, date);

            // Act & Assert
            Assert.That(serviceJob1.Equals(serviceJob2), Is.False, "ServiceJobs with the same data but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentServiceJobs_ReturnsDifferentHashCodes()
        {
            // Arrange
            var carId = Guid.NewGuid();
            var employeeId = Guid.NewGuid();
            var date = DateTime.Now;

            var serviceJob1 = new Work("Замена масла", "Описание работы", 1500m, carId, employeeId, date);
            var serviceJob2 = new Work("Ремонт двигателя", "Описание работы", 5000m, carId, employeeId, date);

            // Act
            var hash1 = serviceJob1.GetHashCode();
            var hash2 = serviceJob2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}