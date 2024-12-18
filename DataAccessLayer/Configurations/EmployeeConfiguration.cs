// <copyright file="EmployeeConfiguration.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Carshop;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Employee"/>) в таблицу БД.
    /// </summary>
    public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Установка первичного ключа
            _ = builder.HasKey(employee => employee.Id);

            // Конфигурация свойства Name
            _ = builder.Property(employee => employee.Name)
                .HasMaxLength(200)
                .IsRequired();

            // Конфигурация свойства Role
            _ = builder.Property(employee => employee.Role)
                .HasMaxLength(100)
                .IsRequired();

            // Опционально: Добавление индекса на имя и роль
            _ = builder.HasIndex(employee => new { employee.Name, employee.Role })
                .IsUnique(); // Уникальная пара "Имя + Роль"
        }
    }
}