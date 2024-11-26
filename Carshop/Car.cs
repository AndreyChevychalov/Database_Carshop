// <copyright file="Car.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Carshop
{
    using System;
    using Staff.Extensions;

    /// <summary>
    /// Класс Автомобиль.
    /// </summary>
    public sealed class Car : IEquatable<Car>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Car"/>.
        /// </summary>
        /// <param name="mark"> Марка.</param>
        /// <param name="manufactured"> Дата изготовления. </param>
        /// <param name="Client">Клиенты.</param>
        /// <exception cref="ArgumentNullException"> Если Марка <see langword="null"/>.</exception>
        public Car(string mark, DateOnly manufactured, ISet<Client>? Client = null)
        {
            this.Id = Guid.Empty;
            this.Mark = mark.TrimOrNull() ?? throw new ArgumentNullException(nameof(mark));
            this.Manufactured = manufactured;
            if (Client != null)
            {
                foreach (var client in Client)
                {
                    this.Clients.Add(client);
                    client.Add_car(this);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Car"/>.
        /// </summary>
        /// <param name="mark"> Марка.</param>
        /// <param name="manufactured"> Дата изготовления. </param>
        /// <param name="clients">Клиенты.</param>
        /// <exception cref="ArgumentNullException"> Если Марка <see langword="null"/>.</exception>
        public Car(string mark, DateOnly manufactured, params Client[] clients)
            : this(mark, manufactured, new HashSet<Client>(clients))
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Марка.
        /// </summary>
        public string Mark { get; init; }

        /// <summary>
        /// Список авторов.
        /// </summary>
        public ISet<Client> Clients { get; init; } = new HashSet<Client>();

        /// <summary>
        /// Дата изготовления.
        /// </summary>
        public DateOnly Manufactured { get; init; }

        /// <inheritdoc/>
        public bool Equals(Car? other)
        {
            if (ReferenceEquals(null, other) && other is null)
            {
                return false;
            }

            return this.Mark.Equals(other.Mark)
                && this.Clients.SetEquals(other.Clients);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) =>
            this.Equals(obj as Car);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            this.Mark.GetHashCode() * this.Clients.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Mark} {string.Join(",", this.Clients)}";
    }
}
