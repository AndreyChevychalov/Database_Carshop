// <copyright file="WorkConfiguration.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Carshop;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Work"/>) в таблицу БД.
    /// </summary>
    public sealed class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(work => work.Id);

            // Конфигурация свойства Name
            _ = builder.Property(work => work.Name)
                .HasMaxLength(200)
                .IsRequired();

            // Конфигурация свойства Description
            _ = builder.Property(work => work.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            // Конфигурация свойства Price
            _ = builder.Property(work => work.Price)
                .HasColumnType("decimal(18,2)") // Для финансовых значений
                .IsRequired();

            // Конфигурация свойства Date
            _ = builder.Property(work => work.Date)
                .IsRequired();

            // Настройка связи с Car
            _ = builder.HasOne(work => work.Car)
                .WithMany()
                .HasForeignKey(work => work.CarId)
                .OnDelete(DeleteBehavior.Cascade); // Удаление работы при удалении автомобиля

            // Настройка связи с Employee
            _ = builder.HasOne(work => work.Employee)
                .WithMany()
                .HasForeignKey(work => work.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // Удаление работы при удалении работника
        }
    }
}