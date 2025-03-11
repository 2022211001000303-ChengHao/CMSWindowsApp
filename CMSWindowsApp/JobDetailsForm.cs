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
    public partial class JobDetailsForm: Form
    {
        public JobDetailsForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textCarNo.Text.Length < 6)
                {
                    MessageBox.Show("Please Specify a valid number");
                    textCarNo.Focus();
                    return;
                }

                if (Convert.ToInt32(textWorkerId.Text) < 1)
                {
                    MessageBox.Show("Please specify a valid worker Id");
                    textWorkerId.Focus();
                    return;
                }

                if (Convert.ToDateTime(dateTimePicker1.Value) > DateTime.Today)
                {
                    MessageBox.Show("Please specify valid Date");
                    dateTimePicker1.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
