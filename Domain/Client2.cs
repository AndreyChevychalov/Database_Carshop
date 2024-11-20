// <copyright file="Client2.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System;

namespace Domain
{
    public sealed class Client2 : Person
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Client2"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        public Client2(string name)
            : base(name)
        {
            this.Cars = new HashSet<Car>();
        }

        public new ISet<Car> Cars { get; }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            this.Cars.Add(car);
        }
    }
}