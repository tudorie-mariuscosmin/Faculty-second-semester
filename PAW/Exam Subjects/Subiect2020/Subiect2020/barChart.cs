using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect2020
{
    public partial class barChart : Control
    {
        private Fleet data;
        public Fleet Data {
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
        public barChart()
        {
            data = new Fleet();
            InitializeComponent();
           
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var graphics = pe.Graphics;
            var clipRectangle = pe.ClipRectangle;
            if (data.vehicles.Count != 0)
            {
                var barWidth = clipRectangle.Width / data.vehicles.Count;
                var maxValue = Data.vehicles.Max(x => x.HorsePower);
                float scalingFactor = clipRectangle.Height / maxValue;

                int i = 0;
                foreach(var vehicle in data.vehicles)
                {

                    float barHeight = vehicle.HorsePower * scalingFactor;
                    float barX = barWidth * i;
                    float barY = clipRectangle.Height - barHeight;
                    graphics.FillRectangle(Brushes.Red, barX, barY, (float)(barWidth * 0.9), barHeight);
                    i++;
                }

            }
        }
    }
}
