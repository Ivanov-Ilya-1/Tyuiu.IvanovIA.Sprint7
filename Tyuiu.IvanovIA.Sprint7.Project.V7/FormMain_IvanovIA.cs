using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tyuiu.IvanovIA.Sprint7.Project.V7.Lib;

namespace Tyuiu.IvanovIA.Sprint7.Project.V7
{
    public partial class FormMain_IvanovIA : Form
    {
        private DataService_IvanovIA dataService;
        private List<ApartmentModel_IvanovIA> apartments;

        public FormMain_IvanovIA()
        {
            InitializeComponent();
            dataService = new DataService_IvanovIA();
            apartments = new List<ApartmentModel_IvanovIA>();

            SetupDesign_IvanovIA();
        }

        private void SetupDesign_IvanovIA()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);

            buttonLoadData_IvanovIA.BackColor = Color.FromArgb(0, 120, 215);
            buttonLoadData_IvanovIA.ForeColor = Color.White;
            buttonLoadData_IvanovIA.FlatStyle = FlatStyle.Flat;

            buttonSaveData_IvanovIA.BackColor = Color.FromArgb(0, 120, 215);
            buttonSaveData_IvanovIA.ForeColor = Color.White;
            buttonSaveData_IvanovIA.FlatStyle = FlatStyle.Flat;

            buttonSearch_IvanovIA.BackColor = Color.FromArgb(0, 120, 215);
            buttonSearch_IvanovIA.ForeColor = Color.White;
            buttonSearch_IvanovIA.FlatStyle = FlatStyle.Flat;

            buttonCreateTestData_IvanovIA.BackColor = Color.FromArgb(0, 120, 215);
            buttonCreateTestData_IvanovIA.ForeColor = Color.White;
            buttonCreateTestData_IvanovIA.FlatStyle = FlatStyle.Flat;

            buttonShowChart_IvanovIA.BackColor = Color.FromArgb(0, 120, 215);
            buttonShowChart_IvanovIA.ForeColor = Color.White;
            buttonShowChart_IvanovIA.FlatStyle = FlatStyle.Flat;

            dataGridViewApartments_IvanovIA.BackgroundColor = Color.White;
            dataGridViewApartments_IvanovIA.GridColor = Color.LightGray;
            dataGridViewApartments_IvanovIA.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            panelStats_IvanovIA.BackColor = Color.White;
        }

        // ============ ОБРАБОТЧИКИ СОБЫТИЙ ============

        private void buttonLoadData_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "CSV файлы|*.csv|Все файлы|*.*";
                dialog.Title = "Выберите CSV файл";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    apartments = dataService.LoadFromCSV_IvanovIA(dialog.FileName);
                    UpdateDataGrid_IvanovIA();
                    UpdateStatistics_IvanovIA();

                    toolStripStatusLabelInfo_IvanovIA.Text = $"Загружено: {apartments.Count} записей";
                    MessageBox.Show($"Загружено {apartments.Count} записей", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveData_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                if (apartments.Count == 0)
                {
                    MessageBox.Show("Нет данных для сохранения", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "CSV файлы|*.csv";
                dialog.FileName = "apartments_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dataService.SaveToCSV_IvanovIA(apartments, dialog.FileName);

                    toolStripStatusLabelInfo_IvanovIA.Text = $"Сохранено: {dialog.FileName}";
                    MessageBox.Show("Данные сохранены", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBoxSearch_IvanovIA.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    UpdateDataGrid_IvanovIA();
                    MessageBox.Show("Введите фамилию для поиска", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (apartments.Count == 0)
                {
                    MessageBox.Show("Сначала загрузите данные", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var results = dataService.SearchByLastName_IvanovIA(apartments, searchText);
                ShowSearchResults_IvanovIA(results);

                toolStripStatusLabelInfo_IvanovIA.Text = $"Найдено: {results.Count} записей";

                if (results.Count == 0)
                {
                    MessageBox.Show($"Не найдено квартир для фамилии: {searchText}", "Результат поиска",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateTestData_IvanovIA_Click(object sender, EventArgs e)
        {
            try
            {
                apartments = dataService.CreateTestData_IvanovIA();
                UpdateDataGrid_IvanovIA();
                UpdateStatistics_IvanovIA();

                toolStripStatusLabelInfo_IvanovIA.Text = $"Создано: {apartments.Count} тестовых записей";
                MessageBox.Show($"Создано {apartments.Count} тестовых записей", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonShowChart_IvanovIA_Click(object sender, EventArgs e)
        {
            if (apartments.Count == 0)
            {
                MessageBox.Show("Нет данных для графика", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormChart_IvanovIA chartForm = new FormChart_IvanovIA(apartments);
            chartForm.Show();
        }

        private void buttonUpdateStats_IvanovIA_Click(object sender, EventArgs e)
        {
            UpdateStatistics_IvanovIA();
        }

        private void menuItemLoad_Click(object sender, EventArgs e)
        {
            buttonLoadData_IvanovIA_Click(sender, e);
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            buttonSaveData_IvanovIA_Click(sender, e);
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Выйти из программы?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Домоуправление\nВерсия 1.0\nРазработчик: Иванов Илья Анатольевич\nГруппа: ИИПБ-25-1\nВариант: V7",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ============ ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ============

        private void UpdateDataGrid_IvanovIA()
        {
            dataGridViewApartments_IvanovIA.Rows.Clear();

            foreach (var apt in apartments)
            {
                dataGridViewApartments_IvanovIA.Rows.Add(
                    apt.EntranceNumber,
                    apt.ApartmentNumber,
                    apt.TotalArea,
                    apt.LivingArea,
                    apt.RoomsCount,
                    apt.TenantLastName,
                    apt.RegistrationDate.ToString("dd.MM.yyyy"),
                    apt.FamilyMembers,
                    apt.ChildrenCount,
                    apt.HasDebt ? "Да" : "Нет",
                    apt.Notes
                );
            }
        }

        private void ShowSearchResults_IvanovIA(List<ApartmentModel_IvanovIA> results)
        {
            dataGridViewApartments_IvanovIA.Rows.Clear();

            foreach (var apt in results)
            {
                dataGridViewApartments_IvanovIA.Rows.Add(
                    apt.EntranceNumber,
                    apt.ApartmentNumber,
                    apt.TotalArea,
                    apt.LivingArea,
                    apt.RoomsCount,
                    apt.TenantLastName,
                    apt.RegistrationDate.ToString("dd.MM.yyyy"),
                    apt.FamilyMembers,
                    apt.ChildrenCount,
                    apt.HasDebt ? "Да" : "Нет",
                    apt.Notes
                );
            }
        }

        private void UpdateStatistics_IvanovIA()
        {
            if (apartments.Count == 0)
            {
                labelTotal_IvanovIA.Text = "Всего квартир: 0";
                labelAvgArea_IvanovIA.Text = "Средняя площадь: 0 м²";
                labelDebt_IvanovIA.Text = "С задолженностью: 0";
                labelChildren_IvanovIA.Text = "Всего детей: 0";
                labelMinArea_IvanovIA.Text = "Мин. площадь: 0 м²";
                labelMaxArea_IvanovIA.Text = "Макс. площадь: 0 м²";
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
    }
}