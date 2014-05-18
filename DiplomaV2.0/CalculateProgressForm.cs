using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using DiplomaV2._0.calculations;
using DiplomaV2._0.calculations.implementations;
using DiplomaV2._0.utils;

namespace DiplomaV2._0
{
    public partial class CalculateProgressForm : Form
    {
        private Form1 pForm;
        private ICalculation calc;
        private string progressStatus;
        private bool forceClose;
        private Thread t1;

        public CalculateProgressForm(Form1 sender)
        {
            InitializeComponent();
            pForm = sender;
            //calc = CalculationFactory.createCalculation(utils.Properties.currentCalculateMethod);
            forceClose = true;

            Progress.getINSTANCE().clearProgress();
            progressTimer.Enabled = true;
            t1 = new Thread(calculateIntropolate);
            t1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            globalProgressBar.Value = Progress.getINSTANCE().getGlobalProgress();
            globalProgressLabel.Text = Progress.getINSTANCE().getGlobalProgress().ToString() + " %";
            progressStatusLabel.Text = progressStatus;
        }

        private void calculateIntropolate()
        {
            try
            {
                progressStatus = "Обработка начальных данных (первое окошко).";
                Database.getINSTANCE().setAPoints(Utils.parseStrings(pForm.getDatabaseA(), 0, 6));

                progressStatus = "Обработка искомых данных (второе окошко).";
                Database.getINSTANCE().setBPointsCoord(Utils.parseStrings(pForm.getDatabaseB(), 6, 9));

                progressStatus = "Расчет индукции в искомых точках.";
                calc.calculate();

                progressStatus = "Конвертация данных.";
                
                Utils.toStrings(pForm.getDatabaseB(), Database.getINSTANCE().getBPointsInd());

                Progress.getINSTANCE().addToProgress(100);

                MessageBox.Show("Расчет необходимых данных закончен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ThreadAbortException ex)
            {
                MessageBox.Show(ex.Message + "Некоторые данные могут быть не сохранены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Пожалуйста откорректируйте данные и попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Invoke(new ThreadStart(delegate
                {
                    button1.Visible = false;
                    forceClose = false;
                    pForm.Enabled = true;
                    this.Close();
                }));
            }
        }

        private void CalculateProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (forceClose)
                {
                    t1.Abort();
                    pForm.Enabled = true;
                }
        }
    }
}
