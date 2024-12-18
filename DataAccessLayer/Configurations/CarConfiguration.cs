// <copyright file="CarConfiguration.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Carshop;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Car"/>) в таблицу БД.
    /// </summary>
    public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(car => car.Id);

            // Конфигурация свойства Make
            _ = builder.Property(car => car.Mark)
                .HasMaxLength(100)
                .IsRequired();

            // Конфигурация свойства Model
            _ = builder.Property(car => car.Model)
                .HasMaxLength(100)
                .IsRequired();

            // Конфигурация свойства Year
            _ = builder.Property(car => car.Year)
                .IsRequired();

            // Настройка связи с Client
            _ = builder.HasOne(car => car.Client)
                .WithMany(client => client.Cars)
                .HasForeignKey(car => car.ClientId)
                .OnDelete(DeleteBehavior.Cascade); // Удаление автомобиля при удалении клиента
        }
    }
}