using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSWindowsApp
{
    public partial class CustomerForm: Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            errorCustomerForm.SetError(textBox1, "");
            errorCustomerForm.SetError(textBox2, "");
            errorCustomerForm.SetError(textBox3, "");
            errorCustomerForm.SetError(textBox4, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = true;
            if (textBox1.Text == "")
            {
                errorCustomerForm.SetError(textBox1, "Please specify a valid car number");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox1, "");
            if (textBox2.Text == "")
            {
                errorCustomerForm.SetError(textBox2, "Please specify a valid name");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox2, "");
            if (textBox3.Text == "")
            {
                errorCustomerForm.SetError(textBox3, "Please specify a valid address");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox3, "");
            if (textBox4.Text == "")
            {
                errorCustomerForm.SetError(textBox4, "Please specify a valid make");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox4, "");

            if (flag == false)
                return;
            else
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
