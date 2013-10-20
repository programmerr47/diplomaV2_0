using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaV2._0
{
    class Database
    {
        private static Database INSTANCE = new Database();

        private double[,] aPoints;
        private double[,] bPointsCoord;
        private double[,] bPointsInd;

        public Database() {}

        public static Database getINSTANCE()
        {
            return INSTANCE;
        }

        public double[,] getAPoints()
        {
            return aPoints;
        }

        public double[,] getBPointsCoord()
        {
            return bPointsCoord;
        }

        public double[,] getBPointsInd()
        {
            return bPointsInd;
        }

        public void setAPoints(double[,] aPoints)
        {
            this.aPoints = aPoints;
        }

        public void setBPointsCoord(double[,] bPointsCoord)
        {
            this.bPointsCoord = bPointsCoord;
        }

        public void setBPointsInd(double[,] bPointsInd)
        {
            this.bPointsInd = bPointsInd;
        }
    }
}
