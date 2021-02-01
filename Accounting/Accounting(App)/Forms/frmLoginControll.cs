using Accounting_DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;

namespace Accounting_App_.Forms
{
    public partial class frmLoginControll : Form
    {
        public bool isEdit = false;
        public frmLoginControll()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using (UnitOfWork dn = new UnitOfWork())
                {
                    
                    if (!isEdit)
                    {
                        var Login = dn.LoginRepository;
                        if (Login.Get(a => a.Username == txtUsername.Text).Any())
                        {
                            if (dn.LoginRepository.Get(a => a.Password == txtPassword.Text).Any())
                            {
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("Your entered password is not correct");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your entered Username is not correct");
                        }
                    }
                    else
                    {
                        var Login = dn.LoginRepository.Get().First();
                        Login.Username = txtUsername.Text;
                        Login.Password = txtPassword.Text;
                        dn.LoginRepository.Update(Login);
                        dn.Save();
                        MessageBox.Show("Your ID is updted");
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fix errors first", "Error");
            }
        }

        private void frmLoginControll_Load(object sender, EventArgs e)
        {
            using (UnitOfWork dn = new UnitOfWork())
            {
                if (isEdit)
                {
                    var Login = dn.LoginRepository.Get().First();
                    txtUsername.Text = Login.Username;
                    txtPassword.Text = Login.Password;
                }
            }
        }
    }
}
