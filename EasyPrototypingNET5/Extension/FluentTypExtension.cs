//-----------------------------------------------------------------------
// <copyright file="StringFluentExtension.cs" company="Lifeprojects.de">
//     Class: StringFluentExtension
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>28.04.2021</date>
//
// <summary>
// Die Klasse stellt Extesnion Methoden für eine Sammlung Typ zur Verfügung.
// Für diesen Typ wird dan die dazu passende Klasse aufgerufen.
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.FluentAPI
{
    using System.Diagnostics;

    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class FluentTypExtension
    {
        /// <summary>
        /// Die Methode stellt Extenstion Methodes für den Typ Bool zur Verfügung
        /// </summary>
        /// <param name="this">Value vom Typ</param>
        /// <returns></returns>
        public static FluentBool This(this bool @this)
        {
            return new FluentBool(@this);
        }

        public static FluentBool This(this bool? @this)
        {
            return new FluentBool(@this);
        }
    }
}
