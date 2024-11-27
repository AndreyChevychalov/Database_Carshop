// <copyright file="StringExtensions.cs" company="Чевычалов А.В.">
// Copyright (c) Чевычалов А.В.. All rights reserved.
// </copyright>
namespace Staff.Extensions
{
    /// <summary>
    /// Класс <see cref="StringExtentions"/>.
    /// Коллекция методов расширений для типа <see cref="string"/>.
    /// </summary>
#pragma warning disable SA1649 // File name should match first type name
    public static class StringExtentions
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <inheritdoc cref="string.IsNullOrEmpty"/>
        public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Убирает ведущие и замыкающие пробелы. В случае получения пустой строки возвращает <see langword="null"/>.
        /// </summary>
        /// <param name="value"> Целевая строка. </param>
        /// <returns>
        /// Целевая строка без ведущих и замыкающих пробелов
        /// или <see langword="null"/> в случае пустой строки (<see cref="string.Empty"/>).
        /// </returns>
        public static string? TrimOrNull(this string? value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty()
                ? null
                : trimmed!;
        }
    }
}