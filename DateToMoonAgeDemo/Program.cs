using Vishnu_UserModules;

namespace DateToMoonAgeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateToMoonAge dateToMoonAge = new DateToMoonAge();
            // Console.WriteLine("{0} -> {1}", DateTime.Now, dateToMoonAge.ModifyValue(DateTime.Now));

            DateTime myDate;
            for (int i = 1; i < 32; i++)
            {
                string dateString = String.Format($"{i:D2}.05.2020");
                myDate = DateTime.ParseExact(dateString, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                string? moonAgeString = dateToMoonAge.ModifyValue(myDate)?.ToString();
                int moonPhase = Convert.ToInt32(moonAgeString) / 4 + 1;

                Console.WriteLine("{0} -> {1}: {2}", myDate, moonAgeString, moonPhase);
            }
        }
    }
}