﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSWindowsApp
{
    public partial class JobDetailsForm: Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataSet jobDetailsDataset;
        private BindingSource bindingSource;

        public JobDetailsForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCarNo.Text.Length < 6)
                {
                    MessageBox.Show("Please Specify a valid number");
                    txtCarNo.Focus();
                    return;
                }

                if (Convert.ToInt32(txtWorkerID.Text) < 1)
                {
                    MessageBox.Show("Please specify a valid worker Id");
                    txtWorkerID.Focus();
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=localhost;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True");
            adapter = new SqlDataAdapter("Select * from tblJobDetails", conn);
            
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            jobDetailsDataset = new DataSet();
            adapter.Fill(jobDetailsDataset, "tblJobDetails"); 
            bindingSource = new BindingSource { DataSource = jobDetailsDataset.Tables["tblJobDetails"] };

            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt && txt.Name.StartsWith("txt"))
                {
                    txt.DataBindings.Clear();
                    string columnName = txt.Name.Substring(3);
                    txt.DataBindings.Add("Text", bindingSource, columnName);
                }
            }
            UpdatePositionlabel();
        }

        private void UpdatePositionlabel()
        {
            if (bindingSource.Count > 0)
            {
                lblPosition.Text = $"{bindingSource.Position + 1} / {bindingSource.Count}";
            }
            else
            {
                lblPosition.Text = "0 / 0";
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position > 0)
                bindingSource.MovePrevious();
            
            UpdatePositionlabel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position < bindingSource.Count - 1)
                bindingSource.MoveNext();

            UpdatePositionlabel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
            UpdatePositionlabel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
            UpdatePositionlabel();
        }
    }
}
