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
    public partial class ConflictResolution3 : Form
    {
        public PromotionConflict Conflict { get; }
        public Promotion PromotionData { get; }
        public List<Products> Products { get; }

        public ConflictResolution3(PromotionConflict conflict, Promotion promotionData, List<Products> products)
        {
            InitializeComponent();
            Conflict = conflict;
            PromotionData = promotionData;
            Products = products;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var f = new ConflictResolution5();
            f.ShowDialog();
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value > PromotionData.Priority)
            {
                lblWarning.Visible = true;
            } else
            {
                lblWarning.Visible = false;
            }
        }

        private void ConflictResolution3_Load(object sender, EventArgs e)
        {
            lblPriority.Text = PromotionData.Priority.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ConflictResolution4 conflictForm4 = new ConflictResolution4(Conflict,PromotionData,Products);
            conflictForm4.Show();
        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            var priority = numericUpDown1.Value;
            lblWarning.Visible = priority > PromotionData.Priority;
        }
    }
}
