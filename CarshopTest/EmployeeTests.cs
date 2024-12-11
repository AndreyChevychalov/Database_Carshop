// <copyright file="EmployeeTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace CarshopTest
{
    using System;
    using Carshop;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Employee"/>.
    /// </summary>
    [TestFixture]
    public sealed class EmployeeTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange & Act
            var employee = new Employee("Алексей Павлов", "Механик");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(employee.Name, Is.EqualTo("Алексей Павлов"));
                Assert.That(employee.Role, Is.EqualTo("Механик"));
                Assert.That(employee.Id, Is.Not.EqualTo(Guid.Empty));
            });
        }

        [Test]
        public void Ctor_NullName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Employee(null!, "Механик"));
        }

        [Test]
        public void Ctor_EmptyName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Employee(string.Empty, "Механик"));
        }

        [Test]
        public void Ctor_NullRole_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Employee("Алексей Павлов", null!));
        }

        [Test]
        public void Ctor_EmptyRole_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Employee("Алексей Павлов", string.Empty));
        }

        [Test]
        public void ToString_ValidData_ReturnsExpected()
        {
            // Arrange
            var employee = new Employee("Алексей Павлов", "Механик");

            // Act
            var result = employee.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("Алексей Павлов - Механик"));
        }

        [Test]
        public void Equals_SameData_ReturnsFalse()
        {
            // Arrange
            var employee1 = new Employee("Алексей Павлов", "Механик");
            var employee2 = new Employee("Алексей Павлов", "Механик");

            // Act & Assert
            Assert.That(employee1.Equals(employee2), Is.False, "Employees with the same data but different GUIDs should not be equal.");
        }

        [Test]
        public void GetHashCode_DifferentEmployees_ReturnsDifferentHashCodes()
        {
            // Arrange
            var employee1 = new Employee("Алексей Павлов", "Механик");
            var employee2 = new Employee("Мария Смирнова", "Мастер");

            // Act
            var hash1 = employee1.GetHashCode();
            var hash2 = employee2.GetHashCode();

            // Assert
            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }
}