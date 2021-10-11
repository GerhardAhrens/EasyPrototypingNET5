/*
 * <copyright file="ReferenceTypeAssertions.cs" company="Lifeprojects.de">
 *     Class: ReferenceTypeAssertions
 *     Copyright © Lifeprojects.de 2021
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>developer@lifeprojects.de</email>
 * <date>28.04.2021</date>
 *
 * <summary>
 * Basisklasse für FluentAPI Type Extenstion
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
    public abstract class ReferenceTypeAssertions<TSubject, TAssertions> where TAssertions : ReferenceTypeAssertions<TSubject, TAssertions>
    {
        protected ReferenceTypeAssertions(TSubject subject)
        {
            this.Subject = subject;
        }

        /// <summary>
        /// Gets the object which value is being asserted.
        /// </summary>
        public TSubject Subject { get; }
    }
}
