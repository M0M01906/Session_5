using S5_1_.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S5_1_
{
    public partial class AddNewPromotion : Form
    {
        BelleCroissantLyonnaisEntities db = new BelleCroissantLyonnaisEntities();
        HttpClient httpClient = new HttpClient();
        List<Products> products = new List<Products>();
        List<PromotionConflict> conflicts = new List<PromotionConflict>();

        public AddNewPromotion()
        {
            InitializeComponent();
            InitializeHttpClient();
        }

        private void InitializeHttpClient()
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"staff:BCLyon2024"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
        }

        private void AddNewPromotion_Load(object sender, EventArgs e)
        {
            products = PromotionManagement.products;
            listBox1.Items.Clear();
            foreach (var i in products)
            {
                listBox1.Items.Add(i.ProductName);
            }

            cbDiscountType.Items.Clear();
            cbDiscountType.Items.Add("Percentage");
            cbDiscountType.Items.Add("FixedAmount");
            cbDiscountType.SelectedIndex = -1;

            if (Properties.Settings.Default.IsEdit)
            {
                string productIds = Properties.Settings.Default.ProductID;
                if (!string.IsNullOrWhiteSpace(productIds))
                {
                    List<int> applicableProducts = productIds
                        .Split(',')
                        .Select(id => int.TryParse(id, out int parsed) ? parsed : -1)
                        .Where(id => id != -1)
                        .ToList();

                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        string itemText = listBox1.Items[i].ToString();
                        var product = products.FirstOrDefault(p => p.ProductName == itemText);
                        if (product != null && applicableProducts.Contains(product.ProductId))
                        {
                            listBox1.SetSelected(i, true);
                        }
                    }
                }
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtStartDate.CustomFormat = "dd-MM-yyyy";
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtEndDate.CustomFormat = "dd-MM-yyyy";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int err = 0;

            if (string.IsNullOrWhiteSpace(inpPromotionName.Text)) { err++; errorProvider1.SetError(inpPromotionName, "Enter promo name!"); }
            if (cbDiscountType.Text == "") { err++; errorProvider1.SetError(cbDiscountType, "Select discount type!"); }
            if (inpDiscountValue.Value <= 0) { err++; errorProvider1.SetError(inpDiscountValue, "Discount value must be greater than 0."); }
            List<int> selectedProductsID = GetSelectedProductsID();
            if (selectedProductsID.Count == 0) { err++; errorProvider1.SetError(listBox1, "Select at least one product!"); }
            if (dtStartDate.Value == null) { err++; errorProvider1.SetError(dtStartDate, "Select start date!"); }
            if (dtEndDate.Value == null) { err++; errorProvider1.SetError(dtEndDate, "Select end date!"); }

            if (err == 0)
            {
                conflicts = await CheckForConflicts();
                if (conflicts.Count > 0)
                {
                    ShowConflictResolutionWizard();
                    return;
                }
                SavePromotion(selectedProductsID);
                /*  var IsEdit = Properties.Settings.Default.IsEdit;
                  var promo = IsEdit ? db.Promotions.FirstOrDefault(x => x.PromotionId == Properties.Settings.Default.PromoID) : new Promotion();

                  if (promo != null)
                  {
                      promo.PromotionName = inpPromotionName.Text;
                      promo.DiscountType = cbDiscountType.Text;
                      promo.DiscountValue = inpDiscountValue.Value;
                      promo.ApplicableProducts = string.Join(",", selectedProductsID);
                      promo.MinimumOrderValue = inpMinOrderValue.Value;
                      promo.Priority = (int)inpPriority.Value;
                      promo.StartDate = dtStartDate.Value;
                      promo.EndDate = dtEndDate.Value;

                      if (!IsEdit) db.Promotions.Add(promo);
                      db.SaveChanges();

                      MessageBox.Show(IsEdit ? "Product updated successfully!" : "Product added successfully!");
                      Close();*/
            }
            
        }


        private void SavePromotion(List<int> selectedProductsID)
        {
            var IsEdit = Properties.Settings.Default.IsEdit;
            var promo = IsEdit ? db.Promotions.FirstOrDefault(x => x.PromotionId == Properties.Settings.Default.PromoID) : new Promotion();

            if (promo != null)
            {
                promo.PromotionName = inpPromotionName.Text;
                promo.DiscountType = cbDiscountType.Text;
                promo.DiscountValue = inpDiscountValue.Value;
                promo.ApplicableProducts = string.Join(",", selectedProductsID);
                promo.MinimumOrderValue = inpMinOrderValue.Value;
                promo.Priority = (int)inpPriority.Value;
                promo.StartDate = dtStartDate.Value;
                promo.EndDate = dtEndDate.Value;

                if (!IsEdit) db.Promotions.Add(promo);
                db.SaveChanges();

                MessageBox.Show(IsEdit ? "Product updated successfully!" : "Product added successfully!");
                Close();
            }
        }

        private async Task<List<PromotionConflict>> CheckForConflicts()
        {
            List<PromotionConflict> detectedConflicts = new List<PromotionConflict>();
            List<int> selectedProductIds = GetSelectedProductsID();
            int currentPriority = (int)inpPriority.Value;
            DateTime startDate = dtStartDate.Value;
            DateTime endDate = dtEndDate.Value;

            try
            {
                var query = db.Promotions
                    .Where(p => p.Priority == currentPriority &&
                                p.StartDate <= endDate &&
                                p.EndDate >= startDate);

                if (Properties.Settings.Default.IsEdit)
                {
                    int promoId = Properties.Settings.Default.PromoID;
                    query = query.Where(p => p.PromotionId != promoId);
                }

                var potentialConflicts = query.ToList();

                foreach (var promotion in potentialConflicts)
                {
                    if (string.IsNullOrEmpty(promotion.ApplicableProducts)) continue;

                    var conflictProductIds = promotion.ApplicableProducts
                        .Split(',')
                        .Select(id => int.TryParse(id, out int parsed) ? parsed : -1)
                        .Where(id => id != -1 && selectedProductIds.Contains(id))
                        .ToList();

                    if (conflictProductIds.Count > 0)
                    {
                        var conflict = new PromotionConflict
                        {
                            PromotionId = promotion.PromotionId,
                            PromotionName = promotion.PromotionName,
                            Priority = promotion.Priority,
                            StartDate = promotion.StartDate,
                            EndDate = promotion.EndDate,
                            ConflictingProductIds = conflictProductIds,
                            ConflictingProductNames = products
                                .Where(p => conflictProductIds.Contains(p.ProductId))
                                .Select(p => p.ProductName)
                                .ToList()
                        };

                        detectedConflicts.Add(conflict);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for conflicts: " + ex.Message);
            }

            return detectedConflicts;
        }

        private void ShowConflictResolutionWizard()
        {
            var promotionData = new Promotion
            {
                PromotionName = inpPromotionName.Text,
                DiscountType = cbDiscountType.Text,
                DiscountValue = inpDiscountValue.Value,
                Priority = (int)inpPriority.Value,
                StartDate = dtStartDate.Value,
                EndDate = dtEndDate.Value,
                ApplicableProducts = string.Join(",", GetSelectedProductsID())
            };

            using (var conflictForm = new ConflictResolutionForm(conflicts, products, promotionData))
            {
                var result = conflictForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    inpPriority.Value = conflictForm.SelectedPriority;
                    dtStartDate.Value = conflictForm.SelectedStartDate;
                    dtEndDate.Value = conflictForm.SelectedEndDate;

                    for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
                    {
                        listBox1.SetSelected(listBox1.SelectedIndices[i], false);
                    }

                    foreach (var productId in conflictForm.SelectedProductIds)
                    {
                        var product = products.FirstOrDefault(p => p.ProductId == productId);
                        if (product != null)
                        {
                            int index = listBox1.Items.IndexOf(product.ProductName);
                            if (index >= 0)
                            {
                                listBox1.SetSelected(index, true);
                            }
                        }
                    }

                    var conflictForm5 = new ConflictResolution5(promotionData);
                    var finalResult = conflictForm5.ShowDialog();

                    if (finalResult == DialogResult.OK)
                    {
                        SavePromotionData(promotionData); 
                    }
                }
            }
        }

        private void SavePromotionData(Promotion promotion)
        {
            var existingPromotion = db.Promotions
                             .FirstOrDefault(p => p.Priority == promotion.Priority
                                              && p.StartDate == promotion.StartDate
                                              && p.EndDate == promotion.EndDate);

            if (existingPromotion != null)
            {
                // Update existing promotion data
                existingPromotion.PromotionName = promotion.PromotionName;
                existingPromotion.DiscountType = promotion.DiscountType;
                existingPromotion.DiscountValue = promotion.DiscountValue;
                existingPromotion.ApplicableProducts = promotion.ApplicableProducts;

                db.SaveChanges(); // Persist the changes
                MessageBox.Show("Promotion updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the promotion does not exist, you can insert a new one
                db.Promotions.Add(promotion);
                db.SaveChanges(); // Persist the new promotion
                MessageBox.Show("New promotion created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<int> GetSelectedProductsID()
        {
            var selectedIDs = new List<int>();
            foreach (var item in listBox1.SelectedItems)
            {
                var product = products.FirstOrDefault(p => p.ProductName == item.ToString());
                if (product != null)
                {
                    selectedIDs.Add(product.ProductId);
                }
            }
            return selectedIDs;
        }
    }
}
