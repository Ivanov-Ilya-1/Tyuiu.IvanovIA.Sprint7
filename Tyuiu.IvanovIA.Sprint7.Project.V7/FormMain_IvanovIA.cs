using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tyuiu.IvanovIA.Sprint7.Project.V7.Lib;
using System.IO;

namespace Tyuiu.IvanovIA.Sprint7.Project.V7
{
    public partial class FormMain_IvanovIA : Form
    {
        private DataService_IvanovIA dataService;
        private List<ApartmentModel_IvanovIA> apartments;
        private bool isDataModified = false;
        private string currentFilePath = "";

        public FormMain_IvanovIA()
        {
            InitializeComponent();
            dataService = new DataService_IvanovIA();
            apartments = new List<ApartmentModel_IvanovIA>();

            // Настройка дизайна
            SetupDesign_IvanovIA();
            SetupDataGridView_IvanovIA();

            UpdateWindowTitle_IvanovIA();
            UpdateStatusBar_IvanovIA();
        }

        private void SetupDesign_IvanovIA()
        {
            // Настройка цветовой схемы Windows 11
            this.BackColor = Color.FromArgb(243, 243, 243);

            // Настройка стиля кнопок
            SetupButtonsStyle_IvanovIA();

            // Настройка панелей
            panelHeader_IvanovIA.BackColor = Color.FromArgb(0, 120, 215);
            panelSearch_IvanovIA.BackColor = Color.White;
            panelSearch_IvanovIA.BorderStyle = BorderStyle.FixedSingle;
            panelStats_IvanovIA.BackColor = Color.White;
            panelStats_IvanovIA.BorderStyle = BorderStyle.FixedSingle;

            // Настройка DataGridView
            dataGridViewApartments_IvanovIA.BackgroundColor = Color.White;
            dataGridViewApartments_IvanovIA.GridColor = Color.FromArgb(225, 225, 225);
            dataGridViewApartments_IvanovIA.BorderStyle = BorderStyle.FixedSingle;

            // Настройка меток
            labelHeader_IvanovIA.ForeColor = Color.White;
            labelHeader_IvanovIA.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // Настройка статус-бара
            statusStripMain_IvanovIA.BackColor = Color.FromArgb(240, 240, 240);
            statusStripMain_IvanovIA.RenderMode = ToolStripRenderMode.Professional;
        }

