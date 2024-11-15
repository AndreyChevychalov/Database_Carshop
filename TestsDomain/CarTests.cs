// <copyright file="CarTests.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>
namespace TestsDomain
{
    using System;
    using Domain;
    using NUnit.Framework;

    [TestFixture]

    public class CarTests
    {
        [Test]
        public void Ctor_Valid_Success()
        {
            // arrange
            var manufactured = DateOnly.FromDateTime(DateTime.Today);

            // act & assert
            Assert.DoesNotThrow(
                () => { _ = new Car("Тoyota MK4", manufactured); });
        }

        [Test]
        public void Ctor_TitleNull_ThrowException()
        {
            // arrange
            var manufactured = DateOnly.FromDateTime(DateTime.Today);

            // act & assert
            Assert.Throws<ArgumentNullException>(
                () => { _ = new Car(null!, manufactured); });
        }

        [Test]
        public void Ctor_TitleEmpty_ThrowException()
        {
            // arrange
            var date = DateOnly.FromDateTime(DateTime.Today);

            // act & assert
            Assert.Throws<ArgumentNullException>(
                () => { _ = new Car(string.Empty, date); });
        }

        [Test]
        public void Equals_SameData_Equal()
        {
            // Arrange
            var manufactured = DateOnly.FromDateTime(DateTime.Today);
            var car = new Car("Тoyota MK4", manufactured);
            var other = new Car("Not Тoyota MK4", manufactured);

            // Act
            var actual = car.Equals(other);

            // Assert
            Assert.That(actual, Is.False);
        }
    }
}
