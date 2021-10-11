/*
 * <copyright file="FluentChar.cs" company="Lifeprojects.de">
 *     Class: FluentChar
 *     Copyright © Lifeprojects.de 2021
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>developer@lifeprojects.de</email>
 * <date>28.04.2021</date>
 *
 * <summary>
 * Die Klasse stellt Extenstion Methoden für den Typ Char auf Basis einer FluentAPI (FluentChar) zur Verfügung
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;

    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public class FluentChar : FluentChar<FluentChar>
    {
        // <summary>
        /// Initializes a new instance of the <see cref="FluentChar"/> class.
        /// </summary>
        public FluentChar(char value) : base(value)
        {
        }
    }

    public class FluentChar<TAssertions> : ReferenceTypeAssertions<char, TAssertions> where TAssertions : FluentChar<TAssertions>
    {
        public FluentChar(char value) : base(value)
        {
            this.CharValue = value;
        }

        private char CharValue { get; set; }

        /// <summary>
        /// Die Methode prüft, ob ein Zeichen in einer Liste von Zeichen vorkommt
        /// </summary>
        /// <param name="values">Liste von Char.</param>
        /// <returns><b>True</b> = wenn das Zeichen in der Liste gefunden wurde<br/> <b>False</b> = wenn das Zeichen nicht in der Liste gefunden wurde</returns>
        public bool In(params char[] values)
        {
            return Array.IndexOf(values, this.CharValue) != -1;
        }

        /// <summary>
        /// Die Methode prüft, ob ein Zeichen <b>nicht</b> in einer Liste von Zeichen vorkommt
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns><b>True</b> = wenn das Zeichen nicht in der Liste gefunden wurde<br/> <b>False</b> = wenn das Zeichen in der Liste gefunden wurde</returns>
        public bool NotIn(params char[] values)
        {
            return Array.IndexOf(values, this.CharValue) == -1;
        }

        /// <summary>
        /// Wiederholt das angegebene Zeichen (char), n-mal.
        /// </summary>
        /// <param name="repeatCount">Anzahl der Wiederholungen des angegebenen Zeichens</param>
        /// <returns>String mit der Zeichenwiederholung</returns>
        public string Repeat(int repeatCount)
        {
            return new string(this.CharValue, repeatCount);
        }

        /// <summary>
        /// Erstellt eine Liste von Char beginnent mit dem ersten Zeichen, bis zum Zeichen das als Parameter übergeben wurde.
        /// </summary>
        /// <param name="toCharacter">Zeich als Punkt für das letzte Zeichen in der Liste</param>
        /// <returns>Liste mit Zeichen</returns>
        public IEnumerable<char> ToIEnumerable(char toCharacter)
        {
            bool reverseRequired = (this.CharValue > toCharacter);

            char first = reverseRequired ? toCharacter : this.CharValue;
            char last = reverseRequired ? this.CharValue : toCharacter;

            IEnumerable<char> result = Enumerable.Range(first, last - first + 1).Select(charCode => (char)charCode);

            if (reverseRequired)
            {
                result = result.Reverse();
            }


            return result;
        }

        /// <summary>
        /// Gibt an zu welcher Unicode Category das Zeichen gehört
        /// </summary>
        /// <returns>Enum vom Typ UnicodeCategory</returns>
        public UnicodeCategory GetUnicodeCategory()
        {
            return Char.GetUnicodeCategory(this.CharValue);
        }

        /// <summary>
        /// Gibt an ob das übergebene Zeichen aus der Kategorie Control ist
        /// </summary>
        /// <returns>bool, True wenn das übergebene Zeichen aus Kategorie Control ist</returns>
        public bool IsControl()
        {
            return char.IsControl(this.CharValue);
        }

        /// <summary>
        /// Gibt an ob das übergebene Zeichen ein Nummerisches Zeichen ist
        /// </summary>
        /// <returns>bool, True wenn das übergebene Zeichen ein Nummerisches Zeichen ist</returns>
        public bool IsDigit()
        {
            return char.IsDigit(this.CharValue);
        }

        /// <summary>
        /// Gibt an ob das übergebene Zeichen ein Nummerisches Zeichen ist
        /// </summary>
        /// <returns>bool, True wenn das übergebene Zeichen ein Nummerisches Zeichen ist</returns>
        public bool IsNumber()
        {
            return char.IsNumber(this.CharValue);
        }

        /// <summary>
        /// Gibt an ob das übergebene Zeichen aus der Kategorie Punktation ist
        /// </summary>
        /// <returns>bool, True wenn das übergebene Zeichen aus Kategorie Punktation ist</returns>
        public bool IsPunctuation()
        {
            return char.IsPunctuation(this.CharValue);
        }

        /// <summary>
        /// Gibt an ob das übergebene Zeichen aus der Kategorie Symbol ist
        /// </summary>
        /// <returns>bool, True wenn das übergebene Zeichen aus Kategorie Symbol ist</returns>
        public bool IsSymbol()
        {
            return char.IsSymbol(this.CharValue);
        }
    }
}
