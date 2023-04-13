using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"server=DESKTOP-EFR1DG0\SQLEXPRESS02;Database=DotNet20Dec;Integrated Security=True;");

        }
        private DataSet GetAllProducts()
        {
            da = new SqlDataAdapter("select * from Product3", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "product3");
            return ds;
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllProducts();
                DataRow row = ds.Tables["product3"].NewRow();
                row["id"]=txtid.Text;
                row["name"] = txtname.Text;
                row["company"] = txtcompany.Text;
                row["price"] = txtprice.Text;
                // add new row in the dataset table
                ds.Tables["product3"].Rows.Add(row);
                int res = da.Update(ds.Tables["product3"]);
                if (res >= 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllProducts();
                DataRow row = ds.Tables["product3"].NewRow();
                row["id"] = txtid.Text;
                row["name"] = txtname.Text;
                row["company"] = txtcompany.Text;
                row["price"] = txtprice.Text;
                // add new row in the dataset table
                ds.Tables["product3"].Rows.Add(row);
                int res = da.Update(ds.Tables["product3"]);
                if (res >= 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllProducts();
                DataRow row = ds.Tables["product3"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    txtname.Text = row["name"].ToString();
                     txtcompany.Text = row["company"].ToString();
                    txtprice.Text = row["price"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllProducts();
                DataRow row = ds.Tables["product3"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row.Delete();
                    int res = da.Update(ds.Tables["product3"]);
                    if (res >= 1)
                    {
                        MessageBox.Show("Record deleted");
                    }

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnshowallproducts_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllProducts();
                dataGridView1.DataSource = ds.Tables["product3"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
