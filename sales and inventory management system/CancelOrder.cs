using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_and_inventory_management_system
{
    public partial class CancelOrder : Form
    {
        DailySale dailySale;
        public CancelOrder(DailySale sale)
        {
            InitializeComponent();
            dailySale = sale;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboInventory.Text != string.Empty && udCancelQty.Value > 0 && txtReason.Text != string.Empty)
                {
                    if (int.Parse(txtQty.Text) >= udCancelQty.Value)
                    {
                        Void @void = new Void(this);
                        @void.txtUsername.Focus();
                        @void.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ReloadSoldList()
        {
            dailySale.LoadSold();
        }

        private void cboInventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
