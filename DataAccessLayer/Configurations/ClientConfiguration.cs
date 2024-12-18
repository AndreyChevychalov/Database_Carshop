// <copyright file="ClientConfiguration.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Carshop;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Client"/>) в таблицу БД.
    /// </summary>
    public sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(client => client.Id);

            // Конфигурация свойства Name
            _ = builder.Property(client => client.Name)
                .HasMaxLength(200)
                .IsRequired();

            // Конфигурация свойства ContactInfo
            _ = builder.Property(client => client.ContactInfo)
                .HasMaxLength(300)
                .IsRequired(false);

            // Опционально: настройка индекса по имени клиента
            _ = builder.HasIndex(client => client.Name)
                .IsUnique(false); // Уникальность не требуется, может быть несколько клиентов с одинаковым именем
        }
    }
}