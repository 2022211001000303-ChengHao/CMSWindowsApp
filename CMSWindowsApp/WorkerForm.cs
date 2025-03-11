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
    public partial class WorkerForm: Form
    {
        public WorkerForm()
        {
            InitializeComponent();
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            this.tblWorkerTableAdapter1.Fill(this.cMSDBDataSet1.tblWorker);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.cMSDBDataSet1.tblWorker.Clear();
            sqlDataAdapter1.Fill(this.cMSDBDataSet1.tblWorker);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(this.cMSDBDataSet1.tblWorker);
            MessageBox.Show("The Worker Table is Updated");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.cMSDBDataSet1.tblWorker.Clear();
            sqlDataAdapter1.Fill(this.cMSDBDataSet1.tblWorker);
        }
    }
}
