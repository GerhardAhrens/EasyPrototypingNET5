/*
 * <copyright file="FluentTypExtension.cs" company="Lifeprojects.de">
 *     Class: FluentTypExtension
 *     Copyright © Lifeprojects.de 2021
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>developer@lifeprojects.de</email>
 * <date>28.04.2021</date>
 *
 * <summary>
 * Die Klasse stellt Extesnion Methoden für eine Sammlung Typ zur Verfügung. Für diesen Typ wird dan die dazu passende Klasse aufgerufen.
 * </summary>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful,but WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.You should have received a copy of the GNU General Public License along with this program. 
 * If not, see <http://www.gnu.org/licenses/>.
*/

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

        /// <summary>
        /// Die Methode stellt Extenstion Methodes für den Typ Char zur Verfügung
        /// </summary>
        /// <param name="this">Value vom Typ</param>
        /// <returns></returns>
        public static FluentChar This(this char @this)
        {
            return new FluentChar(@this);
        }
    }
}
