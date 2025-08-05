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
    public partial class ConflictResolution4 : Form
    {
        BelleCroissantLyonnaisEntities db = new BelleCroissantLyonnaisEntities();
        private Promotion promotionData;
        private bool isConflictResolved = false;
        public PromotionConflict Conflict { get; }
        private List<Products> newProducts;


        public ConflictResolution4(PromotionConflict conflict, Promotion promotionData, List<Products> products)
        {
            InitializeComponent();
            Conflict = conflict;
            this.promotionData = promotionData;
            this.newProducts = products;
        }

        private void dtNewStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtNewStartDate.CustomFormat = "yyyy-MM-dd";
            CheckDateOverlap();
        }

        private void CheckDateOverlap()
        {
            DateTime newStartDate = dtNewStartDate.Value;
            DateTime newEndDate = dtNewEndDate.Value;

            if (newStartDate > newEndDate)
            {
                if (dtNewStartDate.Focused || dtNewEndDate.Focused)
                {
                    MessageBox.Show("Start date cannot be later than the end date.",
                                  "Invalid Date Range",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
                lblResolved.Visible = false;
                btnSave.Enabled = false;
                return;
            }

            bool isNonOverlapping = newEndDate < promotionData.StartDate || newStartDate > promotionData.EndDate;

            lblResolved.Visible = isNonOverlapping;
            btnSave.Enabled = isNonOverlapping;
            isConflictResolved = isNonOverlapping;
        }

        private void ConflictResolution4_Load(object sender, EventArgs e)
        {
            lblDateRange.Text = $"Current Date Range: {promotionData.StartDate:yyyy-MM-dd}  {promotionData.EndDate:yyyy-MM-dd}";

            var allProducts = db.Products.Select(p => p.ProductName).ToList();
            var filteredConflictingProducts = allProducts.Where(p => Conflict.ConflictingProductNames.Contains(p)).ToList();

            lstBxProducts.Items.Clear();
            foreach (var item in filteredConflictingProducts)
            {
                lstBxProducts.Items.Add(item);
            }
      /*      for (int i = 0; i < lstBxProducts.Items.Count; i++)
            {
                string product = lstBxProducts.Items[i].ToString();

                if (conflictingProducts.Contains(product))
                {
                    lstBxProducts.SetSelected(i, true);
                }
            }*/
        }

        private void dtNewEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtNewEndDate.CustomFormat = "yyyy-MM-dd";
            CheckDateOverlap();
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

        private void lstBxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool allSelected = true;

            for (int i = 0; i < lstBxProducts.Items.Count; i++)
            {
                if (!lstBxProducts.GetSelected(i))
                {
                    allSelected = false;
                    break;  
                }
            }

            if (allSelected)
            {
                lblResolved.Visible = true;
                btnSave.Enabled = true;
                isConflictResolved = true;
            }
            else
            {
                lblResolved.Visible = false;
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /* if (lstBxProducts.SelectedItems.Count > 0)
             {
                 // Remove selected products from the 'newProducts' list
                 foreach (var selectedItem in lstBxProducts.SelectedItems.Cast<string>().ToList())
                 {
                     newProducts.RemoveAll(p => p.ProductName == selectedItem);
                 }
                 var promotion = db.Promotions.FirstOrDefault(p => p.Priority == promotionData.Priority && p.StartDate == promotionData.StartDate && p.EndDate == promotionData.EndDate);
                 if (promotion != null)
                 {
                     promotion.StartDate = promotionData.StartDate;
                     promotion.EndDate = promotionData.EndDate;
                     promotion.Priority = promotionData.Priority;

                     List<int> updatedProductIds = new List<int>();

                     foreach (var product in newProducts)
                     {
                         var productId = db.Products.FirstOrDefault(p => p.ProductName == product.ProductName)?.ProductId;
                         if (productId != null)
                         {
                             updatedProductIds.Add(productId.Value);
                         }
                     }

                     promotion.ApplicableProducts = string.Join(",", updatedProductIds);
                     db.SaveChanges();

                     MessageBox.Show("Conflict resolved and promotion updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     MessageBox.Show("Promotion not found or conflict cannot be resolved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }

                 this.Close();  
             }
             else
             {
                 MessageBox.Show("Please select products to resolve the conflict.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }*/
            // Case 1: Conflict resolved by adjusting dates
            if (isConflictResolved) // Assume that isConflictResolved is true if the date adjustment is correct
            {
                // Debugging: Show the promotion data being used
                MessageBox.Show($"Looking to update promotion with:\nPriority: {promotionData.Priority}\nStart Date: {promotionData.StartDate:yyyy-MM-dd}\nEnd Date: {promotionData.EndDate:yyyy-MM-dd}",
                                 "Debugging", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update the promotionData with the new dates (directly updating the object)
                promotionData.StartDate = dtNewStartDate.Value.Date; // New start date
                promotionData.EndDate = dtNewEndDate.Value.Date;    // New end date

                // Pass the updated promotionData to the next form
                var conflictForm5 = new ConflictResolution5(promotionData); // Pass the updated promotionData
                conflictForm5.Show();
            }
            // Case 2: Conflict resolved by removing products
            else if (lstBxProducts.SelectedItems.Count > 0) // Case where the conflict is resolved by selecting products
            {
                // If conflict is resolved by removing products, remove the selected products
                foreach (var selectedItem in lstBxProducts.SelectedItems.Cast<string>().ToList())
                {
                    // Find the product in the newProducts list and remove it
                    newProducts.RemoveAll(p => p.ProductName == selectedItem);
                }

                // Debugging: Show the promotion data being used
                MessageBox.Show($"Looking to update promotion with:\nPriority: {promotionData.Priority}\nStart Date: {promotionData.StartDate:yyyy-MM-dd}\nEnd Date: {promotionData.EndDate:yyyy-MM-dd}",
                                 "Debugging", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Here, we update the `promotionData`'s ApplicableProducts field to reflect the updated products list
                List<int> updatedProductIds = new List<int>();

   /*             foreach (var product in newProducts)
                {
                    var productId = db.Products.FirstOrDefault(p => p.ProductName == product.ProductName)?.ProductId;
                    if (productId != null)
                    {
                        updatedProductIds.Add(productId.Value);
                    }
                }*/

                // Update the promotionData with the new list of applicable products
                promotionData.ApplicableProducts = string.Join(",", updatedProductIds);

                // Pass the updated promotionData to the next form
                var conflictForm5 = new ConflictResolution5(promotionData); // Pass the updated promotionData
                conflictForm5.Show();
            }
            else
            {
                // Show a message if no products are selected or no dates are adjusted
                MessageBox.Show("Please select products or adjust the dates to resolve the conflict.",
                                "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
