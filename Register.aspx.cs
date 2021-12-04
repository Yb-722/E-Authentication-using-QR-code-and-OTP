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

    protected void btnregister_Click(object sender, EventArgs e)
    {
        try
        {
            tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
            iusers.Insert(txtusername.Text, txtpassword.Text, txtemail.Text, txtphoneNo.Text, "", "");
            lblmsg.Text = "User Registration Successful!";
            lblmsg.Visible = true;
            
        }
        catch
        {
            lblmsg.Text = "Error in Registration!";
            lblmsg.Visible = true;
        }
      
    }
}