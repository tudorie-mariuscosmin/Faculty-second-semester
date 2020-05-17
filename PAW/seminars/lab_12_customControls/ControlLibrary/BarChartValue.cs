using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLibrary
{
    public class BarChartValue
    {
        public string Label { get; set; }
        public float Value { get; set; }

        public BarChartValue(string label, float value)
        {
            Label = label;
            Value = value;
        }
    }
}
