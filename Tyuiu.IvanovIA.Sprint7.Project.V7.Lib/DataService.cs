using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tyuiu.IvanovIA.Sprint7.Project.V7.Lib
{
    public class DataService_IvanovIA
    {
        // Функция 1: Загрузка данных из CSV
        public List<ApartmentModel_IvanovIA> LoadFromCSV_IvanovIA(string path)
        {
            List<ApartmentModel_IvanovIA> dataList = new List<ApartmentModel_IvanovIA>();

            try
            {
                string[] allLines = File.ReadAllLines(path);

                for (int i = 1; i < allLines.Length; i++)
                {
                    string line = allLines[i];

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(',');

                    if (parts.Length >= 11)
                    {
                        ApartmentModel_IvanovIA item = new ApartmentModel_IvanovIA();

                        item.EntranceNumber = int.Parse(parts[0]);
                        item.ApartmentNumber = int.Parse(parts[1]);
                        item.TotalArea = decimal.Parse(parts[2], CultureInfo.InvariantCulture);
                        item.LivingArea = decimal.Parse(parts[3], CultureInfo.InvariantCulture);
                        item.RoomsCount = int.Parse(parts[4]);
                        item.TenantLastName = parts[5];
                        item.RegistrationDate = DateTime.Parse(parts[6]);
                        item.FamilyMembers = int.Parse(parts[7]);
                        item.ChildrenCount = int.Parse(parts[8]);
                        item.HasDebt = bool.Parse(parts[9]);
                        item.Notes = parts[10];

                        dataList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки файла: {ex.Message}");
            }

            return dataList;
        }

        // Функция 2: Сохранение в CSV
        public void SaveToCSV_IvanovIA(List<ApartmentModel_IvanovIA> data, string path)
        {
            try
            {
                List<string> lines = new List<string>();

                lines.Add("EntranceNumber,ApartmentNumber,TotalArea,LivingArea,RoomsCount,TenantLastName,RegistrationDate,FamilyMembers,ChildrenCount,HasDebt,Notes");

                foreach (var item in data)
                {
                    string line = $"{item.EntranceNumber},{item.ApartmentNumber},{item.TotalArea.ToString(CultureInfo.InvariantCulture)},{item.LivingArea.ToString(CultureInfo.InvariantCulture)},{item.RoomsCount},{item.TenantLastName},{item.RegistrationDate:yyyy-MM-dd},{item.FamilyMembers},{item.ChildrenCount},{item.HasDebt},{item.Notes}";
                    lines.Add(line);
                }

                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения: {ex.Message}");
            }
        }

        // Функция 3: Поиск по фамилии
        public List<ApartmentModel_IvanovIA> SearchByLastName_IvanovIA(List<ApartmentModel_IvanovIA> data, string lastName)
        {
            List<ApartmentModel_IvanovIA> resultList = new List<ApartmentModel_IvanovIA>();

            foreach (var item in data)
            {
                if (item.TenantLastName.IndexOf(lastName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultList.Add(item);
                }
            }

            return resultList;
        }

        // Функция 4: Фильтрация по задолженности
        public List<ApartmentModel_IvanovIA> FilterByDebt_IvanovIA(List<ApartmentModel_IvanovIA> data, bool hasDebt)
        {
            List<ApartmentModel_IvanovIA> resultList = new List<ApartmentModel_IvanovIA>();

            foreach (var item in data)
            {
                if (item.HasDebt == hasDebt)
                {
                    resultList.Add(item);
                }
            }

            return resultList;
        }

        // Функция 5: Сортировка по номеру квартиры
        public List<ApartmentModel_IvanovIA> SortByApartmentNumber_IvanovIA(List<ApartmentModel_IvanovIA> data, bool ascending)
        {
            if (ascending)
            {
                return data.OrderBy(x => x.ApartmentNumber).ToList();
            }
            else
            {
                return data.OrderByDescending(x => x.ApartmentNumber).ToList();
            }
        }

        // Функция 6: Подсчет квартир
        public int CountApartments_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            return data.Count;
        }

        // Функция 7: Сумма площади
        public decimal SumTotalArea_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            decimal sum = 0;

            foreach (var item in data)
            {
                sum += item.TotalArea;
            }

            return sum;
        }

        // Функция 8: Средняя площадь
        public decimal AverageTotalArea_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            if (data.Count == 0)
                return 0;

            decimal sum = SumTotalArea_IvanovIA(data);
            return Math.Round(sum / data.Count, 2);
        }

        // Функция 9: Минимальная площадь
        public decimal MinTotalArea_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            if (data.Count == 0)
                return 0;

            decimal minValue = data[0].TotalArea;

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i].TotalArea < minValue)
                {
                    minValue = data[i].TotalArea;
                }
            }

            return minValue;
        }

        // Функция 10: Максимальная площадь
        public decimal MaxTotalArea_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            if (data.Count == 0)
                return 0;

            decimal maxValue = data[0].TotalArea;

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i].TotalArea > maxValue)
                {
                    maxValue = data[i].TotalArea;
                }
            }

            return maxValue;
        }

        // Функция 11: Квартиры с долгом
        public int CountApartmentsWithDebt_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            int count = 0;

            foreach (var item in data)
            {
                if (item.HasDebt)
                {
                    count++;
                }
            }

            return count;
        }

        // Функция 12: Всего детей
        public int TotalChildrenCount_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            int total = 0;

            foreach (var item in data)
            {
                total += item.ChildrenCount;
            }

            return total;
        }

        // Функция 13: Создание тестовых данных
        public List<ApartmentModel_IvanovIA> CreateTestData_IvanovIA()
        {
            List<ApartmentModel_IvanovIA> testData = new List<ApartmentModel_IvanovIA>();

            string[] lastNames = {
                "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов",
                "Попов", "Васильев", "Николаев", "Алексеев", "Дмитриев",
                "Федоров", "Егоров", "Сергеев", "Павлов", "Макаров",
                "Орлов", "Белов", "Киселев", "Григорьев", "Титов",
                "Комаров", "Ильин", "Захаров", "Карпов", "Андреев",
                "Назаров", "Савельев", "Глебов", "Константинов", "Архипов"
            };

            Random random = new Random();

            for (int i = 1; i <= 30; i++)
            {
                ApartmentModel_IvanovIA apt = new ApartmentModel_IvanovIA();

                apt.EntranceNumber = random.Next(1, 6);
                apt.ApartmentNumber = random.Next(1, 188);
                apt.TotalArea = Math.Round((decimal)(12 + random.NextDouble() * 104), 1);
                apt.LivingArea = Math.Round(apt.TotalArea * (decimal)(0.6 + random.NextDouble() * 0.3), 1);
                apt.RoomsCount = random.Next(1, 5);
                apt.TenantLastName = lastNames[random.Next(lastNames.Length)];
                apt.RegistrationDate = new DateTime(2015 + random.Next(8), random.Next(1, 13), random.Next(1, 29));
                apt.FamilyMembers = random.Next(1, 7);
                apt.ChildrenCount = random.Next(0, apt.FamilyMembers);
                apt.HasDebt = random.Next(0, 100) < 30;
                apt.Notes = apt.HasDebt ? "Есть задолженность" : "Без задолженности";

                testData.Add(apt);
            }

            return testData;
        }
    }
}