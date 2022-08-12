using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;

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

        public string ComputerName { get; set; }
        public long Time { get; set; }
        public string Stage { get; set; }
        public double[] GPS { get; set; }
        public double Temperature { get; set; }
        public int Pressure { get; set; }
        public double BatteryVoltage { get; set; }
        public double[] Acceleration { get; set; }
        public double[] Gyro { get; set; }
        public double Altitude { get; set; }
        public int Humidity { get; set; }
    }
}
