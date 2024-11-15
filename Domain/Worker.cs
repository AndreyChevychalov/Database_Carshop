// <copyright file="Worker.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Работники.
    /// </summary>
    public sealed class Worker : IEquatable<Worker>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Worker"/>.
        /// </summary>
        /// <param name="name"> Имя работника.</param>
        /// <param name="job"> Проффесия работника.</param>
        /// <exception cref="ArgumentNullException">Если название <see langword="null"/>. </exception>
        public Worker(string name, string job)
        {
            this.Id = Guid.NewGuid();
            this.Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            this.Job = job?.Trim() ?? throw new ArgumentNullException(nameof(job));
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя работника.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Проффесия работника.
        /// </summary>
        public string Job { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object? other)
        {
            return other is Worker worker && this.Equals(worker);
        }

        /// <inheritdoc/>
        public bool Equals(Worker? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name.Equals(other.Name)
            && this.Job.Equals(other.Job);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => 
            $"{this.Name} {string.Join(",", this.Job)}";
    }
}
