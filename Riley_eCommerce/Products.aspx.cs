using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Riley_eCommerce
{
    public partial class Products : System.Web.UI.Page
    {
        string dbConnect = @"integrated security=True;data source=(localdb)\MSSQLLocalDB;persist security info=False;initial catalog=Store";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string fileName = ImageFileUpload.FileName;

            if (fileName != "")
            {
                ImageFileUpload.SaveAs(HttpContext.Current.Server.MapPath(".") + @"\pictures\" + fileName);
                imgUploaded.ImageUrl = "pictures/" + fileName;
                txtPicture.Text = fileName;
            }
        }

        protected void btnNewProduct_Click(object sender, EventArgs e)
        {
            txtPicture.Text = "";
            txtManufacturerCode.Text = "";
            txtDescription.Text = "";
            txtQOH.Text = "";
            txtPrice.Text = "";
            txtProductID.Text = "";

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string sqlString = "INSERT INTO Products (Picture) VALUES (@Picture)";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@Picture", txtPicture.Text);
                //cmd.Parameters.AddWithValue("@ManufacCode", txtManufacturerCode.Text);
                //cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                //cmd.Parameters.AddWithValue("@QOH", txtQOH.Text);
                //cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.ExecuteNonQuery();
                lblMessages.Text = "";

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            string identRequest = "SELECT IDENT_CURRENT('Products') FROM Products";

            cmd = new SqlCommand(identRequest, connectCmd);
            int identValue = Convert.ToInt32(cmd.ExecuteScalar());
            txtProductID.Text = identValue.ToString();
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtProductID.Text != "")
            {
                // create the objects needed for CRUD
                SqlDataAdapter sqlDataAdapter = null;
                DataSet ds = null;
                SqlConnection connectFill = null;
                SqlConnection connectCmd = null;
                SqlCommand cmd = null;
                SqlCommand scmd = null;

                // open a connection to the database
                connectCmd = new SqlConnection(dbConnect);
                connectCmd.Open();

                string sqlString = "UPDATE Products SET Picture=@Picture, ManufacCode=@ManufacCode, Description=@Description, QOH=@QOH, Price=@Price WHERE ProductID=@ProductID";

                try
                {
                    cmd = new SqlCommand(sqlString, connectCmd);
                    cmd.Parameters.AddWithValue("@Picture", txtPicture.Text);
                    cmd.Parameters.AddWithValue("@ManufacCode", txtManufacturerCode.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@QOH", txtQOH.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmd.ExecuteNonQuery();
                    lblMessages.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessages.Text = ex.Message;
                    DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                }
                Console.WriteLine("Record updated");
                Console.WriteLine();

                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }
        }
       

        protected void btnFind_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;
            try
            {
                // create a new data set object called ds
                ds = new DataSet();
                // create a connection to the database called connectFill
                connectFill = new SqlConnection(dbConnect);

                string sqlString = "SELECT * FROM Products WHERE ProductID = @ProductID";

                // create new SQL command object based on SQL string and connection
                scmd = new SqlCommand(sqlString, connectFill);

                scmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);

                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }
            if (ds.Tables["Products"].Rows.Count == 1)
            {
                txtPicture.Text = ds.Tables["Products"].Rows[0]["Picture"].ToString();
                txtManufacturerCode.Text = ds.Tables["Products"].Rows[0]["ManufacCode"].ToString();
                txtDescription.Text = ds.Tables["Products"].Rows[0]["Description"].ToString();
                txtQOH.Text = ds.Tables["Products"].Rows[0]["QOH"].ToString();
                txtPrice.Text = ds.Tables["Products"].Rows[0]["Price"].ToString();
                string fileName = txtPicture.Text;
                imgUploaded.ImageUrl = "pictures/" + fileName;
                txtPicture.Text = fileName;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                lblMessages.Text = "";
            }
            else
            {
                lblMessages.Text = "Product not found";
            }
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }
        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            // open a connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();
            string sqlString = "DELETE FROM Products WHERE ProductID = @ProductID";
            int count = 0;
            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                count = cmd.ExecuteNonQuery();

                txtPicture.Text = "";
                txtManufacturerCode.Text = "";
                txtDescription.Text = "";
                txtQOH.Text = "";
                txtPrice.Text = "";
                txtProductID.Text = "";
                imgUploaded.ImageUrl = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }
            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }
        private static void DisposeResources(ref SqlDataAdapter sqlDataAdapter,
           ref DataSet ds,
           ref SqlConnection connectFill,
           ref SqlConnection connectCmd,
           ref SqlCommand cmd,
           ref SqlCommand scmd)
        {
            if (sqlDataAdapter != null)
                sqlDataAdapter.Dispose();
            if (ds != null)
                ds.Dispose();
            if (connectFill != null)
                connectFill.Dispose();
            if (connectCmd != null)
                connectCmd.Dispose();
            if (cmd != null)
                cmd.Dispose();
            if (scmd != null)
                scmd.Dispose();
        }
    }
}