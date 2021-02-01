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
using Accounting_App_.Forms;
using Acounting_ViewModel_.Accounting;
using Accounting_Bussiness_;

namespace Accounting_App_
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
            //if (frm.ShowDialog() == DialogResult.OK) { }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmTransaction frm = new frmTransaction();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                Refresh();
            }
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
           if(frm.ShowDialog() == DialogResult.OK)
            {
                Refresh();
            }
        }

        private void btnOutcome_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.TReport = 2;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Refresh();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLoginControll frm = new frmLoginControll();
            frm.isEdit = false;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Refresh();
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginControll frm = new frmLoginControll();
            frm.isEdit = true;
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                Application.Restart();
            }
            
        }

        private void Refresh()
        {
            AccountingBalance Re = Account.ReportMainForm();
            lblIncome.Text = Re.recive.ToString("#,0");
            lblOutcome.Text = Re.Pay.ToString("#,0");
            lblBalance.Text = Re.Balance.ToString("#,0");
        }
    }
}
