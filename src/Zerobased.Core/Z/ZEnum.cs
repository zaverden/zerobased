﻿using System;
using System.Linq;
using System.Reflection;

namespace Zerobased
{
    /// <summary>
    ///     Class represent methods that wrap some of <see cref="Enum"/> static methods to their generic versions.
    /// </summary>
    public static class ZEnum
    {
        /// <summary>
        ///     Generic wrapper for <see cref="Enum.Parse(Type, string, bool)"/> method.
        ///     Converts the string representation of the name or numeric value of one or
        ///     more enumerated constants to an equivalent enumerated object. A parameter
        ///     specifies whether the operation is case-insensitive.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration type</typeparam>
        /// <param name="value">A string containing the name or value to convert.</param>
        /// <param name="ignoreCase">TRUE to ignore case; FALSE to regard case. FALSE by default.</param>
        /// <returns>An object of type <typeparamref name="TEnum"/> whose value is represented by <paramref name="value"/>.</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="value"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     <typeparamref name="TEnum"/> is not enum.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        ///     <paramref name="value"/> is either an empty string (<see cref="string.Empty"/>)
        ///     or only contains white space.
        ///     -or- <paramref name="value"/> is a name, but not one of the named
        ///     constants defined for the enumeration.
        /// </exception>
        /// <exception cref="System.OverflowException">value is outside the range of the underlying type of <typeparamref name="TEnum"/>.</exception>
        public static TEnum Parse<TEnum>(string value, bool ignoreCase = false) where TEnum : struct
        {
            CheckTypeParameter<TEnum>();
            var enumValue = (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
            return enumValue;
        }

        /// <summary>
        ///    Generic wrapper for <see cref="Enum.GetNames(Type)"/> method.
        ///    Retrieves an array of the names of the constants in a specified enumeration.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration type.</typeparam>
        /// <returns>A string array of the names of the constants in <typeparamref name="TEnum"/>.</returns>
        /// <exception cref="NotSupportedException">
        ///     <typeparamref name="TEnum"/> is not enum.
        /// </exception>
        public static string[] GetNames<TEnum>() where TEnum : struct
        {
            CheckTypeParameter<TEnum>();
            string[] names = Enum.GetNames(typeof(TEnum));
            return names;
        }

        /// <summary>
        ///     Generic wrapper for <see cref="Enum.IsDefined(Type, object)"/> method.
        ///     Returns an indication whether a constant with a specified value exists in
        ///     a specified enumeration.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration type</typeparam>
        /// <param name="value">The value in <typeparamref name="TEnum"/>.</param>
        /// <returns>TRUE if a constant in <typeparamref name="TEnum"/> has a value equal to <paramref name="value"/>; otherwise, FALSE.</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="value"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     <typeparamref name="TEnum"/> is not enum.
        /// </exception>
        public static bool IsDefined<TEnum>(int value) where TEnum : struct
        {
            CheckTypeParameter<TEnum>();
            bool isDefined = Enum.IsDefined(typeof(TEnum), value);
            return isDefined;
        }

        /// <summary>
        ///     Generic wrapper for <see cref="Enum.GetValues(Type)"/> method.
        ///     Retrieves an array of the values of the constants in a specified enumeration.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration type.</typeparam>
        /// <returns>An array that contains the values of the constants in <typeparamref name="TEnum"/>.</returns>
        /// <exception cref="System.InvalidOperationException">
        ///     The method is invoked by reflection in a reflection-only context, -or- enumType
        ///     is a type from an assembly loaded in a reflection-only context.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     <typeparamref name="TEnum"/> is not enum.
        /// </exception>
        public static TEnum[] GetValues<TEnum>() where TEnum : struct
        {
            CheckTypeParameter<TEnum>();
            TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
            return values;
        }

        /// <summary>
        ///     Throw <see cref="NotSupportedException"/> exception if <typeparamref name="TEnum"/> is not enum.
        /// </summary>
        /// <typeparam name="TEnum">Type to check.</typeparam>
        /// <exception cref="NotSupportedException">
        ///     <typeparamref name="TEnum"/> is not enum.
        /// </exception>
        public static void CheckTypeParameter<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).GetTypeInfo().IsEnum)
            {
                throw new NotSupportedException("Generic parameter must be enum.");
            }
        }
    }
}
