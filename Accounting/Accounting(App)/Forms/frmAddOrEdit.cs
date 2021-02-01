using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using Accounting_DataLayer.Context;

namespace Accounting_App_
{
    public partial class frmAddOrEdit : Form
    {
        public int ContactID = 0;
        private string PathLo = Application.StartupPath + @"\..\..\Images/";
        public frmAddOrEdit()
        {
            InitializeComponent();
        }

        private void btnCancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                string ImageName = null;
                if (pcCustomer.ImageLocation == null || !(pcCustomer.ImageLocation.Contains("Man")) || !(pcCustomer.ImageLocation.Contains("Woman")) )
                {
                    ImageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                }
                else
                {
                    if (Check())
                    {
                        ImageName = "Man.png";
                    }
                    else
                    {
                        ImageName = "Woman.png";
                    };
                }
                pcCustomer.Image.Save(PathLo + ImageName);
                using (UnitOfWork Un = new UnitOfWork())
                {
                    Customers customer = new Customers
                    {
                        FullName = txtName.Text,
                        Age = (int)txtAge.Value,
                        Email = txtEmail.Text,
                        Address = txtAddres.Text,
                        Phone = txtPhone.Text,
                        PhotoImage = ImageName,
                    };
                    if (Check())
                    {
                        customer.Sex = "M";
                    }
                    else
                    {
                        customer.Sex = "W";
                    }
                    if (ContactID != 0)
                    {
                        //Edit Customer
                        customer.ColumnID = ContactID;
                        Un.Customers.Update(customer);
                    }
                    else
                    {
                        //New Customer
                        Un.Customers.Insert(customer);
                    }
                    Un.Save();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            MessageBox.Show("(dark mode) is not completed" +
                "///////" +
                "(radif kenari dar dgv) is not complete" +
                "///////" +
                "(instal app)is not created" +
                "////" +
                "(bisines) is not created" +
                "////"+
                "(user validation) is not created"+
                "////"+
                "(setting in this form) is not created"+
                "////"+
                "(Message box) are not completed");
            if (ContactID != 0)
            {
                using (UnitOfWork Un = new UnitOfWork())
                {
                    this.Text = "Management Edit";
                    btnSave.Text = "Edit";
                    Customers Customer = Un.Customers.Get().SingleOrDefault(a => a.ColumnID == ContactID);
                    txtName.Text = Customer.FullName;
                    txtAddres.Text = Customer.Address;
                    txtAge.Value = (decimal)Customer.Age;
                    txtEmail.Text = Customer.Email;
                    txtPhone.Text = Customer.Phone;
                    pcCustomer.ImageLocation = PathLo + Customer.PhotoImage;
                    if (Customer.Sex != "W")
                    {
                        rbSexMan.Checked = true;
                    }
                    else
                    {
                        rbSexWoman.Checked = true;
                    };
                }
                CreatDeleteButton();
            }
            else
            {
                btnUpload.Width = 164;
                btnUpload.Left = 4;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                pcCustomer.ImageLocation = OpenFile.FileName;
            }
        }

        private void btnDelImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure about delete that picture?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Check();
            }
        }

        private bool Check()
        {
            if (rbSexMan.Checked)
            {
                pcCustomer.ImageLocation = PathLo + "Man.png";
                return true;
            }
            else
            {
                pcCustomer.ImageLocation = PathLo + "Woman.png";
                return false;
            }
        }

        private void CreatDeleteButton()
        {
            Button DB = new Button();
            groupBox1.Controls.Add(DB);
            DB.Text = "Delete";
            DB.Visible = true;
            DB.Location = new Point(4, 245);
            DB.Click += btnDelImage_Click;
            DB.Width = 83;
            DB.Height = 24;
            DB.ForeColor = Color.Black;
        }

        private void rSexWoman_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }
    }
}
