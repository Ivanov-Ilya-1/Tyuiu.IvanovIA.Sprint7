using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Tyuiu.IvanovIA.Sprint7.Project.V7.Lib
{
    public class DataService_IvanovIA
    {
        // Функция 1: Загрузка данных из CSV (с поддержкой разных кодировок)
        public List<ApartmentModel_IvanovIA> LoadFromCSV_IvanovIA(string path)
        {
            List<ApartmentModel_IvanovIA> dataList = new List<ApartmentModel_IvanovIA>();

            try
            {
                // ПРОБУЕМ РАЗНЫЕ КОДИРОВКИ ДЛЯ ЧТЕНИЯ ФАЙЛА
                string[] allLines;

                // Сначала пробуем UTF-8 (современная кодировка)
                try
                {
                    allLines = File.ReadAllLines(path, Encoding.UTF8);
                    Console.WriteLine("Файл прочитан в кодировке UTF-8");
                }
                catch
                {
                    // Если UTF-8 не работает, пробуем Windows-1251 (русская Windows)
                    try
                    {
                        allLines = File.ReadAllLines(path, Encoding.GetEncoding(1251));
                        Console.WriteLine("Файл прочитан в кодировке Windows-1251");
                    }
                    catch
                    {
                        // Если и это не работает, пробуем по умолчанию (системная кодировка)
                        allLines = File.ReadAllLines(path, Encoding.Default);
                        Console.WriteLine("Файл прочитан в системной кодировке");
                    }
                }

                Console.WriteLine($"Прочитано строк из файла: {allLines.Length}");

                if (allLines.Length == 0)
                {
                    Console.WriteLine("Файл пустой!");
                    return dataList;
                }

                // Выводим первую строку для отладки
                Console.WriteLine($"Первая строка файла: {allLines[0]}");

                // Пропускаем заголовок (первую строку)
                for (int i = 1; i < allLines.Length; i++)
                {
                    string line = allLines[i].Trim();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    Console.WriteLine($"Обрабатываем строку {i}: {line}");

                    // Пробуем разные разделители
                    string[] parts;

                    if (line.Contains(";") && line.Split(';').Length >= 11)
                    {
                        // Разделитель - точка с запятой (русский стандарт)
                        parts = line.Split(';');
                        Console.WriteLine($"  Разделитель: точка с запятой, полей: {parts.Length}");
                    }
                    else if (line.Contains(",") && line.Split(',').Length >= 11)
                    {
                        // Разделитель - запятая (английский стандарт)
                        parts = line.Split(',');
                        Console.WriteLine($"  Разделитель: запятая, полей: {parts.Length}");
                    }
                    else if (line.Contains("\t"))
                    {
                        // Разделитель - табуляция
                        parts = line.Split('\t');
                        Console.WriteLine($"  Разделитель: табуляция, полей: {parts.Length}");
                    }
                    else
                    {
                        Console.WriteLine($"  Пропускаем строку {i}: неподдерживаемый формат");
                        continue;
                    }

                    if (parts.Length < 11)
                    {
                        Console.WriteLine($"  Ошибка: в строке {i} только {parts.Length} полей, нужно 11");
                        Console.WriteLine($"  Строка: {line}");
                        continue;
                    }

                    try
                    {
                        ApartmentModel_IvanovIA item = new ApartmentModel_IvanovIA();

                        // Обрабатываем каждое поле с безопасным парсингом
                        item.EntranceNumber = ParseIntSafe(parts[0]);
                        item.ApartmentNumber = ParseIntSafe(parts[1]);

                        // Заменяем точку на запятую для десятичных чисел (для русского формата)
                        string totalAreaStr = parts[2].Trim().Replace('.', ',');
                        string livingAreaStr = parts[3].Trim().Replace('.', ',');

                        item.TotalArea = ParseDecimalSafe(totalAreaStr);
                        item.LivingArea = ParseDecimalSafe(livingAreaStr);

                        item.RoomsCount = ParseIntSafe(parts[4]);
                        item.TenantLastName = parts[5].Trim();

                        // Разные форматы даты
                        string dateStr = parts[6].Trim();
                        item.RegistrationDate = ParseDateSafe(dateStr);

                        item.FamilyMembers = ParseIntSafe(parts[7]);
                        item.ChildrenCount = ParseIntSafe(parts[8]);

                        // Обработка логического значения (разные варианты)
                        string debtStr = parts[9].Trim().ToLower();
                        item.HasDebt = (debtStr == "true" || debtStr == "да" || debtStr == "1" || debtStr == "yes");

                        item.Notes = parts[10].Trim();

                        dataList.Add(item);

                        // Вывод в консоль для отладки
                        Console.WriteLine($"  ✓ Загружена квартира {item.ApartmentNumber}: {item.TenantLastName}, {item.TotalArea} м²");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"  ✗ Ошибка в строке {i}: {ex.Message}");
                        Console.WriteLine($"    Строка: {line}");
                        Console.WriteLine($"    Детали: {ex}");
                    }
                }

                Console.WriteLine($"=== ВСЕГО ЗАГРУЖЕНО ЗАПИСЕЙ: {dataList.Count} ===");
                return dataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"КРИТИЧЕСКАЯ ОШИБКА ЗАГРУЗКИ ФАЙЛА: {ex.Message}");
                Console.WriteLine($"Детали: {ex}");
                throw new Exception($"Ошибка загрузки файла: {ex.Message}");
            }
        }

        // Функция 2: Сохранение в CSV (всегда в UTF-8)
        public void SaveToCSV_IvanovIA(List<ApartmentModel_IvanovIA> data, string path)
        {
            try
            {
                List<string> lines = new List<string>();

                // Заголовок всегда на английском (как в модели)
                lines.Add("EntranceNumber;ApartmentNumber;TotalArea;LivingArea;RoomsCount;TenantLastName;RegistrationDate;FamilyMembers;ChildrenCount;HasDebt;Notes");

                foreach (var item in data)
                {
                    // Формируем строку с разделителем ";" (русский стандарт)
                    string line = $"{item.EntranceNumber};" +
                                 $"{item.ApartmentNumber};" +
                                 $"{item.TotalArea.ToString(CultureInfo.InvariantCulture).Replace('.', ',')};" +
                                 $"{item.LivingArea.ToString(CultureInfo.InvariantCulture).Replace('.', ',')};" +
                                 $"{item.RoomsCount};" +
                                 $"{item.TenantLastName};" +
                                 $"{item.RegistrationDate:dd.MM.yyyy};" +
                                 $"{item.FamilyMembers};" +
                                 $"{item.ChildrenCount};" +
                                 $"{item.HasDebt};" +
                                 $"{item.Notes}";

                    lines.Add(line);
                }

                // Сохраняем в UTF-8 (без BOM для совместимости)
                File.WriteAllLines(path, lines, new UTF8Encoding(false));

                Console.WriteLine($"Файл сохранен: {path}");
                Console.WriteLine($"Кодировка: UTF-8 (без BOM)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА СОХРАНЕНИЯ ФАЙЛА: {ex.Message}");
                throw new Exception($"Ошибка сохранения: {ex.Message}");
            }
        }

        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ДЛЯ БЕЗОПАСНОГО ПАРСИНГА

        private int ParseIntSafe(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine($"  ParseIntSafe: пустое значение, возвращаю 0");
                return 0;
            }

            // Удаляем лишние символы
            value = value.Trim();
            Console.WriteLine($"  ParseIntSafe: парсим '{value}'");

            // Пробуем стандартный парсинг
            if (int.TryParse(value, out int result))
            {
                Console.WriteLine($"  ParseIntSafe: успешно, результат: {result}");
                return result;
            }

            // Если есть дробная часть, берем целую часть
            if (value.Contains(",") || value.Contains("."))
            {
                string[] parts = value.Split(new char[] { ',', '.' });
                if (parts.Length > 0 && int.TryParse(parts[0], out result))
                {
                    Console.WriteLine($"  ParseIntSafe: взята целая часть, результат: {result}");
                    return result;
                }
            }

            // Пробуем удалить нечисловые символы
            string numbersOnly = new string(value.Where(char.IsDigit).ToArray());
            if (int.TryParse(numbersOnly, out result) && numbersOnly.Length > 0)
            {
                Console.WriteLine($"  ParseIntSafe: удалены нечисловые символы, результат: {result}");
                return result;
            }

            Console.WriteLine($"  ParseIntSafe: не удалось распарсить, возвращаю 0");
            return 0;
        }

        private decimal ParseDecimalSafe(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine($"  ParseDecimalSafe: пустое значение, возвращаю 0");
                return 0;
            }

            value = value.Trim();
            Console.WriteLine($"  ParseDecimalSafe: парсим '{value}'");

            // Сохраняем оригинал для сообщений об ошибках
            string originalValue = value;

            // Пробуем с точкой (международный формат)
            if (decimal.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                result = Math.Round(result, 2);
                Console.WriteLine($"  ParseDecimalSafe: успешно с точкой, результат: {result}");
                return result;
            }

            // Пробуем с запятой (русский формат)
            if (decimal.TryParse(value.Replace('.', ','), NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out result))
            {
                result = Math.Round(result, 2);
                Console.WriteLine($"  ParseDecimalSafe: успешно с запятой, результат: {result}");
                return result;
            }

            // Пробуем удалить все нецифровые символы кроме точек и запятых
            string cleanValue = new string(value.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
            if (!string.IsNullOrEmpty(cleanValue))
            {
                if (decimal.TryParse(cleanValue.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                {
                    result = Math.Round(result, 2);
                    Console.WriteLine($"  ParseDecimalSafe: очищено, результат: {result}");
                    return result;
                }
            }

            Console.WriteLine($"  ParseDecimalSafe: не удалось распарсить '{originalValue}', возвращаю 0");
            return 0;
        }

        private DateTime ParseDateSafe(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine($"  ParseDateSafe: пустое значение, возвращаю текущую дату");
                return DateTime.Now;
            }

            value = value.Trim();
            Console.WriteLine($"  ParseDateSafe: парсим '{value}'");

            // Пробуем разные форматы дат (самые распространенные)
            string[] formats = {
                "yyyy-MM-dd",      // 2023-12-15
                "dd.MM.yyyy",      // 15.12.2023
                "dd/MM/yyyy",      // 15/12/2023
                "yyyy/MM/dd",      // 2023/12/15
                "MM/dd/yyyy",      // 12/15/2023
                "dd-MM-yyyy",      // 15-12-2023
                "yyyy.MM.dd",      // 2023.12.15
                "d.M.yyyy",        // 15.12.2023 (без ведущих нулей)
                "d/M/yyyy"         // 15/12/2023 (без ведущих нулей)
            };

            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    Console.WriteLine($"  ParseDateSafe: успешно по формату '{format}', результат: {result:dd.MM.yyyy}");
                    return result;
                }
            }

            // Если не удалось распарсить по форматам, пробуем стандартный парсинг
            if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime defaultResult))
            {
                Console.WriteLine($"  ParseDateSafe: успешно стандартным парсингом, результат: {defaultResult:dd.MM.yyyy}");
                return defaultResult;
            }

            // Пробуем с русской культурой
            if (DateTime.TryParse(value, CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out DateTime ruResult))
            {
                Console.WriteLine($"  ParseDateSafe: успешно с русской культурой, результат: {ruResult:dd.MM.yyyy}");
                return ruResult;
            }

            Console.WriteLine($"  ParseDateSafe: не удалось распарсить '{value}', возвращаю текущую дату");
            return DateTime.Now;
        }

        // ОСТАЛЬНЫЕ ФУНКЦИИ (остаются без изменений)

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