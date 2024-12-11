// <copyright file="Person.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Carshop
{
    /// <summary>
    /// Абстрактный класс, представляющий человека.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/>.
        /// Конструктор для создания нового человека с обязательным именем.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        protected Person(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Имя человека не может быть пустым.");
            }

            this.Id = Guid.NewGuid();
            this.Name = name.Trim();
        }

        /// <summary>
        /// Уникальный идентификатор человека.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Имя человека.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения человека.
        /// </summary>
        /// <returns>Имя человека.</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения людей.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если люди равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Person other)
            {
                return false;
            }

            return this.Id == other.Id &&
                  this.Name == other.Name;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код человека.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Name);
        }
    }
}