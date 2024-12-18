// <copyright file="ApplicationDbContext.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace DataAccessLayer
{
    using System.Reflection;
    using Carshop;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Контекст доступа к данным.
    /// </summary>
    public sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicationDbContext"/>.
        /// </summary>
        public ApplicationDbContext()
            : base()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="options">Опции настройки контекста доступа к данным.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Таблица автомобилей.
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Таблица клиентов.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Таблица работников.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Таблица работ (услуг).
        /// </summary>
        public DbSet<Work> Works { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применение конфигурации через Fluent API.
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Можно дополнительно настроить связи или ограничения напрямую.
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Здесь укажите вашу строку подключения.
            optionsBuilder.UseNpgsql("Username=postgres;Password=1234;Host=localhost;Database=AutoService;");
        }
    }
}