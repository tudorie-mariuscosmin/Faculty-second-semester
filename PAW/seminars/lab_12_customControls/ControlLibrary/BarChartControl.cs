using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary
{
    public partial class BarChartControl : Control
    {

        public BarChartValue[] data;
        public BarChartValue[] Data { get
            {
                return data;
            }
            set
            {
                data = value;
                Invalidate();
            }
        }


        

        public BarChartControl()
        {
            InitializeComponent();
            //Data = new BarChartValue[3];
            //Data[0] = new BarChartValue("2020", 100);
            Data = new BarChartValue[]
            {
                new BarChartValue("2020", 100),
                new BarChartValue("2021", 200),
                new BarChartValue("2022", 300)
            };
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var graphics = pe.Graphics;
            var clipRectangle = pe.ClipRectangle;


            var varWidth = clipRectangle.Width / Data.Length;

            var maxValue = Data.Max(x => x.Value);

            var scalingFactor = clipRectangle.Height / maxValue;

            for (var i=0; i < Data.Length; i++){

                var barHeight = Data[i].Value * scalingFactor;
                var barx = varWidth * i;
                var bary = clipRectangle.Height - barHeight;
                graphics.FillRectangle(Brushes.Blue, barx, bary,(float)0.9*varWidth, barHeight);

                

            }

        }
    }
}
