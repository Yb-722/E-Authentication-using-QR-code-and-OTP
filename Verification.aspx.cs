using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EAuthDataSetTableAdapters;

public partial class Verification : System.Web.UI.Page
{
    string qrimgurl = "";
    string otp = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            tbl_UsersTableAdapter iuser = new tbl_UsersTableAdapter();
            EAuthDataSet.tbl_UsersDataTable itbl = new EAuthDataSet.tbl_UsersDataTable();
            itbl = iuser.GetByUserName(Session["username"].ToString());
            if (itbl.Rows.Count>0)
            {
                foreach(EAuthDataSet.tbl_UsersRow irow in itbl.Rows)
                {
                    qrimgurl = irow.qrcode;
                    otp = irow.otp;
                }
                imgQRCODE.ImageUrl = qrimgurl;
            }
        }
    }

    protected void btnverify_Click(object sender, EventArgs e)
    {
        string myotp = txtOTP.Text.Trim();

        tbl_UsersTableAdapter iuser = new tbl_UsersTableAdapter();
        EAuthDataSet.tbl_UsersDataTable itbl = new EAuthDataSet.tbl_UsersDataTable();
        itbl = iuser.GetByUserName(Session["username"].ToString());
        if (itbl.Rows.Count > 0)
        {
            foreach (EAuthDataSet.tbl_UsersRow irow in itbl.Rows)
            {
                otp = irow.otp;
            }
        }
        if (myotp==otp)
        {
            Response.Redirect("~/Success.aspx");
        }
        else
        {
            lblmsg.Text = "User identity cannot be verified! ";
            lblmsg.Visible = true;
        }
    }
}