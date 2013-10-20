namespace DiplomaV2._0
{
    partial class CalculateProgressForm
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
            this.components = new System.ComponentModel.Container();
            this.globalProgressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.globalProgressLabel = new System.Windows.Forms.Label();
            this.progressStatusLabel = new System.Windows.Forms.Label();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // globalProgressBar
            // 
            this.globalProgressBar.Location = new System.Drawing.Point(12, 45);
            this.globalProgressBar.Name = "globalProgressBar";
            this.globalProgressBar.Size = new System.Drawing.Size(513, 30);
            this.globalProgressBar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Отменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Прогресс : ";
            // 
            // globalProgressLabel
            // 
            this.globalProgressLabel.AutoSize = true;
            this.globalProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.globalProgressLabel.Location = new System.Drawing.Point(482, 26);
            this.globalProgressLabel.Name = "globalProgressLabel";
            this.globalProgressLabel.Size = new System.Drawing.Size(30, 16);
            this.globalProgressLabel.TabIndex = 4;
            this.globalProgressLabel.Text = "0 %";
            // 
            // progressStatusLabel
            // 
            this.progressStatusLabel.AutoSize = true;
            this.progressStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressStatusLabel.Location = new System.Drawing.Point(109, 26);
            this.progressStatusLabel.Name = "progressStatusLabel";
            this.progressStatusLabel.Size = new System.Drawing.Size(13, 16);
            this.progressStatusLabel.TabIndex = 5;
            this.progressStatusLabel.Text = "-";
            // 
            // progressTimer
            // 
            this.progressTimer.Interval = 1;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // CalculateProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 126);
            this.Controls.Add(this.progressStatusLabel);
            this.Controls.Add(this.globalProgressLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.globalProgressBar);
            this.Name = "CalculateProgressForm";
            this.Text = "Состояние вычислений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalculateProgressForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar globalProgressBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label globalProgressLabel;
        private System.Windows.Forms.Label progressStatusLabel;
        private System.Windows.Forms.Timer progressTimer;
    }
}