using Accounting_DataLayer.Context;
using Acounting_ViewModel_.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_App_.Forms
{
    public partial class frmReport : Form
    {
        public int TReport = 1;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                List<ListCustomerViewModel> list = new List<ListCustomerViewModel>();
                list.Add(new ListCustomerViewModel()
                {
                    ColumnID = 0,
                    FullName = "Please select",
                });
                list.AddRange(db.Customers.Get().Select(a => new ListCustomerViewModel()
                {FullName = a.FullName,
                ColumnID = a.ColumnID
                }));
                cbCustomer.DataSource = list;
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "ColumnID";
            }
            Filter();
            this.Text = ((TReport == 1) ? "Income" : "Outcome") + " reports";
        }

        private void Filter()
        {
            dgvReport.Rows.Clear();
            using (UnitOfWork db = new UnitOfWork())
            {
                List<Accounting> resualt = new List<Accounting>();
                DateTime? StartTime;
                DateTime? EndTime;

                //Name Validator.........................
                if ((int)cbCustomer.SelectedValue != 0)
                {
                    resualt.AddRange(db.AccountingRepository.Get(a => a.TypeID == TReport && a.FullName.Contains(cbCustomer.Text)));
                }
                else
                {
                    resualt.AddRange(db.AccountingRepository.Get(a => a.TypeID == TReport));
                }
                //Time Validator.........................
                if (mtbFrom.Text != "    /  /")
                {
                    StartTime = Convert.ToDateTime(mtbFrom.Text);
                    resualt = resualt.Where(a => a.DateTitle >= StartTime.Value).ToList();
                }
                if (mtbTo.Text != "    /  /")
                {
                    EndTime = Convert.ToDateTime(mtbTo.Text);
                    resualt = resualt.Where(a => a.DateTitle >= EndTime.Value).ToList();
                }
                //Add to DataGridView....................
                foreach (var a in resualt)
                {
                    var FullName = db.Customers.Get(b => b.FullName == a.FullName).Select(b => a.FullName).ToList().First();
                    dgvReport.Rows.Add(a.ID, a.TypeID, FullName, a.Amount, a.Description, a.DateTitle);
                }
            }
        }
        //Button events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvReport.CurrentRow != null)
            {
                int ID = int.Parse(dgvReport.CurrentRow.Cells[0].Value.ToString());
                using (UnitOfWork db = new UnitOfWork())
                {
                    string Name = db.Customers.Get(b => b.ColumnID ==ID).Select(c =>c.FullName).ToList().First();
                    if (MessageBox.Show($"Are you sure that you want to delete {Name}?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        db.AccountingRepository.Delete(ID);
                        db.Save();
                        Filter();
                    }
                }
            }
            else { MessageBox.Show("Please select a transaction!", "Alert"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTransaction frm = new frmTransaction();

        }

        private void frmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
