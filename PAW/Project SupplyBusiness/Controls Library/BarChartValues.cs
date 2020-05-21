using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls_Library
{
    public class BarChartValues
    {
        public string Label { get; set; }
        public float Value { get; set; }

        public BarChartValues(string label, float value)
        {
            Label = label;
            Value = value;
        }
    }
}
