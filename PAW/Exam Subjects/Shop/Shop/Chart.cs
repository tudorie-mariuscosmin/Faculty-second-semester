using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Chart : Form
    {
        private List<Product> products;
        private List<Category> categories;
        public Chart(List<Product> products, List<Category> categories)
        {
            this.products = products;
            this.categories = categories;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            List<int> productCount = new List<int>();
            foreach (Category category in categories)
            {
                int count = products.Count(x => x.CategoryId == category.Id);
                productCount.Add(count);
            }


            float barWidth = e.ClipRectangle.Width / productCount.Count;
            int maxVal = productCount.Max();
            float scale = e.ClipRectangle.Height / maxVal;
            for(int i=0; i<productCount.Count; i++)
            {
                float barHeight = productCount[i] * scale;
                float barX = i * barWidth;
                float barY = e.ClipRectangle.Height - barHeight;

                e.Graphics.FillRectangle(Brushes.Blue, barX, barY,(float) 0.9 * barWidth, barHeight);
            }

        }
    }
}
