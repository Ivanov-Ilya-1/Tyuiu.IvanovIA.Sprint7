using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tyuiu.IvanovIA.Sprint7.Project.V7.Lib;

namespace Tyuiu.IvanovIA.Sprint7.Project.V7
{
    public partial class FormChart_IvanovIA : Form
    {
        private List<ApartmentModel_IvanovIA> apartments;

        public FormChart_IvanovIA(List<ApartmentModel_IvanovIA> data)
        {
            apartments = data;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "График распределения квартир";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            // Заголовок
            Label labelTitle_IvanovIA = new Label();
            labelTitle_IvanovIA.Text = "Распределение квартир по количеству комнат";
            labelTitle_IvanovIA.Font = new Font("Arial", 14, FontStyle.Bold);
            labelTitle_IvanovIA.Location = new Point(50, 20);
            labelTitle_IvanovIA.Size = new Size(700, 30);
            labelTitle_IvanovIA.TextAlign = ContentAlignment.MiddleCenter;

            // PictureBox для графика
            PictureBox pictureBoxChart_IvanovIA = new PictureBox();
            pictureBoxChart_IvanovIA.Location = new Point(50, 70);
            pictureBoxChart_IvanovIA.Size = new Size(700, 450);
            pictureBoxChart_IvanovIA.BackColor = Color.White;
            pictureBoxChart_IvanovIA.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxChart_IvanovIA.Paint += PictureBoxChart_Paint_IvanovIA;

            // Кнопка закрытия
            Button buttonClose_IvanovIA = new Button();
            buttonClose_IvanovIA.Text = "Закрыть";
            buttonClose_IvanovIA.Location = new Point(350, 540);
            buttonClose_IvanovIA.Size = new Size(100, 30);
            buttonClose_IvanovIA.BackColor = Color.FromArgb(0, 120, 215);
            buttonClose_IvanovIA.ForeColor = Color.White;
            buttonClose_IvanovIA.FlatStyle = FlatStyle.Flat;
            buttonClose_IvanovIA.Click += (s, e) => this.Close();

            this.Controls.Add(labelTitle_IvanovIA);
            this.Controls.Add(pictureBoxChart_IvanovIA);
            this.Controls.Add(buttonClose_IvanovIA);
        }

        private void PictureBoxChart_Paint_IvanovIA(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // Считаем квартиры по комнатам
            Dictionary<int, int> roomsCount = new Dictionary<int, int>();

            foreach (var apt in apartments)
            {
                if (roomsCount.ContainsKey(apt.RoomsCount))
                {
                    roomsCount[apt.RoomsCount]++;
                }
                else
                {
                    roomsCount[apt.RoomsCount] = 1;
                }
            }

            if (roomsCount.Count == 0)
                return;

            // Настройки графика
            int maxValue = roomsCount.Values.Max();
            int barWidth = 80;
            int spacing = 40;
            int startX = 100;
            int startY = 400;
            int chartHeight = 300;

            // Оси
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, startX - 10, startY, startX + roomsCount.Count * (barWidth + spacing), startY);
            g.DrawLine(axisPen, startX, startY + 10, startX, startY - chartHeight - 10);

            // Подписи осей
            Font labelFont = new Font("Arial", 10);
            Brush labelBrush = Brushes.Black;

            g.DrawString("Количество квартир", labelFont, labelBrush, 10, 50);
            g.DrawString("Количество комнат", labelFont, labelBrush, 350, startY + 20);

            // Столбцы гистограммы
            Brush[] barBrushes = { Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Orange, Brushes.Purple };
            int barIndex = 0;

            foreach (var kvp in roomsCount.OrderBy(x => x.Key))
            {
                int rooms = kvp.Key;
                int count = kvp.Value;

                // Высота столбца
                int barHeight = (int)((double)count / maxValue * chartHeight);

                // Координаты столбца
                int x = startX + barIndex * (barWidth + spacing);
                int y = startY - barHeight;

                // Рисуем столбец
                Brush barBrush = barBrushes[barIndex % barBrushes.Length];
                g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                g.DrawRectangle(Pens.Black, x, y, barWidth, barHeight);

                // Подпись количества
                g.DrawString(count.ToString(), labelFont, labelBrush, x + barWidth / 2 - 10, y - 20);

                // Подпись комнат
                g.DrawString($"{rooms} комн.", labelFont, labelBrush, x + barWidth / 2 - 20, startY + 5);

                barIndex++;
            }

            // Легенда
            int legendY = 450;
            barIndex = 0;

            foreach (var kvp in roomsCount.OrderBy(x => x.Key))
            {
                int rooms = kvp.Key;

                g.FillRectangle(barBrushes[barIndex % barBrushes.Length],
                    50 + barIndex * 150, legendY, 20, 20);
                g.DrawRectangle(Pens.Black, 50 + barIndex * 150, legendY, 20, 20);
                g.DrawString($"{rooms} комнат", labelFont, labelBrush,
                    75 + barIndex * 150, legendY + 2);

                barIndex++;
            }
        }
    }
}