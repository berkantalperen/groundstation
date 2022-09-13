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
            if (type == "default")
            {
                Temperature = 30;
                Pressure = 101;
                BatteryVoltage = 5;
                Humidity = 46;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        private double multiplyWithRandBtw(double variable, double minVal, double maxVal)
        {
            Random rand = new Random();
            variable *= rand.NextDouble() * (maxVal - minVal) + minVal;
            return variable;
        }
        public string ComputerName { get; set; }
        public long Time { get; set; }
        public double Altitude { get; set; }
        public double Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double BatteryVoltage { get; set; }
        public GPS GPS { get; set; }
        public Acceleration Acceleration { get; set; }
        public Gyro Gyro { get; set; }
        public string Stage { get; set; }
    }
    public class GPS
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
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