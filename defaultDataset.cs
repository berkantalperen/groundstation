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

        public string C { get; set; }
        public long? T { get; set; }
        public double? A { get; set; }
        public double? Tmp { get; set; }
        public int? P { get; set; }
        public int? H { get; set; }
        public double? B { get; set; }
        public GPS GPS { get; set; }
        public Acceleration Acc { get; set; }
        public Gyro Gyro { get; set; }
        public string S { get; set; }
    }
    public class GPS
    {
        public double Lon { get; set; }
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
