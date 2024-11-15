// <copyright file="Client.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff.Extensions;

    /// <summary>
    /// Клиент.
    /// </summary>
    public sealed class Client : IEquatable<Client>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Client"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="family_name">Фамилия.</param>
        /// <param name="surname">Отчество.</param>
        /// <exception cref="ArgumentNullException">Если имя или фамилия не определены <see langword="null"/>.</exception>
        public Client(string name, string family_name, string? surname = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            this.Family_name = family_name?.Trim() ?? throw new ArgumentNullException(nameof(family_name));
            this.Surname = surname.IsNullOrEmpty() ? null : surname;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Family_name { get; init; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Surname { get; init; }

        /// <summary>
        /// Рукописи.
        /// </summary>
        public ISet<Car> Cars { get; set; } = new HashSet<Car>();

        /// <summary>
        /// Добавление автомобиля.
        /// </summary>
        /// <param name="car">Автомобиль.</param>
        /// <returns><see langword="true"/> если книга была добавлена.</returns>
        public bool Add_car(Car car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            return this.Cars.Add(car);
        }

        /// <inheritdoc/>
        public bool Equals(Client? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name!.Equals(other.Name!)
                && this.Family_name!.Equals(other.Family_name!)
                && (this.Surname is null || other.Surname is null || this.Surname!.Equals(other.Surname!));
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => this.Equals(obj as Client);

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Surname is not null
                ? $"{this.Name} {this.Surname} {this.Family_name}"
                : $"{this.Name} {this.Family_name}";
        }
    }
}
