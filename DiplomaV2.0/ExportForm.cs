﻿using DiplomaV2._0.files;
using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        IFileWorker propertyWorker;

        public ExportForm(IFileWorker worker, IFileWorker propertyWorker)
        {
            InitializeComponent();
            this.worker = worker;
            this.propertyWorker = propertyWorker;
            ObservingTimer.Start();
        }

        private void ObservingTimer_Tick(object sender, EventArgs e)
        {

            int rectSizeX = -1;
            try { rectSizeX = Int32.Parse(xRecSize.Text); }
            catch (Exception ex) { rectSizeX = -1; }
            sizeX = rectSizeX;

            int rectSizeY = -1;
            try { rectSizeY = Int32.Parse(yRecSize.Text); }
            catch (Exception ex) { rectSizeY = -1; }
            sizeY = rectSizeY;

            int rectSizeZ = -1;
            try { rectSizeZ = Int32.Parse(zRecSize.Text); }
            catch (Exception ex) { rectSizeZ = -1; }
            sizeZ = rectSizeZ;

            int rectBeginX = -1;
            try { rectBeginX = Int32.Parse(xRecOffset.Text); }
            catch (Exception ex) { rectBeginX = -1; }
            offsetX = rectBeginX;

            int rectBeginY = -1;
            try { rectBeginY = Int32.Parse(yRecOffset.Text); }
            catch (Exception ex) { rectBeginY = -1; }
            offsetY = rectBeginY;

            int rectBeginZ = -1;
            try { rectBeginZ = Int32.Parse(zRecOffset.Text); }
            catch (Exception ex) { rectBeginZ = -1; }
            offsetZ = rectBeginZ;

            int rectStepX = -1;
            try { rectStepX = Int32.Parse(xRecStep.Text); }
            catch (Exception ex) { rectStepX = -1; }
            stepX = rectStepX;

            int rectStepY = -1;
            try { rectStepY = Int32.Parse(yRecStep.Text); }
            catch (Exception ex) { rectStepY = -1; }
            stepY = rectStepY;

            int rectStepZ = -1;
            try { rectStepZ = Int32.Parse(zRecStep.Text); }
            catch (Exception ex) { rectStepZ = -1; }
            stepZ = rectStepZ;

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
            writeToFile(null);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            writeToFile(new int[] { sizeX, sizeY, sizeZ, offsetX, offsetY, offsetZ, stepX, stepY, stepZ });
        }

        private void writeToFile(int[] parameters)
        {
            worker.parseFileName();
            worker.writeInFile(parameters);

            DialogResult d = MessageBox.Show("Экспорт завершен. Вы хотите посмотреть результаты в ParaView?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (d == DialogResult.Yes)
            {
                if (!File.Exists(utils.Properties.currentPathToParaview))
                {
                    DialogResult d2 = MessageBox.Show("Последний указанный путь к Paraview недействителен. Хотите ли вы указать новый путь до Paraview?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (d == DialogResult.Yes)
                    {
                        if (openFile.ShowDialog() == DialogResult.OK)
                        {
                            if (System.IO.File.Exists(openFile.FileName))
                            {
                                utils.Properties.currentPathToParaview = openFile.FileName; 
                                propertyWorker.writeInFile(null);
                            }
                        }
                    }
                    else if (d == DialogResult.No)
                    {
                        return;
                    }
                }

                ProcessStartInfo infoStartProcess = new ProcessStartInfo();

                //infoStartProcess.WorkingDirectory = pathToDirectory;
                infoStartProcess.FileName = utils.Properties.currentPathToParaview;

                Process.Start(infoStartProcess);
            }
            else if (d == DialogResult.No)
            {
                return;
            }
        }
    }
}
