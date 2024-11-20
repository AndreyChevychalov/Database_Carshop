// <copyright file="Person.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Абстрактный класс Person, представляющий человека.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        public Person(string name)
        {
            this.PersonId = Guid.Empty;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid PersonId { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Список автомобилей.
        /// </summary>
        public ISet<Car> Cars { get; } = new HashSet<Car>();
    }
}