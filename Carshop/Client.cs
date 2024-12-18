// <copyright file="Client.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Carshop
{
    /// <summary>
    /// Класс, представляющий клиента.
    /// </summary>
    public class Client : Person
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Client"/>.
        /// Конструктор для создания клиента с обязательным именем.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        /// <param name="contactInfo">Контактная информация клиента.</param>
        public Client(string name, string? contactInfo = null)
            : base(name)
        {
            this.ContactInfo = contactInfo?.Trim();
        }

        /// <summary>
        /// Контактная информация клиента.
        /// </summary>
        public string? ContactInfo { get; private set; }

        /// <summary>
        /// Список автомобилей, принадлежащих клиенту.
        /// </summary>
        public ICollection<Car> Cars { get; private set; } = new List<Car>();

        /// <summary>
        /// Устанавливает новую контактную информацию для клиента.
        /// </summary>
        /// <param name="contactInfo">Новая контактная информация.</param>
        public void UpdateContactInfo(string? contactInfo)
        {
            this.ContactInfo = contactInfo?.Trim();
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения клиента.
        /// </summary>
        /// <returns>Имя и контактная информация клиента.</returns>
        public override string ToString()
        {
            return $"{this.Name} ({this.ContactInfo ?? "Контактная информация отсутствует"})";
        }
    }
}