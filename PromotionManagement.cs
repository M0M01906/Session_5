using Newtonsoft.Json;
using S5_1_.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S5_1_
{
    public partial class PromotionManagement : Form
    {
        BelleCroissantLyonnaisEntities db = new BelleCroissantLyonnaisEntities();
        public static List<Products> products = new List<Products>();
        HttpClient HttpClient = new HttpClient();
        public PromotionManagement()
        {
            InitializeComponent();
            InitializeHttpClient();
        }

        private void InitializeHttpClient()
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("staff:BCLyon2024"));
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
        }

        private async void PromotionManagement_Load(object sender, EventArgs e)
        {
            await LoadProducts();
            populateDtgv();
        }

        public async Task LoadProducts()
        {
            try
            {
                string url = "http://192.168.0.101:2367/api/products";
                HttpResponseMessage response = await HttpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Products>>(json);
            }catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void populateDtgv()
        {
            dtgvPromotions.Rows.Clear();
            var promo = db.Promotions.ToList();
            foreach (var i in promo)
            {
                List<string> productNames = new List<string>();
                if (!string.IsNullOrEmpty(i.ApplicableProducts))
                {
                    var productIds = i.ApplicableProducts.Split(',')
                                                         .Select(id => int.TryParse(id, out var parsed) ? parsed : -1)
                                                         .Where(id => id != -1)
                                                         .ToList();
                    productNames = (from c in db.Products
                                    where productIds.Contains(c.ProductId)
                                    select c.ProductName).ToList();
                }

                string applicableProducts = string.Join(",", productNames);
                dtgvPromotions.Rows.Add(i.PromotionId, i.PromotionName, i.DiscountType, i.DiscountValue, applicableProducts, i.StartDate.ToString("yyyy-MM-dd"), i.EndDate.ToString("yyyy-MM-dd"), i.MinimumOrderValue, i.Priority, "Edit", "Delete");
            }
        }

        private void dtgvPromotions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex >= 0 && grid.Columns["Edit"].Index == e.ColumnIndex)
            {
                var id = (int)dtgvPromotions.Rows[e.RowIndex].Cells[0].Value;
                var promotion = db.Promotions.FirstOrDefault(x => x.PromotionId == id);
                var f = new AddNewPromotion();
                Properties.Settings.Default.PromoID = id;
                Properties.Settings.Default.ProductID = promotion.ApplicableProducts;
                Properties.Settings.Default.IsEdit = true;
                f.Text = "Edit Promotion";
                f.inpPromotionName.Text = promotion.PromotionName;  
                f.cbDiscountType.Text = promotion.DiscountType;
                f.inpDiscountValue.Value = promotion.DiscountValue;
                f.dtStartDate.Value = promotion.StartDate;
                f.dtEndDate.Value = promotion.EndDate;
                f.inpMinOrderValue.Value = promotion.MinimumOrderValue.HasValue ? promotion.MinimumOrderValue.Value : 0m;
                f.inpPriority.Value = promotion.Priority;
                f.FormClosed += (s, args) =>
                {
                    db = new BelleCroissantLyonnaisEntities();
                    populateDtgv();
                };
                f.Show();
            } else if (e.RowIndex >= 0 && grid.Columns["Delete"].Index == e.ColumnIndex)
            {
                var id = (int)dtgvPromotions.Rows[e.RowIndex].Cells[0].Value;
                var promo = db.Promotions.FirstOrDefault(x => x.PromotionId == id);
                var result = MessageBox.Show("Are you sure you want to delete this promotion?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.Promotions.Remove(promo);
                    db.SaveChanges();
                    populateDtgv();
                    MessageBox.Show("Promotion deleted successfully!","Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new AddNewPromotion();
            Properties.Settings.Default.IsEdit = false;
            f.FormClosed += (s, args) =>
            {
                db = new BelleCroissantLyonnaisEntities();
                populateDtgv();
            };
            f.Show();
        }
    }
}
