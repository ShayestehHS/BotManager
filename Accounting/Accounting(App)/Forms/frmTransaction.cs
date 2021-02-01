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
using Acounting_ViewModel_.Customer;
using ValidationComponents;

namespace Accounting_App_.Forms
{
    public partial class frmTransaction : Form
    {

        UnitOfWork db = new UnitOfWork();
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            dgvPeoples.AutoGenerateColumns = false;
            dgvPeoples.DataSource = db.Customers.Get().Select(a => new { a.FullName, a.ColumnID, a.PhotoImage }).ToList();
        }

        //Button events
        private void btnCancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if (lblPerson.Visible != false)
                {
                    if (MessageBox.Show("Are you sure that you want to save it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //Accounting accounting = new Accounting()
                        //{
                        //    Amount = int.Parse(txtAmount.Value.ToString()),
                        //    DateTitle = DateTime.Now,
                        //    TypeID = (rbIncome.Checked == true) ? 1 : 2,
                        //    CustomerID = int.Parse(db.Customers.Get(a => a.FullName ==lblPerson.Text).Select(a => a.ColumnID).ToString()),
                        //    Description = txtDescription.Text,
                        //
                        //};
                        Accounting accounting = new Accounting();
                        accounting.FullName = dgvPeoples.CurrentRow.Cells[0].Value.ToString();
                        accounting.Amount = int.Parse(txtAmount.Value.ToString());
                        accounting.DateTitle = DateTime.Now;
                        accounting.TypeID = (rbIncome.Checked == true) ? 1 : 2;
                        accounting.Description = txtDescription.Text;
                        db.AccountingRepository.Insert(accounting);
                        db.Save();
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else { MessageBox.Show("Please Select a person!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please Fix the errors first!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                pcCustomer.ImageLocation = OpenFile.FileName;
            }
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ContactID = int.Parse(dgvPeoples.CurrentRow.Cells[2].Value.ToString());
            frm.ShowDialog(this);
        }
        //Others
        private void txtFilterPeoples_TextChanged(object sender, EventArgs e)
        {
            dgvPeoples.AutoGenerateColumns = false;
            dgvPeoples.DataSource = db.Customers.Get(a => a.FullName == txtFilterPeoples.Text).Select(a => a.FullName);
        }

        private void dgvPeoples_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditPerson.Visible = true;
            lblPerson.Visible = true;
            lblPerson.Text = dgvPeoples.CurrentRow.Cells[0].Value.ToString();
            label1.Text = "your selected person is :";

            string ImageName = dgvPeoples.CurrentRow.Cells[1].Value.ToString();
            pcCustomer.ImageLocation = Application.StartupPath + @"\..\..\Images/" + ImageName;
        }

        private void frmTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frm = new frmMain();
            DialogResult = DialogResult.OK;
        }
    }
}
