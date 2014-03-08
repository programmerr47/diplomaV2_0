using DiplomaV2._0.files;
using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomaV2._0
{
    public partial class ExportForm : Form
    {
        int sizeX = -1;
        int sizeY = -1;
        int sizeZ = -1;
        int offsetX = -1;
        int offsetY = -1;
        int offsetZ = -1;
        int stepX = -1;
        int stepY = -1;
        int stepZ = -1;
        IFileWorker worker;

        public ExportForm(IFileWorker worker)
        {
            this.worker = worker;
            InitializeComponent();
        }

        private void ObservingTimer_Tick(object sender, EventArgs e)
        {

            int rectSizeX;
            try { rectSizeX = Int32.Parse(xRecSize.Text); }
            catch (Exception ex) { rectSizeX = -1; }
            sizeX = rectSizeX;

            int rectSizeY;
            try { rectSizeY = Int32.Parse(yRecSize.Text); }
            catch (Exception ex) { rectSizeY = -1; }
            sizeY = rectSizeY;

            int rectSizeZ;
            try { rectSizeZ = Int32.Parse(zRecSize.Text); }
            catch (Exception ex) { rectSizeZ = -1; }
            sizeZ = rectSizeZ;

            int rectBeginX;
            try { rectBeginX = Int32.Parse(xRecOffset.Text); }
            catch (Exception ex) { rectBeginX = -1; }
            offsetX = rectBeginX;

            int rectBeginY;
            try { rectBeginY = Int32.Parse(yRecOffset.Text); }
            catch (Exception ex) { rectBeginY = -1; }
            offsetY = rectBeginY;

            int rectBeginZ;
            try { rectBeginZ = Int32.Parse(zRecOffset.Text); }
            catch (Exception ex) { rectBeginZ = -1; }
            offsetZ = rectBeginZ;

            int rectStepX;
            try { rectStepX = Int32.Parse(xRecStep.Text); }
            catch (Exception ex) { rectStepX = -1; }
            stepX = rectSizeX;

            int rectStepY;
            try { rectStepY = Int32.Parse(yRecStep.Text); }
            catch (Exception ex) { rectStepY = -1; }
            stepY = rectSizeZ;

            int rectStepZ;
            try { rectStepZ = Int32.Parse(zRecStep.Text); }
            catch (Exception ex) { rectStepZ = -1; }
            stepZ = rectSizeZ;

            if ((sizeX != -1) && (sizeY != -1) && (sizeZ != -1) &&
                (offsetX != -1) && (offsetY != -1) && (offsetZ != -1) &&
                (stepX != -1) && (stepY != -1) && (stepZ != -1))
            {
                saveButton.Enabled = true;
            }
            else
            {
                saveButton.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void standartButton_Click(object sender, EventArgs e)
        {
            worker.parseFileName();
            worker.writeInFile(null);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int[] parameters = new int[] { sizeX, sizeY, sizeZ, offsetX, offsetY, offsetZ, stepX, stepY, stepZ };
            worker.parseFileName();
            worker.writeInFile(parameters);
        }
    }
}