        private void SetupButtonsStyle_IvanovIA()
        {
            // Список всех кнопок для настройки
            Button[] buttons = {
                buttonLoadData_IvanovIA, buttonSaveData_IvanovIA,
                buttonCreateTestData_IvanovIA, buttonShowChart_IvanovIA,
                buttonSearch_IvanovIA, buttonClearSearch_IvanovIA,
                buttonAddApartment_IvanovIA, buttonDeleteApartment_IvanovIA,
                buttonUpdateStats_IvanovIA
            };

            foreach (Button btn in buttons)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.FromArgb(0, 120, 215);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 185);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 165);
                    btn.Cursor = Cursors.Hand;
                    btn.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                }
            }

            // Специальные кнопки
            buttonDeleteApartment_IvanovIA.BackColor = Color.FromArgb(220, 53, 69); // Красный
            buttonDeleteApartment_IvanovIA.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            buttonDeleteApartment_IvanovIA.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 20, 40);
        }

        private void SetupDataGridView_IvanovIA()
        {
            // Очищаем существующие колонки
            dataGridViewApartments_IvanovIA.Columns.Clear();

            // Создаем колонки с настройками
            DataGridViewColumn[] columns = new DataGridViewColumn[]
            {
                CreateColumn("Подъезд", "Entrance", 60),
                CreateColumn("Квартира", "Apartment", 70),
                CreateColumn("Общая пл. (м²)", "TotalArea", 100),
                CreateColumn("Жилая пл. (м²)", "LivingArea", 100),
                CreateColumn("Комнат", "Rooms", 70),
                CreateColumn("Фамилия", "LastName", 120),
                CreateColumn("Дата прописки", "RegDate", 100),
                CreateColumn("Семья", "Family", 70),
                CreateColumn("Дети", "Children", 60),
                CreateColumn("Долг", "Debt", 60),
                CreateColumn("Примечание", "Notes", 200)
            };

            foreach (var column in columns)
            {
                dataGridViewApartments_IvanovIA.Columns.Add(column);
            }

            // Настройка внешнего вида
            dataGridViewApartments_IvanovIA.RowHeadersVisible = false;
            dataGridViewApartments_IvanovIA.AllowUserToAddRows = false;
            dataGridViewApartments_IvanovIA.AllowUserToDeleteRows = false;
            dataGridViewApartments_IvanovIA.ReadOnly = false; // Разрешаем редактирование
            dataGridViewApartments_IvanovIA.EditMode = DataGridViewEditMode.EditOnEnter;

            // Настройка стиля
            dataGridViewApartments_IvanovIA.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            dataGridViewApartments_IvanovIA.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewApartments_IvanovIA.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dataGridViewApartments_IvanovIA.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridViewApartments_IvanovIA.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Подписка на события редактирования
            dataGridViewApartments_IvanovIA.CellValueChanged += DataGridView_CellValueChanged_IvanovIA;
            dataGridViewApartments_IvanovIA.CellValidating += DataGridView_CellValidating_IvanovIA;
        }

        private DataGridViewColumn CreateColumn(string headerText, string name, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                HeaderText = headerText,
                Name = name,
                Width = width,
                MinimumWidth = width,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
        }

        private void UpdateWindowTitle_IvanovIA()
        {
            string title = "Домоуправление - Иванов И.А. (V7)";
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                title += $" - {Path.GetFileName(currentFilePath)}";
            }
            if (isDataModified)
            {
                title += " *";
            }
            this.Text = title;
        }

        private void UpdateStatusBar_IvanovIA()
        {
            toolStripStatusLabelCount_IvanovIA.Text = $"Записей: {apartments.Count}";
            toolStripStatusLabelModified_IvanovIA.Text = isDataModified ? "Изменения: есть" : "Изменений: нет";
        }

        // ============ СОБЫТИЯ РЕДАКТИРОВАНИЯ ТАБЛИЦЫ ============

        private void DataGridView_CellValueChanged_IvanovIA(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && apartments.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewApartments_IvanovIA.Rows[e.RowIndex];
                    ApartmentModel_IvanovIA apartment = apartments[e.RowIndex];

                    // Обновляем модель данных
                    switch (e.ColumnIndex)
                    {
                        case 0: // Подъезд
                            apartment.EntranceNumber = Convert.ToInt32(row.Cells[0].Value);
                            break;
                        case 1: // Квартира
                            apartment.ApartmentNumber = Convert.ToInt32(row.Cells[1].Value);
                            break;
                        case 2: // Общая площадь
                            apartment.TotalArea = Convert.ToDecimal(row.Cells[2].Value);
                            break;
                        case 3: // Жилая площадь
                            apartment.LivingArea = Convert.ToDecimal(row.Cells[3].Value);
                            break;
                        case 4: // Комнат
                            apartment.RoomsCount = Convert.ToInt32(row.Cells[4].Value);
                            break;
                        case 5: // Фамилия
                            apartment.TenantLastName = row.Cells[5].Value?.ToString() ?? "";
                            break;
                        case 6: // Дата прописки
                            if (DateTime.TryParse(row.Cells[6].Value?.ToString(), out DateTime date))
                                apartment.RegistrationDate = date;
                            break;
                        case 7: // Семья
                            apartment.FamilyMembers = Convert.ToInt32(row.Cells[7].Value);
                            break;
                        case 8: // Дети
                            apartment.ChildrenCount = Convert.ToInt32(row.Cells[8].Value);
                            break;
                        case 9: // Долг
                            string debtValue = row.Cells[9].Value?.ToString()?.ToLower() ?? "";
                            apartment.HasDebt = debtValue == "да" || debtValue == "true" || debtValue == "1";
                            row.Cells[9].Value = apartment.HasDebt ? "Да" : "Нет";
                            break;
                        case 10: // Примечание
                            apartment.Notes = row.Cells[10].Value?.ToString() ?? "";
                            break;
                    }

                    // Подсветка строки с долгом
                    row.DefaultCellStyle.BackColor = apartment.HasDebt ?
                        Color.FromArgb(255, 240, 240) : Color.White;

                    // Помечаем как измененное
                    isDataModified = true;
                    UpdateWindowTitle_IvanovIA();
                    UpdateStatusBar_IvanovIA();
                    toolStripStatusLabelInfo_IvanovIA.Text = "Данные изменены. Не забудьте сохранить!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изменения: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_CellValidating_IvanovIA(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                string value = e.FormattedValue?.ToString() ?? "";

                // Валидация в зависимости от колонки
                switch (e.ColumnIndex)
                {
                    case 0: // Подъезд
                    case 1: // Квартира
                    case 4: // Комнат
                    case 7: // Семья
                    case 8: // Дети
                        if (!int.TryParse(value, out int intResult) || intResult < 0)
                        {
                            e.Cancel = true;
                            MessageBox.Show("Введите целое положительное число",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case 2: // Общая площадь
                    case 3: // Жилая площадь
                        if (!decimal.TryParse(value.Replace(',', '.'), out decimal decResult) || decResult <= 0)
                        {
                            e.Cancel = true;
                            MessageBox.Show("Введите положительное число",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case 6: // Дата прописки
                        if (!DateTime.TryParse(value, out _) && !string.IsNullOrEmpty(value))
                        {
                            e.Cancel = true;
                            MessageBox.Show("Введите дату в формате ДД.ММ.ГГГГ",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case 9: // Долг
                        string lowerValue = value.ToLower();
                        if (!(lowerValue == "да" || lowerValue == "нет" ||
                              lowerValue == "true" || lowerValue == "false" ||
                              lowerValue == "1" || lowerValue == "0" || string.IsNullOrEmpty(lowerValue)))
                        {
                            e.Cancel = true;
                            MessageBox.Show("Введите 'Да' или 'Нет'",
                                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка валидации: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============ ОБРАБОТЧИКИ СОБЫТИЙ КНОПОК ============

        private void buttonLoadData_IvanovIA_Click(object sender, EventArgs e)
        {
            if (isDataModified)
            {
                DialogResult result = MessageBox.Show("У вас есть несохраненные изменения. Загрузить новые данные без сохранения?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;
            }

            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                    dialog.Title = "Загрузить данные о квартирах";
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = dialog.FileName;
                        apartments = dataService.LoadFromCSV_IvanovIA(currentFilePath);

                        UpdateDataGrid_IvanovIA();
                        UpdateStatistics_IvanovIA();

                        isDataModified = false;
                        UpdateWindowTitle_IvanovIA();
                        UpdateStatusBar_IvanovIA();

                        toolStripStatusLabelInfo_IvanovIA.Text = $"Загружено {apartments.Count} записей из {Path.GetFileName(currentFilePath)}";

                        MessageBox.Show($"Успешно загружено {apartments.Count} записей!",
                            "Загрузка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveData_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                if (apartments.Count == 0)
                {
                    MessageBox.Show("Нет данных для сохранения!",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string filePath = currentFilePath;
                bool isNewFile = string.IsNullOrEmpty(filePath);

                if (isNewFile || !File.Exists(filePath))
                {
                    using (SaveFileDialog dialog = new SaveFileDialog())
                    {
                        dialog.Filter = "CSV файлы (*.csv)|*.csv";
                        dialog.Title = "Сохранить данные о квартирах";
                        dialog.FileName = $"apartments_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = dialog.FileName;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                dataService.SaveToCSV_IvanovIA(apartments, filePath);
                currentFilePath = filePath;
                isDataModified = false;
                UpdateWindowTitle_IvanovIA();
                UpdateStatusBar_IvanovIA();

                toolStripStatusLabelInfo_IvanovIA.Text = $"Данные сохранены в {Path.GetFileName(filePath)}";

                MessageBox.Show($"Данные успешно сохранены!\n{filePath}",
                    "Сохранение завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBoxSearch_IvanovIA.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    MessageBox.Show("Введите фамилию для поиска!",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxSearch_IvanovIA.Focus();
                    return;
                }

                if (apartments.Count == 0)
                {
                    MessageBox.Show("Нет данных для поиска!",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<ApartmentModel_IvanovIA> results = dataService.SearchByLastName_IvanovIA(apartments, searchText);

                if (results.Count == 0)
                {
                    MessageBox.Show($"Квартиры с фамилией '{searchText}' не найдены.",
                        "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSearchResults_IvanovIA(results);
                }
                else
                {
                    ShowSearchResults_IvanovIA(results);
                    toolStripStatusLabelInfo_IvanovIA.Text = $"Найдено {results.Count} записей";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClearSearch_IvanovIA_Click(object sender, EventArgs e)
        {
            textBoxSearch_IvanovIA.Clear();
            UpdateDataGrid_IvanovIA();
            toolStripStatusLabelInfo_IvanovIA.Text = "Поиск отменен. Показаны все записи.";
        }

        private void buttonCreateTestData_IvanovIA_Click(object sender, EventArgs e)
        {
            if (isDataModified)
            {
                DialogResult result = MessageBox.Show("У вас есть несохраненные изменения. Создать тестовые данные без сохранения?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;
            }

            try
            {
                apartments = dataService.CreateTestData_IvanovIA();
                UpdateDataGrid_IvanovIA();
                UpdateStatistics_IvanovIA();

                currentFilePath = "";
                isDataModified = true;
                UpdateWindowTitle_IvanovIA();
                UpdateStatusBar_IvanovIA();

                toolStripStatusLabelInfo_IvanovIA.Text = $"Создано {apartments.Count} тестовых записей";

                MessageBox.Show($"Создано {apartments.Count} тестовых записей о квартирах!",
                    "Тестовые данные", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании тестовых данных:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddApartment_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем новую квартиру с данными по умолчанию
                ApartmentModel_IvanovIA newApartment = new ApartmentModel_IvanovIA
                {
                    EntranceNumber = 1,
                    ApartmentNumber = apartments.Count > 0 ?
                        apartments[apartments.Count - 1].ApartmentNumber + 1 : 1,
                    TotalArea = 50.0m,
                    LivingArea = 35.0m,
                    RoomsCount = 2,
                    TenantLastName = "Новый жилец",
                    RegistrationDate = DateTime.Now,
                    FamilyMembers = 1,
                    ChildrenCount = 0,
                    HasDebt = false,
                    Notes = "Новая запись"
                };

                apartments.Add(newApartment);

                // Добавляем строку в таблицу
                int rowIndex = dataGridViewApartments_IvanovIA.Rows.Add();
                DataGridViewRow row = dataGridViewApartments_IvanovIA.Rows[rowIndex];

                row.Cells[0].Value = newApartment.EntranceNumber;
                row.Cells[1].Value = newApartment.ApartmentNumber;
                row.Cells[2].Value = newApartment.TotalArea;
                row.Cells[3].Value = newApartment.LivingArea;
                row.Cells[4].Value = newApartment.RoomsCount;
                row.Cells[5].Value = newApartment.TenantLastName;
                row.Cells[6].Value = newApartment.RegistrationDate.ToString("dd.MM.yyyy");
                row.Cells[7].Value = newApartment.FamilyMembers;
                row.Cells[8].Value = newApartment.ChildrenCount;
                row.Cells[9].Value = newApartment.HasDebt ? "Да" : "Нет";
                row.Cells[10].Value = newApartment.Notes;

                // Прокручиваем к новой строке
                dataGridViewApartments_IvanovIA.FirstDisplayedScrollingRowIndex = rowIndex;
                dataGridViewApartments_IvanovIA.Rows[rowIndex].Selected = true;

                isDataModified = true;
                UpdateWindowTitle_IvanovIA();
                UpdateStatusBar_IvanovIA();
                UpdateStatistics_IvanovIA();

                toolStripStatusLabelInfo_IvanovIA.Text = "Добавлена новая квартира. Не забудьте сохранить!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении квартиры:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteApartment_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewApartments_IvanovIA.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите строку для удаления!",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = dataGridViewApartments_IvanovIA.SelectedRows[0].Index;

                    if (selectedIndex >= 0 && selectedIndex < apartments.Count)
                    {
                        apartments.RemoveAt(selectedIndex);
                        dataGridViewApartments_IvanovIA.Rows.RemoveAt(selectedIndex);

                        isDataModified = true;
                        UpdateWindowTitle_IvanovIA();
                        UpdateStatusBar_IvanovIA();
                        UpdateStatistics_IvanovIA();

                        toolStripStatusLabelInfo_IvanovIA.Text = "Запись удалена. Не забудьте сохранить!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении квартиры:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonShowChart_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                if (apartments.Count == 0)
                {
                    MessageBox.Show("Нет данных для построения графика!",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (FormChart_IvanovIA chartForm = new FormChart_IvanovIA(apartments))
                {
                    chartForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении графика:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdateStats_IvanovIA_Click(object sender, EventArgs e)
        {
            UpdateStatistics_IvanovIA();
            toolStripStatusLabelInfo_IvanovIA.Text = "Статистика обновлена";
        }

        // ============ ОБРАБОТЧИКИ СОБЫТИЙ МЕНЮ ============

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            FormMain_IvanovIA_FormClosing(sender, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
        }

        // ============ ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ============

        private void UpdateDataGrid_IvanovIA()
        {
            try
            {
                dataGridViewApartments_IvanovIA.Rows.Clear();

                if (apartments.Count == 0)
                    return;

                foreach (var apartment in apartments)
                {
                    int rowIndex = dataGridViewApartments_IvanovIA.Rows.Add();
                    DataGridViewRow row = dataGridViewApartments_IvanovIA.Rows[rowIndex];

                    row.Cells[0].Value = apartment.EntranceNumber;
                    row.Cells[1].Value = apartment.ApartmentNumber;
                    row.Cells[2].Value = apartment.TotalArea.ToString("F1");
                    row.Cells[3].Value = apartment.LivingArea.ToString("F1");
                    row.Cells[4].Value = apartment.RoomsCount;
                    row.Cells[5].Value = apartment.TenantLastName;
                    row.Cells[6].Value = apartment.RegistrationDate.ToString("dd.MM.yyyy");
                    row.Cells[7].Value = apartment.FamilyMembers;
                    row.Cells[8].Value = apartment.ChildrenCount;
                    row.Cells[9].Value = apartment.HasDebt ? "Да" : "Нет";
                    row.Cells[10].Value = apartment.Notes;

                    // Подсветка строк с задолженностью
                    row.DefaultCellStyle.BackColor = apartment.HasDebt ?
                        Color.FromArgb(255, 240, 240) : Color.White;
                }

                UpdateStatusBar_IvanovIA();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении таблицы:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSearchResults_IvanovIA(List<ApartmentModel_IvanovIA> results)
        {
            try
            {
                dataGridViewApartments_IvanovIA.Rows.Clear();

                if (results.Count == 0)
                    return;

                foreach (var apartment in results)
                {
                    int rowIndex = dataGridViewApartments_IvanovIA.Rows.Add();
                    DataGridViewRow row = dataGridViewApartments_IvanovIA.Rows[rowIndex];

                    row.Cells[0].Value = apartment.EntranceNumber;
                    row.Cells[1].Value = apartment.ApartmentNumber;
                    row.Cells[2].Value = apartment.TotalArea.ToString("F1");
                    row.Cells[3].Value = apartment.LivingArea.ToString("F1");
                    row.Cells[4].Value = apartment.RoomsCount;
                    row.Cells[5].Value = apartment.TenantLastName;
                    row.Cells[6].Value = apartment.RegistrationDate.ToString("dd.MM.yyyy");
                    row.Cells[7].Value = apartment.FamilyMembers;
                    row.Cells[8].Value = apartment.ChildrenCount;
                    row.Cells[9].Value = apartment.HasDebt ? "Да" : "Нет";
                    row.Cells[10].Value = apartment.Notes;

                    row.DefaultCellStyle.BackColor = apartment.HasDebt ?
                        Color.FromArgb(255, 240, 240) : Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отображении результатов:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics_IvanovIA()
        {
            try
            {
                if (apartments.Count == 0)
                {
                    labelTotal_IvanovIA.Text = "Всего квартир: 0";
                    labelAvgArea_IvanovIA.Text = "Средняя площадь: 0,0 м²";
                    labelDebt_IvanovIA.Text = "С задолженностью: 0";
                    labelChildren_IvanovIA.Text = "Всего детей: 0";
                    labelMinArea_IvanovIA.Text = "Мин. площадь: 0,0 м²";
                    labelMaxArea_IvanovIA.Text = "Макс. площадь: 0,0 м²";
                    return;
                }

                int total = dataService.CountApartments_IvanovIA(apartments);
                decimal avgArea = dataService.AverageTotalArea_IvanovIA(apartments);
                int withDebt = dataService.CountApartmentsWithDebt_IvanovIA(apartments);
                int children = dataService.TotalChildrenCount_IvanovIA(apartments);
                decimal minArea = dataService.MinTotalArea_IvanovIA(apartments);
                decimal maxArea = dataService.MaxTotalArea_IvanovIA(apartments);

                labelTotal_IvanovIA.Text = $"Всего квартир: {total}";
                labelAvgArea_IvanovIA.Text = $"Средняя площадь: {avgArea:F1} м²";
                labelDebt_IvanovIA.Text = $"С задолженностью: {withDebt}";
                labelChildren_IvanovIA.Text = $"Всего детей: {children}";
                labelMinArea_IvanovIA.Text = $"Мин. площадь: {minArea:F1} м²";
                labelMaxArea_IvanovIA.Text = $"Макс. площадь: {maxArea:F1} м²";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете статистики:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============ ДОПОЛНИТЕЛЬНЫЕ СОБЫТИЯ ============

        private void textBoxSearch_IvanovIA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSearch_IvanovIA_Click(sender, e);
                e.Handled = true;
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            string aboutText = "🏠 Домоуправление - Система учета квартир\n\n" +
                              "📋 Версия: 2.0 (Улучшенная)\n" +
                              "👨‍💻 Разработчик: Иванов Илья Анатольевич\n" +
                              "🎓 Группа: ИИПБ-25-1\n" +
                              "🔢 Вариант: V7\n" +
                              "📅 Дата сборки: " + DateTime.Now.ToString("dd.MM.yyyy") + "\n\n" +
                              "✨ Особенности версии 2.0:\n" +
                              "• Редактирование данных прямо в таблице\n" +
                              "• Добавление и удаление записей\n" +
                              "• Валидация ввода данных\n" +
                              "• Современный интерфейс\n" +
                              "• Иконки для всех кнопок";

            MessageBox.Show(aboutText, "О программе",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormMain_IvanovIA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataModified)
            {
                DialogResult result = MessageBox.Show("У вас есть несохраненные изменения. Закрыть программу без сохранения?",
                    "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    buttonSaveData_IvanovIA_Click(sender, e);
                }
            }
        }
    }
}