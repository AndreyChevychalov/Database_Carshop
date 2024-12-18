// <copyright file="Program.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>

namespace Demo
{
    using System;
    using Carshop;
    using DataAccessLayer;

    class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                // Создаём нового клиента
                var client = new Client("Иван Иванов", "ivanov@example.com");

                // Добавляем клиента в базу
                context.Clients.Add(client);

                // Сохраняем изменения
                context.SaveChanges();

                Console.WriteLine($"Клиент добавлен с ID: {client.Id}");
            }
        }
    }
}