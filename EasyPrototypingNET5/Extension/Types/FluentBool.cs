/*
 * <copyright file="FluentBool.cs" company="Lifeprojects.de">
 *     Class: FluentBool
 *     Copyright © Lifeprojects.de 2021
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>developer@lifeprojects.de</email>
 * <date>28.04.2021</date>
 *
 * <summary>
 * Die Klasse stellt Methoden zur bool Behandlung auf Basis einer FluentAPI (FluentBool) zur Verfügung
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
    using System.Globalization;

    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public sealed class FluentBool : FluentBool<FluentBool>
    {
        // <summary>
        /// Initializes a new instance of the <see cref="FluentBool"/> class.
        /// </summary>
        public FluentBool(bool value) : base(value)
        {
        }

        public FluentBool(bool? value) : base(value)
        {
        }
    }

    /// <summary>
    /// Gibt den Referenztyp von der Extension Klasse weiter
    /// </summary>
    /// <typeparam name="TAssertions"></typeparam>
    public class FluentBool<TAssertions> : ReferenceTypeAssertions<bool?, TAssertions> where TAssertions : FluentBool<TAssertions>
    {
        public FluentBool(bool? value) : base(value)
        {
            this.BoolValue = value;
        }

        private bool? BoolValue { get; set; }

        /// <summary>
        /// Konvertiert den Wert dieser Instanz in seine äquivalente String-Darstellung
        /// <br>Sprachabhängig in Deutsch oder englisch (entweder "Ja/Yes" oder "Nein/No").</br>
        /// </summary>
        /// <param name="">bool Value</param>
        /// <returns>string</returns>
        public string ToYesNoString()
        {
            if (CultureInfo.CurrentCulture.Name == "de-DE")
            {
                if (this.BoolValue == null)
                {
                    return "Nein";
                }
                else
                {
                    return (bool)this.BoolValue ? "Ja" : "Nein";
                }
            }
            else
            {
                if (this.BoolValue == null)
                {
                    return "Nein";
                }
                else
                {
                    return (bool)this.BoolValue ? "Yes" : "No";
                }
            }
        }

        /// <summary>
        /// Konvertiert den Wert dieser Instanz in seine äquivalente String-Darstellung
        /// <br>Sprachabhängig in Deutsch oder englisch (entweder "Ja/Yes" oder "Nein/No")</br>
        /// <br>unter Berücksichtigung der übergeben Cultur.</br>
        /// </summary>
        /// <param name="this">bool Value</param>
        /// <param name="cultureInfo">Current CultureInfo</param>
        /// <returns></returns>
        public string ToYesNoString(CultureInfo cultureInfo)
        {
            if (cultureInfo.Name == "de-DE")
            {
                if (this.BoolValue == null)
                {
                    return "Nein";
                }
                else
                {
                    return (bool)this.BoolValue ? "Ja" : "Nein";
                }
            }
            else
            {
                if (this.BoolValue == null)
                {
                    return "Nein";
                }
                else
                {
                    return (bool)this.BoolValue ? "Yes" : "No";
                }
            }
        }

        /// <summary>
        /// Gib einen bool-Wert als Integer 0/1 zurück.
        /// </summary>
        /// <param name="this">bool Value</param>
        /// <returns><b>True</b> = 1, <b>False</b> = 0</returns>
        public int ToInt()
        {
            if (this.BoolValue == null)
            {
                return 0;
            }
            else
            {
                return (bool)this.BoolValue ? 1 : 0;
            }
        }
    }
}
