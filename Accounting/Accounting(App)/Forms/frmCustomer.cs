using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting_DataLayer.Context;
namespace Accounting_App_
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frmAdd = new frmAddOrEdit();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frmEdit = new frmAddOrEdit();
            frmEdit.ContactID = int.Parse(dgvCustomer.CurrentRow.Cells[0].Value.ToString());
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        void BindGrid()
        {
            txtFilter.Text = null;
            using (UnitOfWork Un = new UnitOfWork())
            {
                dgvCustomer.AutoGenerateColumns = false;
                dgvCustomer.DataSource = Un.Customers.Get();
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                string Name = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show($"Are you that you want to delete {Name}?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (UnitOfWork Un = new UnitOfWork())
                    {
                        Un.Customers.Delete(int.Parse(dgvCustomer.CurrentRow.Cells[0].Value.ToString()));
                        Un.Save();
                        BindGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("please select one row");
            }
        }

        private void cbNight_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNight.Checked)
            {
                toolStrip1.ForeColor = Color.White;
                toolStrip1.BackColor = Color.Black;

                toolStrip2.ForeColor = Color.White;
                toolStrip2.BackColor = Color.Black;

                cbNight.ForeColor = Color.White;
                cbNight.BackColor = Color.Black;

                txtFilter.BackColor = Color.DarkCyan;
            }
            else
            {
                toolStrip1.BackColor = default;
                toolStrip1.ForeColor = default;

                toolStrip2.ForeColor = default;
                toolStrip2.BackColor = default;

                cbNight.ForeColor = default;
                cbNight.BackColor = default;

                txtFilter.BackColor = default;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            UnitOfWork Un = new UnitOfWork();
            dgvCustomer.DataSource = Un.Customers.Get(a => a.FullName.Contains(txtFilter.Text));
        }

        private void frmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
