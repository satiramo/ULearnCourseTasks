using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var days = new string[31];
            for (var i = 0; i < days.Length; i++)
                days[i] = (i + 1).ToString();
            var birthValues = new double[31];
            foreach (var man in names)
            {
                if (man.Name==name)
                {
                    birthValues[man.BirthDate.Day - 1]++;
                }
            }
            birthValues[0] = 0;

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                days,
                birthValues);
        }
    }
}