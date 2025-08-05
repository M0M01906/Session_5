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
    public partial class ConflictResolutionForm : Form
    {
        private List<PromotionConflict> conflicts;
        private List<Products> products;

        private int currentIndex = 0;
        private Promotion promotionData;

        public int SelectedPriority { get; private set; }
        public DateTime SelectedStartDate { get; private set; }
        public DateTime SelectedEndDate { get; private set; }
        public List<int> SelectedProductIds { get; private set; }

        public ConflictResolutionForm(List<PromotionConflict> conflicts, List<Products> products, Promotion promotionData)
        {
            InitializeComponent();
            this.conflicts = conflicts;
            this.products = products;
            this.promotionData = promotionData;
        }

        private void ConflictResolutionForm_Load(object sender, EventArgs e)
        {
            currentIndex = 0;
            LoadConflictList();
            LoadPromotiom();
        }

        private void LoadPromotiom()
        {
            lblName.Text = promotionData.PromotionName;
            if (promotionData.DiscountType.Equals("Percentage"))
            {
                lblDiscount.Text = "Percentage " + (int)promotionData.DiscountValue + "%";
            } else if (promotionData.DiscountType.Equals("FixedAmount"))
            {
                lblDiscount.Text = "FixedAmount " + promotionData.DiscountValue; 
            }
            lblProducts.Text = string.Join(", ", GetSelectedProductNames());
            lblDateRange.Text = $"{promotionData.StartDate:yyyy-MM-dd}  {promotionData.EndDate:yyyy-MM-dd}";
            lblPriority.Text = promotionData.Priority.ToString();

        }

        private List<String> GetSelectedProductNames()
        {
            return products
            .Where(p => promotionData.ApplicableProducts.Contains(p.ProductId.ToString()))
            .Select(p => p.ProductName)
            .ToList(); ;                        
        }
        
        private void LoadConflictList()
        {
            pnlConflicts.Controls.Clear();
            pnlConflicts.AutoScroll = true;
            int currentY = 0;
            for (int i = 0; i < conflicts.Count; i++)
            {
                var conflict = conflicts[i];

                var control = new ConflictControl();
                control.SetData(conflict, i);

                control.Width = pnlConflicts.Width - 25;
                control.Location = new Point(0, currentY);
                control.ConflictSelected += ConflictControl_Selected;

                pnlConflicts.Controls.Add(control);

                currentY += control.Height + 10;
            }
        }

        private void ConflictControl_Selected(object sender, int e)
        {
            foreach (Control c in pnlConflicts.Controls)
            {
                if (c is ConflictControl conflictItem)
                {
                    conflictItem.SetSelected(conflictItem.ConflictIndex == e);
                }
            }

            currentIndex = e;

            var selectedControl = pnlConflicts.Controls
                                  .OfType<ConflictControl>()
                                  .FirstOrDefault(c => c.ConflictIndex == e);

            if (selectedControl != null)
            {
                selectedControl.SetSelected(true);
            }

            //ShowConflictDetails(currentIndex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var f = new ConflictResolution5();
            f.ShowDialog();
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < 0 || currentIndex >= conflicts.Count)
            {
                MessageBox.Show("Please select a conflict first.");
                return;
            }

            var conflict = conflicts[currentIndex];

            // Create and open the summary form
            ConflictResolution2 summaryForm = new ConflictResolution2(
                 promotionData,
                 conflict,
                 products
            );

            summaryForm.ShowDialog();
        }
    }
}
