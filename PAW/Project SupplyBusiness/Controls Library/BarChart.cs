using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls_Library
{
    public partial class BarChart : Control
    {
        public BarChartValues[] data;
        public BarChartValues[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                Invalidate();
            }
        }

        public BarChart()
        {
            InitializeComponent();
            Data = new BarChartValues[]
            {
                new BarChartValues("2020", 100),
                new BarChartValues("2021", 200),
                new BarChartValues("2022", 300)
            };
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var graphics = pe.Graphics;
            var clipRectangle = pe.ClipRectangle;


            var varWidth = clipRectangle.Width / Data.Length;

            var maxValue = Data.Max(x => x.Value);

            var scalingFactor = (clipRectangle.Height-15 )/ maxValue;

            for (var i = 0; i < Data.Length; i++)
            {

                var barHeight = Data[i].Value * scalingFactor;
                var barx = varWidth * i;
                var bary = (clipRectangle.Height -15) - barHeight;
                Brush brush;
                if (Data[i].Value < 3)
                    brush = Brushes.Red;
                else if (Data[i].Value < 6)
                    brush = Brushes.Orange;
                else if (Data[i].Value < 9)
                    brush = Brushes.Yellow;
                else
                    brush = Brushes.Green;
                graphics.FillRectangle(brush, barx, bary, (float)0.9 * varWidth, barHeight);

                graphics.DrawString(Data[i].Label, SystemFonts.DefaultFont, Brushes.Black, barx, clipRectangle.Height-15);
                
            }
        }
    }
}
