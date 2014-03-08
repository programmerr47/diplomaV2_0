using DiplomaV2._0.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0.files
{
    class PropertyFileWorker : AbstractFileWorker
    {
        public PropertyFileWorker(Form1 pf) : base(pf) { }

        public override void writeInFile(int[] parameters)
        {
            StreamWriter streamWriter = File.CreateText(utils.Properties.directoryOfApp + utils.Properties.currentNamePropertyFile);
            streamWriter.WriteLine("decimalSeparator=" + utils.Properties.currentDecimalSeparator + "");
            streamWriter.WriteLine("pathToFile=" + utils.Properties.currentPathToFile + "");
            streamWriter.WriteLine("calculationMethod=" + utils.Properties.currentCalculateMethod + "");
            streamWriter.Close();
        }

        public override void readFromFile()
        {
            try
            {
                StreamReader streamReader = new StreamReader(utils.Properties.currentNamePropertyFile);
                string str;
                string[] comms;
                while (!streamReader.EndOfStream)
                {
                    str = streamReader.ReadLine();
                    comms = str.Split('=');
                    switch (comms[0])
                    {
                        case "decimalSeparator":
                            {
                                utils.Properties.currentDecimalSeparator = comms[1];
                                break;
                            }
                        case "pathToFile":
                            {
                                if (comms[1] != "-")
                                {
                                    utils.Properties.currentPathToFile = comms[1];
                                    parseFileName();
                                }
                                break;
                            }
                        case "calculationMethod":
                            {
                                try
                                {
                                    utils.Properties.currentCalculateMethod = (Utils.Calcs)Enum.Parse(typeof(Utils.Calcs), comms[1], true);
                                }
                                catch (ArgumentException ex)
                                {
                                    utils.Properties.currentCalculateMethod = Utils.Calcs.LAGRANGE;
                                }
                                break;
                            }
                    }
                }
                streamReader.Close();
            }
            catch (FileNotFoundException ex)
            {
                writeInFile();
            }
        }
    }
}
