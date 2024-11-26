// <copyright file="WorkerTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace TestsCarshop
{
    using System;
    using Carshop;
    using NUnit.Framework;

    /// <summary>
    /// Класс тестов на <see cref="Worker"/>.
    /// </summary>
    [TestFixture]
    public class WorkerTests
    {
        [Test]
        public void Ctor_ValdData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Worker("Иванов И.И.", "Механик"));
        }

        [Test]
        public void Ctor_NullName_ThrowException()
        {
            _ = Assert.Throws<ArgumentNullException>(() => _ = new Worker(null!, null!));
        }

        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var worker = new Worker("Иванов И.И.", "Механик");
            var expected = "Иванов И.И. Механик";

            // Act
            var actual = worker.ToString();

            // Assert
            Assert.That(expected, Is.Not.Null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Equals_SameData_Equal()
        {
            // Arrange
            var worker = new Worker("Иванов И.И.", "Механик");
            var other = new Worker("Не Иванов И.И.", "Не Механик");

            // Act
            var actual = worker.Equals(other);

            // Assert
            Assert.That(actual, Is.False);
        }
    }
}