using System;
using Vishnu.Interchange;

namespace Vishnu_UserModules
{
	/// <summary>
	/// Konvertiert ein übergebenes Datum in das zugehörige Mondalter in Tagen.
	/// </summary>
	/// <remarks>
	/// File: DateToMoonAge.cs
	/// Autor: Erik Nagel, NetEti
	/// Herzlichen Dank an Mostafa Kaisoun für seine Berechnungslogik
	/// https://www.codeproject.com/script/Membership/View.aspx?mid=1961229
	/// 
	/// 04.04.2020 Erik Nagel: erstellt
	/// </remarks>
	public class DateToMoonAge : IValueModifier
    {
        /// <summary>
        /// Konvertiert ein übergebenes Datum in das zugehörige Mondalter in Tagen.
        /// </summary>
        /// <param name="toConvert">Datum als DateTime.</param>
        /// <returns>Mondalter in Tagen.</returns>
        public object ModifyValue(object toConvert)
        {
            if (toConvert is DateTime)
            {
                if (toConvert != null)
                {
                    DateTime inDateTime = (DateTime)toConvert;
					return new DateToMoonAge_ReturnObject(this.MoonAge(inDateTime.Day, inDateTime.Month, inDateTime.Year));
                }
                else
                {
                    return toConvert;
                }
            }
            else
            {
                throw new ArgumentException(String.Format("{0}: kann {1} nicht konvertieren, erwartet wird DateTime", this.GetType().Name, toConvert.ToString()));
            }
        }

		private int MoonAge(int d, int m, int y)
		{
			int j = JulianDate(d, m, y);
			//Calculate the approximate phase of the moon
			double ip = (j + 4.867) / 29.53059;
			ip = ip - Math.Floor(ip);
			//After several trials I've seen to add the following lines, 
			//which gave the result was not bad
			double ag;
			if (ip < 0.5)
				ag = ip * 29.53059 + 29.53059 / 2;
			else
				ag = ip * 29.53059 - 29.53059 / 2;
			// Moon's age in days
			ag = Math.Floor(ag) + 1;
			return Convert.ToInt32(ag);
		}

		private int JulianDate(int d, int m, int y)
		{
			int mm, yy;
			int k1, k2, k3;
			int j;

			yy = y - (int)((12 - m) / 10);
			mm = m + 9;
			if (mm >= 12)
			{
				mm = mm - 12;
			}
			k1 = (int)(365.25 * (yy + 4712));
			k2 = (int)(30.6001 * mm + 0.5);
			k3 = (int)((int)((yy / 100) + 49) * 0.75) - 38;
			// 'j' for dates in Julian calendar:
			j = k1 + k2 + d + 59;
			if (j > 2299160)
			{
				// For Gregorian calendar:
				j = j - k3;  // 'j' is the Julian date at 12h UT (Universal Time)
			}
			return j;
		}

		/*
		private void PrintAge()
		{
			string theAge = "Moon age";
			theAge = theAge + " " + ":" + " " + ag.ToString();
			if (ag == 1)
				theAge = theAge + " " + "day";
			else
				theAge = theAge + " " + "days";
			this.lblAge.Text = theAge;
		}
		*/
	}
}
