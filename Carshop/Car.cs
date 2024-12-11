// <copyright file="Car.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Carshop
{
    /// <summary>
    /// Класс, представляющий автомобиль.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Car"/>.
        /// Конструктор для создания нового автомобиля.
        /// </summary>
        /// <param name="mark">Марка автомобиля.</param>
        /// <param name="model">Модель автомобиля.</param>
        /// <param name="year">Год выпуска автомобиля.</param>
        /// <param name="clientId">Идентификатор клиента.</param>
        public Car(string mark, string model, int year, Guid clientId)
        {
            if (string.IsNullOrWhiteSpace(mark))
            {
                throw new ArgumentNullException(nameof(mark), "Марка автомобиля не может быть пустой.");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException(nameof(model), "Модель автомобиля не может быть пустой.");
            }

            if (year < 1900 || year > DateTime.Now.Year + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Неверный год выпуска автомобиля.");
            }

            this.Id = Guid.NewGuid();
            this.Mark = mark.Trim();
            this.Model = model.Trim();
            this.Year = year;
            this.ClientId = clientId;
        }

        /// <summary>
        /// Уникальный идентификатор автомобиля.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Марка автомобиля.
        /// </summary>
        public string Mark { get; private set; }

        /// <summary>
        /// Модель автомобиля.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Год выпуска автомобиля.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Идентификатор клиента, которому принадлежит автомобиль.
        /// </summary>
        public Guid ClientId { get; private set; }

        /// <summary>
        /// Навигационное свойство для клиента.
        /// </summary>
        public Client Client { get; private set; }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения автомобиля.
        /// </summary>
        /// <returns>Описание автомобиля в виде строки.</returns>
        public override string ToString()
        {
            return $"{this.Mark} {this.Model} ({this.Year})";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения автомобилей.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если автомобили равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Car other)
            {
                return false;
            }

            return this.Id == other.Id &&
                   this.Mark == other.Mark &&
                   this.Model == other.Model &&
                   this.Year == other.Year &&
                   this.ClientId == other.ClientId;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код автомобиля.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Mark, this.Model, this.Year, this.ClientId);
        }
    }
}