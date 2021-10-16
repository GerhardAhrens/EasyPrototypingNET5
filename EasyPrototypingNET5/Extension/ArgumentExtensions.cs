//-----------------------------------------------------------------------
// <copyright file="ArgumentExtensions.cs" company="Lifeprojects.de">
//     Class: ArgumentExtensions
//     Copyright © Lifeprojects.de 2019
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>25.07.2019</date>
//
// <summary>Extensions Class for Argument's</summary>
//-----------------------------------------------------------------------

namespace System
{
    using System.Linq.Expressions;

    public static class ArgumentExtensions
    {
        /// <summary>
        /// Überprüft das übergebene Argument in einer Methode auf Null.
        /// </summary>
        /// <typeparam name="TValue">Zu prüfender Typ</typeparam>
        /// <param name="this">Zu prüfender Wert</param>
        /// <param name="exceptionMessage">Exception Message</param>
        public static TValue IsArgumentNull<TValue>(this TValue @this, string exceptionMessage) where TValue : class
        {
            if (@this == null)
            {
                throw new ArgumentNullException(exceptionMessage);
            }
            else
            {
                return (TValue)@this;
            }
        }

        /// <summary>
        /// Überprüft das übergebene Argument in einer Methode auf Null. und übergibt einen Default-Wert
        /// </summary>
        /// <typeparam name="TValue">Zu prüfender Typ</typeparam>
        /// <param name="this">Zu prüfender Wert</param>
        /// <param name="defaultValue">Default-Wert bei Null</param>
        /// <returns></returns>
        public static TValue IsArgumentNull<TValue>(this TValue @this, string exceptionMessage, TValue defaultValue = null) where TValue : class
        {
            if (@this == null && defaultValue == null)
            {
                throw new ArgumentNullException(exceptionMessage);
            }
            else
            {
                if (defaultValue != null)
                {
                    return (TValue)defaultValue;
                }
                else
                {
                    return (TValue)@this;
                }
            }
        }

        public static TValue IsArgumentNull<TValue>(this TValue @this) where TValue : class
        {
            if (@this == null)
            {
                Type t = typeof(TValue);
                throw new ArgumentNullException($"{t.Name}");
            }
            else
            {
                return (TValue)@this;
            }
        }

        public static DateTime IsArgumentNull(this DateTime? @this, string exceptionMessage, DateTime? defaultValue = null)
        {
            if (@this == null && defaultValue == null)
            {
                throw new ArgumentNullException(exceptionMessage);
            }
            else
            {
                if (defaultValue == null)
                {
                    return new DateTime(1900, 1, 1);
                }
                else
                {
                    return (DateTime)defaultValue;
                }
            }
        }

        public static bool IsArgumentNull(this bool? @this, string exceptionMessage, bool? defaultValue = null)
        {
            if (@this == null && defaultValue == null)
            {
                throw new ArgumentNullException(exceptionMessage);
            }
            else
            {
                if (defaultValue == null)
                {
                    return default;
                }
                else
                {
                    return (bool)defaultValue;
                }
            }
        }

        public static void IsArgumentEmptyOrNull(this string @this, string paramName)
        {
            if (string.IsNullOrEmpty(@this) == true)
            {
                throw new ArgumentException(paramName);
            }
        }

        public static string IsArgumentEmptyOrNull(this string @this, string paramName, string defaultValue)
        {
            if (string.IsNullOrEmpty(@this) == true)
            {
                return defaultValue;
            }
            else
            {
                return @this;
            }
        }

        public static void IsArgumentOutOfRange<T>(this T @this, string paramName, T min, T max) where T : IComparable<T>
        {
            if (@this.CompareTo(min) < 0 || @this.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        public static void IsArgumentOutOfRange<T>(this T @this, string paramName, T min, T max, string message) where T : IComparable<T>
        {
            if (@this.CompareTo(min) < 0 || @this.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        public static void IsArgumentOutOfRange<T>(this T @this, string paramName, bool conditon, string message) where T : IComparable<T>
        {
            if (conditon == false)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        public static T IsArgumentOutOfRange<T>(this T @this, string paramName, bool conditon) where T : IComparable<T>
        {
            if (conditon == true)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
            else
            {
                return @this;
            }
        }

        public static T IsArgumentOutOfRange<T>(this T @this, string paramName, Func<bool> predicate) where T : IComparable<T>
        {
            if (predicate() == false)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
            else
            {
                return @this;
            }
        }

        public static void IsArgumentInEnum(this Enum @this, string paramName)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(paramName);
            }
            else if (Enum.IsDefined(@this.GetType(), @this) == false)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        public static Enum IsArgumentInEnum(this Enum @this, string paramName, Enum defaultValue = null)
        {
            if (@this == null)
            {
                if (defaultValue == null)
                {
                    return (Enum)defaultValue;
                }
                else
                {
                    return (Enum)defaultValue;
                }
            }
            if (Enum.IsDefined(@this.GetType(), @this) == false)
            {
                if (defaultValue == null)
                {
                    return (Enum)defaultValue;
                }
                else
                {
                    return (Enum)defaultValue;
                }
            }
            else
            {
                return (Enum)@this;
            }
        }

        public static void ThrowIfNull<T>(this T argument) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static void ThrowIfNull<T>(this T argument, string parameterName) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void ThrowIfNull<T>(this T argument, string parameterName, string message) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(parameterName, message);
            }
        }

        public static void ThrowIfNull<T>(this T argument, Expression<Func<T>> exprParameterName) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(GetName(exprParameterName));
            }
        }

        public static void ThrowIfNull<T>(this T argument, Expression<Func<T>> exprParameterName, string message) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(GetName(exprParameterName), message);
            }
        }

        private static string GetName<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return body.Member.Name;
        }
    }
}
