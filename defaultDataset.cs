using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace groundstation
{
    internal class defaultDataset
    {
        public defaultDataset() { }

        public defaultDataset(string type)
        {
            //if (type == "default")
            //{
            //    Tmp = 30;
            //    P = 101;
            //    B = 5;
            //    H = 46;
            //}
            //else
            //{
            //    throw new ArgumentException();
            //}
        }
        private double multiplyWithRandBtw(double variable, double minVal, double maxVal)
        {
            Random rand = new Random();
            variable *= rand.NextDouble() * (maxVal - minVal) + minVal;
            return variable;
        }
        public string C { get; set; }
        public long T { get; set; }
        public double A { get; set; }
        public double Tmp { get; set; }
        public int P { get; set; }
        public int H { get; set; }
        public double B { get; set; }
        public GPS GPS { get; set; }
        public Acceleration Acc { get; set; }
        public Gyro Gyro { get; set; }
        public string S { get; set; }
    }
    public class GPS
    {
        public double Long { get; set; }
        public double Lat { get; set; }
    }
    public class Acceleration
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
    public class Gyro
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
/*
{
    "ComputerName":"Sim",
    "Time":200,
    "Stage":"Launch",
    "Temperature":35,
    "Altitude":300,
    "Pressure":980,
    "Humidity":46,
    "GPS": [39.89010317933223, 32.77989826916683],
    "Acceleration":[0,0,5.6],
    "Gyro":[0,0,0],
    "Battery Voltage":4.9
}
 */