using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConfrence
{
    public partial class barChart : Control
    {
        private int[] data;
        public int[] Data
        {
            get { return this.data; }
            set
            {
                data = value;
                Invalidate();
            }
        }
                
        
        public barChart()
        {
            data = new int[] { 1 };
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var clipRectangle = pe.ClipRectangle;
            var graphics = pe.Graphics;
            if (Data.Length > 0)
            {
                float barWidth = clipRectangle.Width / Data.Length;
                int maxValue = Data.Max(x => x);
                float scalingFactor = clipRectangle.Height / maxValue;
                int i = 0;
                foreach (int x in Data)
                {
                    float barHeight = x * scalingFactor;
                    float Xcord = i * barWidth;
                    float Ycord = clipRectangle.Height - barHeight;
                    graphics.FillRectangle(Brushes.Red, Xcord, Ycord, (float)0.9 * barWidth, barHeight);
                    i++;
                }
            }
        }
    }
}
