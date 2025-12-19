namespace Tyuiu.IvanovIA.Sprint7.Project.V7
{
    partial class FormMain_IvanovIA
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain_IvanovIA = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem_IvanovIA = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem_IvanovIA = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem_IvanovIA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem_IvanovIA = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem_IvanovIA = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem_IvanovIA = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLoadData_IvanovIA = new System.Windows.Forms.Button();
            this.buttonSaveData_IvanovIA = new System.Windows.Forms.Button();
            this.buttonCreateTestData_IvanovIA = new System.Windows.Forms.Button();
            this.buttonShowChart_IvanovIA = new System.Windows.Forms.Button();
            this.panelSearch_IvanovIA = new System.Windows.Forms.Panel();
            this.labelSearch_IvanovIA = new System.Windows.Forms.Label();
            this.textBoxSearch_IvanovIA = new System.Windows.Forms.TextBox();
            this.buttonSearch_IvanovIA = new System.Windows.Forms.Button();
            this.dataGridViewApartments_IvanovIA = new System.Windows.Forms.DataGridView();
            this.panelStats_IvanovIA = new System.Windows.Forms.Panel();
            this.labelTotal_IvanovIA = new System.Windows.Forms.Label();
            this.labelAvgArea_IvanovIA = new System.Windows.Forms.Label();
            this.labelDebt_IvanovIA = new System.Windows.Forms.Label();
            this.labelChildren_IvanovIA = new System.Windows.Forms.Label();
            this.labelMinArea_IvanovIA = new System.Windows.Forms.Label();
            this.labelMaxArea_IvanovIA = new System.Windows.Forms.Label();
            this.buttonUpdateStats_IvanovIA = new System.Windows.Forms.Button();
            this.statusStripMain_IvanovIA = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo_IvanovIA = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain_IvanovIA.SuspendLayout();
            this.panelSearch_IvanovIA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments_IvanovIA)).BeginInit();
            this.panelStats_IvanovIA.SuspendLayout();
            this.statusStripMain_IvanovIA.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain_IvanovIA
            // 
            this.menuStripMain_IvanovIA.BackColor = System.Drawing.Color.White;
            this.menuStripMain_IvanovIA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem_IvanovIA,
            this.helpToolStripMenuItem_IvanovIA});
            this.menuStripMain_IvanovIA.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain_IvanovIA.Name = "menuStripMain_IvanovIA";
            this.menuStripMain_IvanovIA.Size = new System.Drawing.Size(1100, 24);
            this.menuStripMain_IvanovIA.TabIndex = 0;
            this.menuStripMain_IvanovIA.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem_IvanovIA
            // 
            this.fileToolStripMenuItem_IvanovIA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem_IvanovIA,
            this.saveToolStripMenuItem_IvanovIA,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem_IvanovIA});
            this.fileToolStripMenuItem_IvanovIA.Name = "fileToolStripMenuItem_IvanovIA";
            this.fileToolStripMenuItem_IvanovIA.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem_IvanovIA.Text = "Файл";
            // 
            // loadToolStripMenuItem_IvanovIA
            // 
            this.loadToolStripMenuItem_IvanovIA.Name = "loadToolStripMenuItem_IvanovIA";
            this.loadToolStripMenuItem_IvanovIA.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem_IvanovIA.Text = "Загрузить";
            this.loadToolStripMenuItem_IvanovIA.Click += new System.EventHandler(this.menuItemLoad_Click);
            // 
            // saveToolStripMenuItem_IvanovIA
            // 
            this.saveToolStripMenuItem_IvanovIA.Name = "saveToolStripMenuItem_IvanovIA";
            this.saveToolStripMenuItem_IvanovIA.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem_IvanovIA.Text = "Сохранить";
            this.saveToolStripMenuItem_IvanovIA.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem_IvanovIA
            // 
            this.exitToolStripMenuItem_IvanovIA.Name = "exitToolStripMenuItem_IvanovIA";
            this.exitToolStripMenuItem_IvanovIA.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem_IvanovIA.Text = "Выход";
            this.exitToolStripMenuItem_IvanovIA.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // helpToolStripMenuItem_IvanovIA
            // 
            this.helpToolStripMenuItem_IvanovIA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem_IvanovIA});
            this.helpToolStripMenuItem_IvanovIA.Name = "helpToolStripMenuItem_IvanovIA";
            this.helpToolStripMenuItem_IvanovIA.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem_IvanovIA.Text = "Справка";
            // 
            // aboutToolStripMenuItem_IvanovIA
            // 
            this.aboutToolStripMenuItem_IvanovIA.Name = "aboutToolStripMenuItem_IvanovIA";
            this.aboutToolStripMenuItem_IvanovIA.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem_IvanovIA.Text = "О программе";
            this.aboutToolStripMenuItem_IvanovIA.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // buttonLoadData_IvanovIA
            // 
            this.buttonLoadData_IvanovIA.Location = new System.Drawing.Point(20, 40);
            this.buttonLoadData_IvanovIA.Name = "buttonLoadData_IvanovIA";
            this.buttonLoadData_IvanovIA.Size = new System.Drawing.Size(120, 30);
            this.buttonLoadData_IvanovIA.TabIndex = 1;
            this.buttonLoadData_IvanovIA.Text = "Загрузить CSV";
            this.buttonLoadData_IvanovIA.UseVisualStyleBackColor = true;
            this.buttonLoadData_IvanovIA.Click += new System.EventHandler(this.buttonLoadData_IvanovIA_Click);
            // 
            // buttonSaveData_IvanovIA
            // 
            this.buttonSaveData_IvanovIA.Location = new System.Drawing.Point(150, 40);
            this.buttonSaveData_IvanovIA.Name = "buttonSaveData_IvanovIA";
            this.buttonSaveData_IvanovIA.Size = new System.Drawing.Size(120, 30);
            this.buttonSaveData_IvanovIA.TabIndex = 2;
            this.buttonSaveData_IvanovIA.Text = "Сохранить CSV";
            this.buttonSaveData_IvanovIA.UseVisualStyleBackColor = true;
            this.buttonSaveData_IvanovIA.Click += new System.EventHandler(this.buttonSaveData_IvanovIA_Click);
            // 
            // buttonCreateTestData_IvanovIA
            // 
            this.buttonCreateTestData_IvanovIA.Location = new System.Drawing.Point(280, 40);
            this.buttonCreateTestData_IvanovIA.Name = "buttonCreateTestData_IvanovIA";
            this.buttonCreateTestData_IvanovIA.Size = new System.Drawing.Size(120, 30);
            this.buttonCreateTestData_IvanovIA.TabIndex = 3;
            this.buttonCreateTestData_IvanovIA.Text = "Тестовые данные";
            this.buttonCreateTestData_IvanovIA.UseVisualStyleBackColor = true;
            this.buttonCreateTestData_IvanovIA.Click += new System.EventHandler(this.buttonCreateTestData_IvanovIA_Click);
            // 
            // buttonShowChart_IvanovIA
            // 
            this.buttonShowChart_IvanovIA.Location = new System.Drawing.Point(410, 40);
            this.buttonShowChart_IvanovIA.Name = "buttonShowChart_IvanovIA";
            this.buttonShowChart_IvanovIA.Size = new System.Drawing.Size(120, 30);
            this.buttonShowChart_IvanovIA.TabIndex = 4;
            this.buttonShowChart_IvanovIA.Text = "Показать график";
            this.buttonShowChart_IvanovIA.UseVisualStyleBackColor = true;
            this.buttonShowChart_IvanovIA.Click += new System.EventHandler(this.buttonShowChart_IvanovIA_Click);
            // 
            // panelSearch_IvanovIA
            // 
            this.panelSearch_IvanovIA.Controls.Add(this.labelSearch_IvanovIA);
            this.panelSearch_IvanovIA.Controls.Add(this.textBoxSearch_IvanovIA);
            this.panelSearch_IvanovIA.Controls.Add(this.buttonSearch_IvanovIA);
            this.panelSearch_IvanovIA.Location = new System.Drawing.Point(20, 85);
            this.panelSearch_IvanovIA.Name = "panelSearch_IvanovIA";
            this.panelSearch_IvanovIA.Size = new System.Drawing.Size(400, 40);
            this.panelSearch_IvanovIA.TabIndex = 5;
            // 
            // labelSearch_IvanovIA
            // 
            this.labelSearch_IvanovIA.AutoSize = true;
            this.labelSearch_IvanovIA.Location = new System.Drawing.Point(3, 13);
            this.labelSearch_IvanovIA.Name = "labelSearch_IvanovIA";
            this.labelSearch_IvanovIA.Size = new System.Drawing.Size(104, 15);
            this.labelSearch_IvanovIA.TabIndex = 0;
            this.labelSearch_IvanovIA.Text = "Поиск по фамилии:";
            // 
            // textBoxSearch_IvanovIA
            // 
            this.textBoxSearch_IvanovIA.Location = new System.Drawing.Point(113, 10);
            this.textBoxSearch_IvanovIA.Name = "textBoxSearch_IvanovIA";
            this.textBoxSearch_IvanovIA.Size = new System.Drawing.Size(150, 23);
            this.textBoxSearch_IvanovIA.TabIndex = 1;
            // 
            // buttonSearch_IvanovIA
            // 
            this.buttonSearch_IvanovIA.Location = new System.Drawing.Point(269, 8);
            this.buttonSearch_IvanovIA.Name = "buttonSearch_IvanovIA";
            this.buttonSearch_IvanovIA.Size = new System.Drawing.Size(80, 25);
            this.buttonSearch_IvanovIA.TabIndex = 2;
            this.buttonSearch_IvanovIA.Text = "Найти";
            this.buttonSearch_IvanovIA.UseVisualStyleBackColor = true;
            this.buttonSearch_IvanovIA.Click += new System.EventHandler(this.buttonSearch_IvanovIA_Click);
            // 
            // dataGridViewApartments_IvanovIA
            // 
            this.dataGridViewApartments_IvanovIA.AllowUserToAddRows = false;
            this.dataGridViewApartments_IvanovIA.AllowUserToDeleteRows = false;
            this.dataGridViewApartments_IvanovIA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApartments_IvanovIA.Location = new System.Drawing.Point(20, 135);
            this.dataGridViewApartments_IvanovIA.Name = "dataGridViewApartments_IvanovIA";
            this.dataGridViewApartments_IvanovIA.ReadOnly = true;
            this.dataGridViewApartments_IvanovIA.Size = new System.Drawing.Size(1050, 350);
            this.dataGridViewApartments_IvanovIA.TabIndex = 6;
            // 
            // panelStats_IvanovIA
            // 
            this.panelStats_IvanovIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats_IvanovIA.Controls.Add(this.labelTotal_IvanovIA);
            this.panelStats_IvanovIA.Controls.Add(this.labelAvgArea_IvanovIA);
            this.panelStats_IvanovIA.Controls.Add(this.labelDebt_IvanovIA);
            this.panelStats_IvanovIA.Controls.Add(this.labelChildren_IvanovIA);
            this.panelStats_IvanovIA.Controls.Add(this.labelMinArea_IvanovIA);
            this.panelStats_IvanovIA.Controls.Add(this.labelMaxArea_IvanovIA);
            this.panelStats_IvanovIA.Controls.Add(this.buttonUpdateStats_IvanovIA);
            this.panelStats_IvanovIA.Location = new System.Drawing.Point(20, 500);
            this.panelStats_IvanovIA.Name = "panelStats_IvanovIA";
            this.panelStats_IvanovIA.Size = new System.Drawing.Size(1050, 120);
            this.panelStats_IvanovIA.TabIndex = 7;
            // 
            // labelTotal_IvanovIA
            // 
            this.labelTotal_IvanovIA.AutoSize = true;
            this.labelTotal_IvanovIA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotal_IvanovIA.Location = new System.Drawing.Point(20, 20);
            this.labelTotal_IvanovIA.Name = "labelTotal_IvanovIA";
            this.labelTotal_IvanovIA.Size = new System.Drawing.Size(104, 16);
            this.labelTotal_IvanovIA.TabIndex = 0;
            this.labelTotal_IvanovIA.Text = "Всего квартир: 0";
            // 
            // labelAvgArea_IvanovIA
            // 
            this.labelAvgArea_IvanovIA.AutoSize = true;
            this.labelAvgArea_IvanovIA.Location = new System.Drawing.Point(20, 50);
            this.labelAvgArea_IvanovIA.Name = "labelAvgArea_IvanovIA";
            this.labelAvgArea_IvanovIA.Size = new System.Drawing.Size(119, 15);
            this.labelAvgArea_IvanovIA.TabIndex = 1;
            this.labelAvgArea_IvanovIA.Text = "Средняя площадь: 0 м²";
            // 
            // labelDebt_IvanovIA
            // 
            this.labelDebt_IvanovIA.AutoSize = true;
            this.labelDebt_IvanovIA.Location = new System.Drawing.Point(20, 80);
            this.labelDebt_IvanovIA.Name = "labelDebt_IvanovIA";
            this.labelDebt_IvanovIA.Size = new System.Drawing.Size(119, 15);
            this.labelDebt_IvanovIA.TabIndex = 2;
            this.labelDebt_IvanovIA.Text = "С задолженностью: 0";
            // 
            // labelChildren_IvanovIA
            // 
            this.labelChildren_IvanovIA.AutoSize = true;
            this.labelChildren_IvanovIA.Location = new System.Drawing.Point(250, 20);
            this.labelChildren_IvanovIA.Name = "labelChildren_IvanovIA";
            this.labelChildren_IvanovIA.Size = new System.Drawing.Size(77, 15);
            this.labelChildren_IvanovIA.TabIndex = 3;
            this.labelChildren_IvanovIA.Text = "Всего детей: 0";
            // 
            // labelMinArea_IvanovIA
            // 
            this.labelMinArea_IvanovIA.AutoSize = true;
            this.labelMinArea_IvanovIA.Location = new System.Drawing.Point(250, 50);
            this.labelMinArea_IvanovIA.Name = "labelMinArea_IvanovIA";
            this.labelMinArea_IvanovIA.Size = new System.Drawing.Size(95, 15);
            this.labelMinArea_IvanovIA.TabIndex = 4;
            this.labelMinArea_IvanovIA.Text = "Мин. площадь: 0 м²";
            // 
            // labelMaxArea_IvanovIA
            // 
            this.labelMaxArea_IvanovIA.AutoSize = true;
            this.labelMaxArea_IvanovIA.Location = new System.Drawing.Point(250, 80);
            this.labelMaxArea_IvanovIA.Name = "labelMaxArea_IvanovIA";
            this.labelMaxArea_IvanovIA.Size = new System.Drawing.Size(101, 15);
            this.labelMaxArea_IvanovIA.TabIndex = 5;
            this.labelMaxArea_IvanovIA.Text = "Макс. площадь: 0 м²";
            // 
            // buttonUpdateStats_IvanovIA
            // 
            this.buttonUpdateStats_IvanovIA.Location = new System.Drawing.Point(450, 40);
            this.buttonUpdateStats_IvanovIA.Name = "buttonUpdateStats_IvanovIA";
            this.buttonUpdateStats_IvanovIA.Size = new System.Drawing.Size(150, 30);
            this.buttonUpdateStats_IvanovIA.TabIndex = 6;
            this.buttonUpdateStats_IvanovIA.Text = "Обновить статистику";
            this.buttonUpdateStats_IvanovIA.UseVisualStyleBackColor = true;
            this.buttonUpdateStats_IvanovIA.Click += new System.EventHandler(this.buttonUpdateStats_IvanovIA_Click);
            // 
            // statusStripMain_IvanovIA
            // 
            this.statusStripMain_IvanovIA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo_IvanovIA});
            this.statusStripMain_IvanovIA.Location = new System.Drawing.Point(0, 648);
            this.statusStripMain_IvanovIA.Name = "statusStripMain_IvanovIA";
            this.statusStripMain_IvanovIA.Size = new System.Drawing.Size(1100, 22);
            this.statusStripMain_IvanovIA.TabIndex = 8;
            this.statusStripMain_IvanovIA.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo_IvanovIA
            // 
            this.toolStripStatusLabelInfo_IvanovIA.Name = "toolStripStatusLabelInfo_IvanovIA";
            this.toolStripStatusLabelInfo_IvanovIA.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabelInfo_IvanovIA.Text = "Готово к работе";
            // 
            // FormMain_IvanovIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 670);
            this.Controls.Add(this.statusStripMain_IvanovIA);
            this.Controls.Add(this.panelStats_IvanovIA);
            this.Controls.Add(this.dataGridViewApartments_IvanovIA);
            this.Controls.Add(this.panelSearch_IvanovIA);
            this.Controls.Add(this.buttonShowChart_IvanovIA);
            this.Controls.Add(this.buttonCreateTestData_IvanovIA);
            this.Controls.Add(this.buttonSaveData_IvanovIA);
            this.Controls.Add(this.buttonLoadData_IvanovIA);
            this.Controls.Add(this.menuStripMain_IvanovIA);
            this.MainMenuStrip = this.menuStripMain_IvanovIA;
            this.Name = "FormMain_IvanovIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Домоуправление - Иванов И.А. Вариант V7";
            this.menuStripMain_IvanovIA.ResumeLayout(false);
            this.menuStripMain_IvanovIA.PerformLayout();
            this.panelSearch_IvanovIA.ResumeLayout(false);
            this.panelSearch_IvanovIA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments_IvanovIA)).EndInit();
            this.panelStats_IvanovIA.ResumeLayout(false);
            this.panelStats_IvanovIA.PerformLayout();
            this.statusStripMain_IvanovIA.ResumeLayout(false);
            this.statusStripMain_IvanovIA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStripMain_IvanovIA;
        private ToolStripMenuItem fileToolStripMenuItem_IvanovIA;
        private ToolStripMenuItem loadToolStripMenuItem_IvanovIA;
        private ToolStripMenuItem saveToolStripMenuItem_IvanovIA;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem_IvanovIA;
        private ToolStripMenuItem helpToolStripMenuItem_IvanovIA;
        private ToolStripMenuItem aboutToolStripMenuItem_IvanovIA;
        private Button buttonLoadData_IvanovIA;
        private Button buttonSaveData_IvanovIA;
        private Button buttonCreateTestData_IvanovIA;
        private Button buttonShowChart_IvanovIA;
        private Panel panelSearch_IvanovIA;
        private Label labelSearch_IvanovIA;
        private TextBox textBoxSearch_IvanovIA;
        private Button buttonSearch_IvanovIA;
        private DataGridView dataGridViewApartments_IvanovIA;
        private Panel panelStats_IvanovIA;
        private Label labelTotal_IvanovIA;
        private Label labelAvgArea_IvanovIA;
        private Label labelDebt_IvanovIA;
        private Label labelChildren_IvanovIA;
        private Label labelMinArea_IvanovIA;
        private Label labelMaxArea_IvanovIA;
        private Button buttonUpdateStats_IvanovIA;
        private StatusStrip statusStripMain_IvanovIA;
        private ToolStripStatusLabel toolStripStatusLabelInfo_IvanovIA;
    }
}