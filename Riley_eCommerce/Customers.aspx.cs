using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Riley_eCommerce
{
    public partial class Customers : System.Web.UI.Page
    {
        string dbConnect = @"integrated security=True;data source=(localdb)\MSSQLLocalDB;persist security info=False;initial catalog=Store";
        public static int CusID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // **************************
        // Clears out all form fields
        //
        // No input arguments
        protected void btnNewCustomer_Click(object sender, EventArgs e)
        {
            txtCustomerNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtPostal.Text = "";

            btnDeleteCustomer.Enabled = false;
            btnUpdateCustomer.Enabled = false;
        }

        protected void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            // check for blank customer number
            if (txtCustomerNumber.Text != "")
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

                // now make a change to the customer last name
                string sqlString = "UPDATE Customers SET FirstName=@FirstName, LastName=@LastName, Address=@Address, City=@City, Province=@Province, PostalCode=@PostalCode WHERE CusID=@CusID";

                int count = 0;
                try
                {
                    cmd = new SqlCommand(sqlString, connectCmd);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                    cmd.Parameters.AddWithValue("@PostalCode", txtPostal.Text);
                    cmd.Parameters.AddWithValue("@CusID", txtCustomerNumber.Text);
                    count = cmd.ExecuteNonQuery();
                    lblMessages.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessages.Text = ex.Message;
                    DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                }
                Console.WriteLine("Record updated");
                Console.WriteLine();

                // release all database resources (memory)
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }
        }

        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
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

            // define SQL string to delete customer by customer ID
            string sqlString = "DELETE FROM Customers WHERE CusID = @CusID";

            // create an int variable to receive number of records deleted
            int count = 0;
            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@CusID", txtCustomerNumber.Text);
                count = cmd.ExecuteNonQuery();

                txtCustomerNumber.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtProvince.Text = "";
                txtPostal.Text = "";
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }
            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }

        protected void btnFindCustomer_Click(object sender, EventArgs e)
        {
            // create the objects needed for CRUD
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

                // create SQL string to select customer record
                string sqlString = "SELECT * FROM Customers WHERE CusID = @CusID";

                // create new SQL command object based on SQL string and connection
                scmd = new SqlCommand(sqlString, connectFill);

                // add the parameter to SQL string and validate
                scmd.Parameters.AddWithValue("@CusID", txtCustomerNumber.Text);

                // create a new SQL data adapter to retrieve the data and
                // fill the data set
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Customers");
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            if (ds.Tables["Customers"].Rows.Count == 1)
            {
                txtFirstName.Text = ds.Tables["Customers"].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables["Customers"].Rows[0]["LastName"].ToString();
                txtAddress.Text = ds.Tables["Customers"].Rows[0]["Address"].ToString();
                txtCity.Text = ds.Tables["Customers"].Rows[0]["City"].ToString();
                txtProvince.Text = ds.Tables["Customers"].Rows[0]["Province"].ToString();
                txtPostal.Text = ds.Tables["Customers"].Rows[0]["PostalCode"].ToString();
                btnDeleteCustomer.Enabled = true;
                btnUpdateCustomer.Enabled = true;
                lblMessages.Text = "";
                CusID = int.Parse(txtCustomerNumber.Text);
            }
            else
                lblMessages.Text = "CUSTOMER NUMBER NOT FOUND";

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
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

            // create our SQL string with VALUE parameters
            string sqlString = "INSERT INTO Customers (FirstName, LastName, Address, City, Province, PostalCode) VALUES (@FirstName, @LastName, @Address, @City, @Province, @PostalCode)";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txtPostal.Text);
                cmd.ExecuteNonQuery();
                lblMessages.Text = "";
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            // get the primary key identity just inserted
            string identRequest = "SELECT IDENT_CURRENT('Customers') FROM Customers";
            cmd = new SqlCommand(identRequest, connectCmd);
            int identValue = Convert.ToInt32(cmd.ExecuteScalar());
            txtCustomerNumber.Text = identValue.ToString();

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }

        // **************************************************************
        // method releases all database resources that have been assigned
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

        /*protected void changeStyle(object sender, EventArgs e)
        {
            HtmlLink csslink = new HtmlLink();
            csslink.Href = "Styles/Customers.css";
            csslink.Attributes.Add("rel", "stylesheet");
            csslink.Attributes.Add("type", "text/css");
            Page.Header.Controls.Add(csslink);
        } Ignore this */
    }
}