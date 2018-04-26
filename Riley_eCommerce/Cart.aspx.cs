using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riley_eCommerce
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateCartGrid();
            CalculateTotal();
        }

        protected void RemoveFromCart(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int row = int.Parse(b.ID);

            Default.qtySold[Default.cartInfo[row]] = "1";
            // delete the cart item from the Main.cartInfo array
            // ... then rebuild the cart grid
            for (int i = row; i < Default.numItems; i++)
                Default.cartInfo[i] = Default.cartInfo[i + 1];

            Default.numItems--;
            CreateCartGrid();
            CalculateTotal();
        }

        private void CreateCartGrid()
        {
            Table1.Rows.Clear();
            for (int i = 0; i < Default.numItems; i++)
            {
                // add new empty row object
                TableRow row = new TableRow();
                for (int j = 0; j < 7; j++)
                {
                    // add new empty cell object
                    TableCell cell = new TableCell();

                    if (j == 0)
                    {
                        Image pic = new Image();
                        pic.ImageUrl = "pictures/" + Default.pics[Default.cartInfo[i]];
                        pic.Height = 200;
                        pic.Width = 220;
                        cell.Controls.Add(pic);
                    }
                    else if (j == 1)
                    {
                        cell.Text = "Product ID: "+Default.modelNum[Default.cartInfo[i]];
                    }
                    else if (j == 2)
                    {
                        cell.Text = Default.descrip[Default.cartInfo[i]];
                    }
                    else if (j == 3)
                    {
                        cell.Text = "Quantity: "+Default.qty[Default.cartInfo[i]];
                    }
                    else if (j == 4)
                    {
                        Label price = new Label();
                        price.Text = Default.price[Default.cartInfo[i]];

                        // this is the line of code we were missing in class
                        cell.Controls.Add(price);
                    }
                    else if (j == 5)
                    {
                        Button btnAddToCart = new Button();
                        btnAddToCart.ID = i.ToString();

                        btnAddToCart.Click += new EventHandler(RemoveFromCart);
                        btnAddToCart.Text = "Remove from Cart";
                        cell.Controls.Add(btnAddToCart);
                        btnAddToCart.Style["font-size"] = "18pt";
                        btnAddToCart.Style["color"] = "white";
                        btnAddToCart.Style["background"] = "red";
                        btnAddToCart.Style["border"] = "2px solid white;";
                        btnAddToCart.Style["width"] = "80%";
                        btnAddToCart.Style["height"] = "70px";
                        btnAddToCart.Style["border-radius"] = "10%";
                    }
                    else
                    {
                        TextBox text = new TextBox();
                        text.Text = Default.qtySold[Default.cartInfo[i]];
                        text.Style["font-family"] = "helvetica";
                        text.Style["color"] = "blue";
                        text.Style["background-color"] = "white";
                        text.Style["width"] = "100px";
                        text.Style["height"] = "30%";
                        text.Style["font-size"] = "18pt";
                        text.Style["border"] = "solid 1px #002594";

                        cell.Controls.Add(text);
                    }
                    // now add all the cells for the current row
                    row.Cells.Add(cell);
                }
                // finally, add the current row to the table
                Table1.Rows.Add(row);
            }
        }

        protected void btnRecalculate_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            for (int i = 0; i < Default.numItems; i++)
            {
                TableRow row = Table1.Rows[i];
                decimal rowPrice = 0;

                for (int j = 0; j < 7; j++)
                {
                    TableCell cell = row.Cells[j];

                    if (j == 4)
                    {
                        Control ctrl = cell.Controls[0];
                        Label lbl = (Label)ctrl;
                        string price = lbl.Text;
                        rowPrice = decimal.Parse(price);
                    }
                    else if (j == 6)
                    {
                        Control ctrl = cell.Controls[0];
                        TextBox txt = (TextBox)ctrl;
                        string qty = txt.Text;
                        Default.qtySold[Default.cartInfo[i]] = qty;

                        decimal rowTotal = rowPrice * int.Parse(qty);
                        total += rowTotal;
                    }
                }
            }

            LblTotal.Text = total.ToString("$##,##0.#0");
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Server.Transfer("Checkout.aspx");
        }
    }
}