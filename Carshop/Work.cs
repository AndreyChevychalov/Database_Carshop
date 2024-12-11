// <copyright file="Work.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Carshop
{
    /// <summary>
    /// Класс, представляющий работу (услугу) в автосервисе.
    /// </summary>
    public class Work
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Work"/>.
        /// Конструктор для создания новой работы.
        /// </summary>
        /// <param name="name">Название работы.</param>
        /// <param name="description">Описание работы.</param>
        /// <param name="price">Стоимость работы.</param>
        /// <param name="carId">Идентификатор автомобиля.</param>
        /// <param name="employeeId">Идентификатор работника.</param>
        /// <param name="date">Дата выполнения работы.</param>
        public Work(string name, string? description, decimal price, Guid carId, Guid employeeId, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Название работы не может быть пустым.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Стоимость работы не может быть отрицательной.");
            }

            this.Id = Guid.NewGuid();
            this.Name = name.Trim();
            this.Description = description?.Trim();
            this.Price = price;
            this.CarId = carId;
            this.EmployeeId = employeeId;
            this.Date = date;
        }

        /// <summary>
        /// Уникальный идентификатор работы.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Название работы.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Описание работы.
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Стоимость работы.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Идентификатор автомобиля, к которому относится работа.
        /// </summary>
        public Guid CarId { get; private set; }

        /// <summary>
        /// Навигационное свойство для автомобиля.
        /// </summary>
        public Car Car { get; private set; }

        /// <summary>
        /// Идентификатор работника, выполняющего работу.
        /// </summary>
        public Guid EmployeeId { get; private set; }

        /// <summary>
        /// Навигационное свойство для работника.
        /// </summary>
        public Employee Employee { get; private set; }

        /// <summary>
        /// Дата выполнения работы.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Обновляет стоимость работы.
        /// </summary>
        /// <param name="newPrice">Новая стоимость.</param>
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Стоимость работы не может быть отрицательной.");
            }

            this.Price = newPrice;
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения работы.
        /// </summary>
        /// <returns>Описание работы в виде строки.</returns>
        public override string ToString()
        {
            return $"{this.Name} ({this.Date:yyyy-MM-dd}) - {this.Price:C}";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения работ.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если работы равны.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Work other)
            {
                return false;
            }

            return this.Id == other.Id &&
                   this.Name == other.Name &&
                   this.Description == other.Description &&
                   this.Price == other.Price &&
                   this.CarId == other.CarId &&
                   this.EmployeeId == other.EmployeeId &&
                   this.Date == other.Date;
        }

        /// <summary>
        /// Переопределение метода GetHashCode.
        /// </summary>
        /// <returns>Хэш-код работы.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Name, this.Description, this.Price, this.CarId, this.EmployeeId, this.Date);
        }
    }
}