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
    public partial class ConflictControl : UserControl
    {
        public int ConflictIndex { get; set; }
        public EventHandler<int> ConflictSelected;
        public ConflictControl()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => TriggerSelection();
            }
            rdBtnCheck.Click += (s, e) => TriggerSelection();
        }

        public void SetData(PromotionConflict conflict, int index)
        {
            ConflictIndex = index;
            lblConflictNumber.Text = $"Conflict {index + 1}";
            lblExistingPromotion.Text = conflict.PromotionName;
            lblConflictingProduct.Text = string.Join(", ", conflict.ConflictingProductNames);
            lblDateRange.Text = $"{conflict.StartDate:yyyy-MM-dd} {conflict.EndDate:yyyy-MM-dd}";
            lblPriority.Text = conflict.Priority.ToString();
        }

        public void SetSelected(bool selected)
        {
            this.BackColor = selected ? Color.LightBlue : Color.White;
            rdBtnCheck.Checked = selected;
        }

        private void TriggerSelection()
        {
            ConflictSelected?.Invoke(this,ConflictIndex);
        }

    }
}
