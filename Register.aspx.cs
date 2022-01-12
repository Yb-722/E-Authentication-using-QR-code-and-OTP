using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EAuthDataSetTableAdapters;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnregister_Click1(object sender, EventArgs e)
    {
        try
        {
            tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
            EAuthDataSet.tbl_UsersDataTable itbl = new EAuthDataSet.tbl_UsersDataTable();
            EAuthDataSet.tbl_UsersDataTable itbl1 = new EAuthDataSet.tbl_UsersDataTable();
            EAuthDataSet.tbl_UsersDataTable itbl2 = new EAuthDataSet.tbl_UsersDataTable();
            itbl = iusers.GetByUserName(txtusername.Text);
            itbl1 = iusers.GetByPhone(txtphoneNo.Text);
            itbl2 = iusers.GetByEmail(txtemail.Text);
            if ((txtusername.Text != "") & (txtpassword.Text != "") & (txtemail.Text != "") & (txtphoneNo.Text != ""))
            {
                if ((itbl.Rows.Count==0) & (itbl1.Rows.Count==0) & (itbl2.Rows.Count==0))
                {
                    iusers.Insert(txtusername.Text, txtpassword.Text, txtemail.Text, txtphoneNo.Text, "", "");
                    lblmsg.Text = "User Registration Successful!";
                    lblmsg.Visible = true;
                }

                else
                {
                    if (itbl.Rows.Count > 0)
                    {
                        lblmsg.Text = "Username is already taken!";
                        lblmsg.Visible = true;
                    }
                    else if (itbl1.Rows.Count > 0)
                    {
                        lblmsg.Text = "Phone number is already registered.";
                        lblmsg.Visible = true;
                    }
                    else if (itbl2.Rows.Count > 0)
                    {
                        lblmsg.Text = "Email is already registered.";
                        lblmsg.Visible = true;
                    }
                }

            }
            else
            {
                lblmsg.Text = "Required field(s) are empty.";
                lblmsg.Visible = true;
            }
           
 
        }
        catch
        {
            lblmsg.Text = "Error in Registration";
            lblmsg.Visible = true;
        }
    }
}