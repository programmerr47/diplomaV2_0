namespace DiplomaV2._0
{
    partial class HelpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.filesPage = new System.Windows.Forms.TabPage();
            this.aboutTextBox = new System.Windows.Forms.TextBox();
            this.calcsPage = new System.Windows.Forms.TabPage();
            this.filesTextBox = new System.Windows.Forms.TextBox();
            this.calcsTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.aboutPage.SuspendLayout();
            this.filesPage.SuspendLayout();
            this.calcsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.aboutPage);
            this.tabControl1.Controls.Add(this.filesPage);
            this.tabControl1.Controls.Add(this.calcsPage);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 563);
            this.tabControl1.TabIndex = 0;
            // 
            // aboutPage
            // 
            this.aboutPage.Controls.Add(this.aboutTextBox);
            this.aboutPage.Location = new System.Drawing.Point(4, 22);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutPage.Size = new System.Drawing.Size(465, 537);
            this.aboutPage.TabIndex = 0;
            this.aboutPage.Text = "О программе";
            this.aboutPage.UseVisualStyleBackColor = true;
            // 
            // filesPage
            // 
            this.filesPage.Controls.Add(this.filesTextBox);
            this.filesPage.Location = new System.Drawing.Point(4, 22);
            this.filesPage.Name = "filesPage";
            this.filesPage.Padding = new System.Windows.Forms.Padding(3);
            this.filesPage.Size = new System.Drawing.Size(465, 537);
            this.filesPage.TabIndex = 1;
            this.filesPage.Text = "Работа с файлами";
            this.filesPage.UseVisualStyleBackColor = true;
            // 
            // aboutTextBox
            // 
            this.aboutTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.aboutTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutTextBox.Location = new System.Drawing.Point(3, 0);
            this.aboutTextBox.Multiline = true;
            this.aboutTextBox.Name = "aboutTextBox";
            this.aboutTextBox.ReadOnly = true;
            this.aboutTextBox.Size = new System.Drawing.Size(462, 541);
            this.aboutTextBox.TabIndex = 0;
            // 
            // calcsPage
            // 
            this.calcsPage.Controls.Add(this.calcsTextBox);
            this.calcsPage.Location = new System.Drawing.Point(4, 22);
            this.calcsPage.Name = "calcsPage";
            this.calcsPage.Size = new System.Drawing.Size(465, 537);
            this.calcsPage.TabIndex = 2;
            this.calcsPage.Text = "Вычисления";
            this.calcsPage.UseVisualStyleBackColor = true;
            // 
            // filesTextBox
            // 
            this.filesTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.filesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filesTextBox.Location = new System.Drawing.Point(1, -2);
            this.filesTextBox.Multiline = true;
            this.filesTextBox.Name = "filesTextBox";
            this.filesTextBox.ReadOnly = true;
            this.filesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.filesTextBox.Size = new System.Drawing.Size(462, 541);
            this.filesTextBox.TabIndex = 1;
            // 
            // calcsTextBox
            // 
            this.calcsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.calcsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcsTextBox.Location = new System.Drawing.Point(1, -2);
            this.calcsTextBox.Multiline = true;
            this.calcsTextBox.Name = "calcsTextBox";
            this.calcsTextBox.ReadOnly = true;
            this.calcsTextBox.Size = new System.Drawing.Size(462, 541);
            this.calcsTextBox.TabIndex = 1;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 575);
            this.Controls.Add(this.tabControl1);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.aboutPage.ResumeLayout(false);
            this.aboutPage.PerformLayout();
            this.filesPage.ResumeLayout(false);
            this.filesPage.PerformLayout();
            this.calcsPage.ResumeLayout(false);
            this.calcsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage aboutPage;
        private System.Windows.Forms.TextBox aboutTextBox;
        private System.Windows.Forms.TabPage filesPage;
        private System.Windows.Forms.TabPage calcsPage;
        private System.Windows.Forms.TextBox filesTextBox;
        private System.Windows.Forms.TextBox calcsTextBox;

    }
}