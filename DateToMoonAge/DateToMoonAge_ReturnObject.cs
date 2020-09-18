using System;
using System.Runtime.Serialization;
using System.Text;

namespace Vishnu_UserModules
{
    /// <summary>
    /// ReturnObject für das Ergebnis des DateToMoonAge ValueModifiers.
    /// </summary>
    /// <remarks>
    /// Autor: Erik Nagel, NetEti
    ///
    /// 04.04.2020 Erik Nagel: erstellt
    /// </remarks>
    [Serializable()]
    public class DateToMoonAge_ReturnObject
    {
        /// <summary>
        /// Mondalter in Tagen.
        /// </summary>
        public int MoonAge { get; set; }

        /// <summary>
        /// Standard-Konstruktor - setzt die DefaultResultProperty auf den Default wert.
        /// </summary>
        public DateToMoonAge_ReturnObject() : this(5) { }

        /// <summary>
        /// Konstruktor - übernimmt einen String-Wert für die DefaultResultProperty.
        /// </summary>
        /// <param name="resultProperty">Int-Wert für die MoonAgeProperty</param>
        public DateToMoonAge_ReturnObject(int resultProperty)
        {
            this.MoonAge = resultProperty;
        }

        /// <summary>
        /// Deserialisierungs-Konstruktor.
        /// </summary>
        /// <param name="info">Property-Container.</param>
        /// <param name="context">Übertragungs-Kontext.</param>
        protected DateToMoonAge_ReturnObject(SerializationInfo info, StreamingContext context)
        {
            this.MoonAge = (int)info.GetValue("MoonAge", typeof(int));
        }

        /// <summary>
        /// Serialisierungs-Hilfsroutine: holt die Objekt-Properties in den Property-Container.
        /// </summary>
        /// <param name="info">Property-Container.</param>
        /// <param name="context">Serialisierungs-Kontext.</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MoonAge", this.MoonAge);
        }

        /// <summary>
        /// Überschriebene ToString()-Methode - stellt alle öffentlichen Properties
        /// als einen aufbereiteten String zur Verfügung.
        /// </summary>
        /// <returns>Alle öffentlichen Properties als ein String aufbereitet.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder(this.MoonAge.ToString());
            // str.Append(...);
            return str.ToString();
        }

        /// <summary>
        /// Vergleicht dieses Result mit einem übergebenen Result nach Inhalt.
        /// </summary>
        /// <param name="obj">Das zu vergleichende Result.</param>
        /// <returns>True, wenn das übergebene Result inhaltlich gleich diesem Result ist.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }
            if (this.ToString() != obj.ToString())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Erzeugt einen eindeutigen Hashcode für dieses Result.
        /// </summary>
        /// <returns>Hashcode (int).</returns>
        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }
    }
}
