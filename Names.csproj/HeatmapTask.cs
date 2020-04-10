using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var days = new string[30];
            for (var i = 0; i < days.Length; i++)
                days[i] = (i + 2).ToString();
            var months = new string[12];
            for (var i = 0; i < months.Length; i++)
                months[i] = (i + 1).ToString();
            var intenceValues = new double[days.Length, months.Length];
            int day = 0, month = 0;            
            foreach (var name in names)
            {
                day = name.BirthDate.Day;
                month = name.BirthDate.Month;
                if (day > 1)
                    intenceValues[day - 2, month - 1]++;
            }
            return new HeatmapData(
                "Пример карты интенсивностей",
                intenceValues, 
                days, 
                months);
        }
    }
}