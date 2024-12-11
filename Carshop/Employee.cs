// <copyright file="Employee.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Carshop
{
    /// <summary>
    /// Класс, представляющий работника.
    /// </summary>
    public class Employee : Person
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Employee"/>.
        /// Конструктор для создания нового работника.
        /// </summary>
        /// <param name="name">Имя работника.</param>
        /// <param name="role">Роль работника.</param>
        public Employee(string name, string role)
            : base(name)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentNullException(nameof(role), "Роль работника не может быть пустой.");
            }

            this.Role = role.Trim();
        }

        /// <summary>
        /// Роль работника (например, "Механик" или "Мастер").
        /// </summary>
        public string Role { get; private set; }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения работника.
        /// </summary>
        /// <returns>Описание работника в виде строки.</returns>
        public override string ToString()
        {
            return $"{this.Name} - {this.Role}";
        }
    }
}