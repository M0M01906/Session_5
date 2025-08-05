using S5_1_.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S5_1_
{
    public partial class ConflictResolution5 : Form
    {
        private int promoPriority;
        private DateTime newStart;
        private DateTime newEnd;
        private List<string> newProducts;

        public int SelectedPriority { get; private set; }
        public DateTime SelectedStartDate { get; private set; }
        public DateTime SelectedEndDate { get; private set; }
        public List<int> SelectedProductIds { get; private set; }  // List to store selected product IDs
        public Promotion PromotionData { get; }

        public ConflictResolution5()
        {
            InitializeComponent();
            SelectedProductIds = new List<int>();  // Initialize the list to avoid null reference
        }

        public ConflictResolution5(Promotion promotionData)
        {
            InitializeComponent();
            PromotionData = promotionData;
            SelectedProductIds = new List<int>();  // Initialize the list to avoid null reference
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel the new/modified promotion?\nNo changes will be made to the database.",
                                         "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Changes cancelled. No modifications were made.");
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConflictResolution5_Load(object sender, EventArgs e)
        {
            if (PromotionData != null)
            {
                // Populate the form fields with the existing promotion data
                SelectedPriority = PromotionData.Priority;
                SelectedStartDate = PromotionData.StartDate;
                SelectedEndDate = PromotionData.EndDate;

                // Assuming 'ApplicableProducts' is a comma-separated string of product IDs in PromotionData
                if (!string.IsNullOrEmpty(PromotionData.ApplicableProducts))
                {
                    // Populate SelectedProductIds from the ApplicableProducts list
                    SelectedProductIds = PromotionData.ApplicableProducts.Split(',')
                                                       .Select(int.Parse)
                                                       .ToList();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Here, you might need to update the `SelectedPriority`, `SelectedStartDate`, `SelectedEndDate`,
            // and `SelectedProductIds` based on user changes to the form controls

            // For example, you might use controls like DateTimePicker or ListBox to get the user's selections

            // Example: Update the promotion data with selected values (if the user modified them)
            SelectedPriority = PromotionData.Priority;
            SelectedStartDate = PromotionData.StartDate;  // Update with the selected value from DateTimePicker (if applicable)
            SelectedEndDate = PromotionData.EndDate;      // Update with the selected value from DateTimePicker (if applicable)

            // You may update SelectedProductIds based on user selections
            // For example, if using a ListBox for product selection:
            // SelectedProductIds = lstBxProducts.SelectedItems.Cast<int>().ToList();

            // Display updated values for debugging or confirmation
            MessageBox.Show($"Selected Priority: {SelectedPriority}\n" +
                            $"Start Date: {SelectedStartDate:yyyy-MM-dd}\n" +
                            $"End Date: {SelectedEndDate:yyyy-MM-dd}\n" +
                            $"Selected Product IDs: {string.Join(", ", SelectedProductIds)}");

            // Close the form and signal that the changes were successfully made
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
