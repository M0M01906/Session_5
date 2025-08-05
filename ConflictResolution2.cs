using S5_1_.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S5_1_
{
    public partial class ConflictResolution2 : Form
    {
        BelleCroissantLyonnaisEntities db = new BelleCroissantLyonnaisEntities();
        private DateTime minDate;
        private DateTime maxDate;
        public Promotion PromotionData { get; }
        public PromotionConflict Conflict { get; }
        public List<Products> Products { get; }

        public ConflictResolution2(Promotion promotionData, PromotionConflict conflict, List<Products> products)
        {
            InitializeComponent();
            PromotionData = promotionData;
            Conflict = conflict;
            Products = products;

            minDate = new[] { promotionData.StartDate, conflict.StartDate }.Min();
            maxDate = new[] { promotionData.EndDate, conflict.EndDate }.Max();

            lblNewName.Text = promotionData.PromotionName;
            lblNewDateRange.Text = $"{promotionData.StartDate:yyyy-MM-dd} - {promotionData.EndDate:yyyy-MM-dd}";
            lblPriority.Text = promotionData.Priority.ToString();

            lblExistingName.Text = conflict.PromotionName;
            lblExistingDateRange.Text = $"{conflict.StartDate:yyyy-MM-dd} - {conflict.EndDate:yyyy-MM-dd}";
            lblExistingPriority.Text = conflict.Priority.ToString();
            lblConflictingProduct.Text = string.Join(",", conflict.ConflictingProductNames);

            panel1.Paint += PnlTimeline_Paint;

        }

        private void PnlTimeline_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            int barHeight = 20;
            int padding = 40;

            int totalDays = (maxDate - minDate).Days + 1;
            float scale = (panel1.Width - 100) / (float)totalDays;

            int x1 = (int)((Conflict.StartDate - minDate).Days * scale) + padding;
            int x2 = (int)((Conflict.EndDate - minDate).Days * scale) + padding;
            g.FillRectangle(Brushes.Red, x1, 10, x2 - x1, barHeight);
            g.DrawString(Conflict.PromotionName, this.Font, Brushes.Black, x1, 0);

            // Draw New Promotion bar
            int y = 50;
            int nx1 = (int)((PromotionData.StartDate - minDate).Days * scale) + padding;
            int nx2 = (int)((PromotionData.EndDate - minDate).Days * scale) + padding;
            g.FillRectangle(Brushes.Blue, nx1, y, nx2 - nx1, barHeight);
            g.DrawString(PromotionData.PromotionName, this.Font, Brushes.Black, nx1, y - 12);

            // Draw date labels
            g.DrawString(minDate.ToString("yyyy-MM-dd"), this.Font, Brushes.Black, 5, y + 30);
            g.DrawString(maxDate.ToString("yyyy-MM-dd"), this.Font, Brushes.Black, panel1.Width - 100, y + 30);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var f = new ConflictResolution5();
            f.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ConflictResolution3 conflictForm3 = new ConflictResolution3(Conflict, PromotionData, Products);
            conflictForm3.Show();
        }
    }
}
