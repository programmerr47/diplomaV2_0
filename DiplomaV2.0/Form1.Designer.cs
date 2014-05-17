namespace DiplomaV2._0
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportVtkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lagranghToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseGridA = new System.Windows.Forms.DataGridView();
            this.aXColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aYColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aZColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aXIndColumnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aYIndColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aZIndColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.dataBaseGridB = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportFile = new System.Windows.Forms.SaveFileDialog();
            this.hintLabel1 = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.loadingIndicator = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseGridA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseGridB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.calculationsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.LoadToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.exportVtkToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.newFileToolStripMenuItem.Text = "Новый проект";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.LoadToolStripMenuItem.Text = "Загрузить данные";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить данные";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // exportVtkToolStripMenuItem
            // 
            this.exportVtkToolStripMenuItem.Name = "exportVtkToolStripMenuItem";
            this.exportVtkToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exportVtkToolStripMenuItem.Text = "Экспорт в vtk";
            this.exportVtkToolStripMenuItem.Click += new System.EventHandler(this.exportVtkToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.closeToolStripMenuItem.Text = "Выход";
            // 
            // calculationsToolStripMenuItem
            // 
            this.calculationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.methodsToolStripMenuItem,
            this.calcToolStripMenuItem});
            this.calculationsToolStripMenuItem.Name = "calculationsToolStripMenuItem";
            this.calculationsToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.calculationsToolStripMenuItem.Text = "Вычисления";
            // 
            // methodsToolStripMenuItem
            // 
            this.methodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lagranghToolStripMenuItem,
            this.linearFunctionsToolStripMenuItem});
            this.methodsToolStripMenuItem.Name = "methodsToolStripMenuItem";
            this.methodsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.methodsToolStripMenuItem.Text = "Метод вычисления";
            // 
            // lagranghToolStripMenuItem
            // 
            this.lagranghToolStripMenuItem.Name = "lagranghToolStripMenuItem";
            this.lagranghToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.lagranghToolStripMenuItem.Text = "Метод лагранжа";
            this.lagranghToolStripMenuItem.Click += new System.EventHandler(this.lagranghToolStripMenuItem_Click);
            // 
            // linearFunctionsToolStripMenuItem
            // 
            this.linearFunctionsToolStripMenuItem.Name = "linearFunctionsToolStripMenuItem";
            this.linearFunctionsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.linearFunctionsToolStripMenuItem.Text = "Кусочно-линейные функции";
            this.linearFunctionsToolStripMenuItem.Click += new System.EventHandler(this.linearFunctionsToolStripMenuItem_Click);
            // 
            // calcToolStripMenuItem
            // 
            this.calcToolStripMenuItem.Name = "calcToolStripMenuItem";
            this.calcToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.calcToolStripMenuItem.Text = "Вычислить";
            this.calcToolStripMenuItem.Click += new System.EventHandler(this.calcToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // dataBaseGridA
            // 
            this.dataBaseGridA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBaseGridA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aXColumn,
            this.aYColumn,
            this.aZColumn,
            this.aXIndColumnt,
            this.aYIndColumn,
            this.aZIndColumn});
            this.dataBaseGridA.Location = new System.Drawing.Point(0, 44);
            this.dataBaseGridA.Name = "dataBaseGridA";
            this.dataBaseGridA.Size = new System.Drawing.Size(365, 464);
            this.dataBaseGridA.TabIndex = 1;
            // 
            // aXColumn
            // 
            this.aXColumn.HeaderText = "Ax";
            this.aXColumn.Name = "aXColumn";
            this.aXColumn.Width = 50;
            // 
            // aYColumn
            // 
            this.aYColumn.HeaderText = "Ay";
            this.aYColumn.Name = "aYColumn";
            this.aYColumn.Width = 50;
            // 
            // aZColumn
            // 
            this.aZColumn.DividerWidth = 20;
            this.aZColumn.HeaderText = "Az";
            this.aZColumn.Name = "aZColumn";
            this.aZColumn.Width = 70;
            // 
            // aXIndColumnt
            // 
            this.aXIndColumnt.HeaderText = "Ax Ind";
            this.aXIndColumnt.Name = "aXIndColumnt";
            this.aXIndColumnt.Width = 50;
            // 
            // aYIndColumn
            // 
            this.aYIndColumn.HeaderText = "Ay Ind";
            this.aYIndColumn.Name = "aYIndColumn";
            this.aYIndColumn.Width = 50;
            // 
            // aZIndColumn
            // 
            this.aZIndColumn.HeaderText = "Az Ind";
            this.aZIndColumn.Name = "aZIndColumn";
            this.aZIndColumn.Width = 50;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // dataBaseGridB
            // 
            this.dataBaseGridB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBaseGridB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dataBaseGridB.Location = new System.Drawing.Point(364, 44);
            this.dataBaseGridB.Name = "dataBaseGridB";
            this.dataBaseGridB.Size = new System.Drawing.Size(364, 464);
            this.dataBaseGridB.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Bx";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "By";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DividerWidth = 20;
            this.dataGridViewTextBoxColumn9.HeaderText = "Bz";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Bx Ind";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "By Ind";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Bz Ind";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 50;
            // 
            // hintLabel1
            // 
            this.hintLabel1.AutoSize = true;
            this.hintLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hintLabel1.Location = new System.Drawing.Point(361, 24);
            this.hintLabel1.Name = "hintLabel1";
            this.hintLabel1.Size = new System.Drawing.Size(310, 17);
            this.hintLabel1.TabIndex = 3;
            this.hintLabel1.Text = "Нажмите на пустую ячейку и введите данные";
            // 
            // calculateButton
            // 
            this.calculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateButton.Location = new System.Drawing.Point(364, 514);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(117, 42);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Вычислить";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // loadingIndicator
            // 
            this.loadingIndicator.Location = new System.Drawing.Point(12, 528);
            this.loadingIndicator.Name = "loadingIndicator";
            this.loadingIndicator.Size = new System.Drawing.Size(100, 16);
            this.loadingIndicator.TabIndex = 5;
            this.loadingIndicator.TabStop = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadingLabel.Location = new System.Drawing.Point(118, 528);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(165, 16);
            this.loadingLabel.TabIndex = 6;
            this.loadingLabel.Text = "Данные загружаются";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 557);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.loadingIndicator);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.hintLabel1);
            this.Controls.Add(this.dataBaseGridB);
            this.Controls.Add(this.dataBaseGridA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseGridA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseGridB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calcToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataBaseGridA;
        private System.Windows.Forms.ToolStripMenuItem lagranghToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearFunctionsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.DataGridView dataBaseGridB;
        private System.Windows.Forms.DataGridViewTextBoxColumn aXColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aYColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aZColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aXIndColumnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn aYIndColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aZIndColumn;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.ToolStripMenuItem exportVtkToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog exportFile;
        private System.Windows.Forms.Label hintLabel1;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.PictureBox loadingIndicator;
        private System.Windows.Forms.Label loadingLabel;

    }
}

