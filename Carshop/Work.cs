namespace Carshop
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс Фильм.
    /// </summary>
    public sealed class Work : IEquatable<Work>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Work"/>.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="description">Описание.</param>
        /// <param name="price">Цена фильма.</param>
        /// <param name="worker">Работник.</param>
        /// <param name="car">Автомобиль.</param>
        /// <exception cref="ArgumentNullException">Если какое-либо значение <see langword="null"/>.</exception>
        public Work(
            string name,
            string description,
            int price,
            Worker worker,
            Car car )
        {
            this.WorkId = Guid.Empty;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.Price = price > 0 ? price : throw new ArgumentOutOfRangeException(nameof(price), "Duration must be positive.");
            this.Worker = worker ?? throw new ArgumentNullException(nameof(worker));
            this.Car = car ?? throw new ArgumentNullException(nameof(car));

        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid WorkId { get; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Цена.
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// Работник.
        /// </summary>
        public Worker Worker { get; set; }

        /// <summary>
        /// Автомобиль.
        /// </summary>
        public Car Car { get; }

        /// <inheritdoc/>
        public bool Equals(Work? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name &&
                   this.Description == other.Description &&
                   this.Worker.Equals(other.Worker) &&
                   this.Car.Equals(other.Car);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Work);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Description, this.Worker, this.);
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Name} {this.Description} {this.Worker} {this.Car} {this.Price}";
    }
}