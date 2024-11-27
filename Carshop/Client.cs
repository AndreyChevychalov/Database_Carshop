// <copyright file="Client.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Carshop
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
        /// <param name="contact_info">Контактная информация.</param>
        /// <exception cref="ArgumentNullException">Если имя или контактная информация не определены <see langword="null"/>.</exception>
        public Client(string name, string contact_info)
        {
            this.Id = Guid.NewGuid();
            this.Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            this.Contact_info = contact_info?.Trim() ?? throw new ArgumentNullException(nameof(contact_info));
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
        /// Контактная информация.
        /// </summary>
        public string Contact_info { get; init; }

        /// <summary>
        /// Автомобили.
        /// </summary>
        public ISet<Car> Cars { get; set; } = new HashSet<Car>();

        /// <summary>
        /// Добавление автомобиля.
        /// </summary>
        /// <param name="car">Автомобиль.</param>
        /// <returns><see langword="true"/> если автомобиль был добавлен.</returns>
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
                && this.Contact_info!.Equals(other.Contact_info!);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => this.Equals(obj as Client);

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Name} {string.Join(",", this.Contact_info)}";
    }
}
