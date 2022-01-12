using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using System.Net;
using System.Net.Mail;
using EAuthDataSetTableAdapters;

public partial class _Default : System.Web.UI.Page
{
    string useremail = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (txtusername.Text != "" & txtpassword.Text != "")
        {
            string txtuser = txtusername.Text;
            string txtpw = txtpassword.Text;
            tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
            EAuthDataSet.tbl_UsersDataTable itbl = new EAuthDataSet.tbl_UsersDataTable();
            EAuthDataSet.tbl_UsersDataTable itbl1 = new EAuthDataSet.tbl_UsersDataTable();
            itbl = iusers.GetByPasswordandUserName(txtpw, txtuser);
            if (itbl.Rows.Count == 0)
            {
                lblmsg.Text = "Wrong Username/Password";
                lblmsg.Visible = true;
            }
            else if (itbl.Rows.Count > 0)
            {
                foreach (EAuthDataSet.tbl_UsersRow irow in itbl.Rows)
                {
                    useremail = irow.email;
                }
                Session["username"] = txtuser;
                GenerateOTP();
                Response.Redirect("~/Verification.aspx");
            }
            
        }
    
        else if(txtusername.Text=="")
        {
            lblmsg.Text = "Username should not be empty";
            lblmsg.Visible = true;
        }

        else
        {
            lblmsg.Text = "Password should not be empty";
            lblmsg.Visible = true;
        }
    }
 

    private void GenerateOTP()
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";
        string characters = numbers;
        characters += alphabets + small_alphabets + numbers;
        int length = 5;
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;

        }

        GenerateQrcode(otp);
        sendmail(otp);
    }

    private void GenerateQrcode(string otpname)
    {
        var writer = new BarcodeWriter();
        writer.Format = BarcodeFormat.QR_CODE;
        var result = writer.Write(otpname);
        string path = Server.MapPath("~/images/QrImage.jpg");
        var barcodeBitmap = new Bitmap(result);
        using(MemoryStream memory = new MemoryStream())
        {
            using(FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                byte[] bytes = memory.ToArray();
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
        iusers.UpdateByUserName(otpname, "~/images/QrImage.jpg", txtusername.Text);


    }

    private void sendmail(string otpname)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("<Enter the sender mail here>", "E-Authentication");
            mail.To.Add(useremail);
            mail.Subject = "Account Activation";
            string body = "Hello " + txtusername.Text.Trim();
            body += "<br /><br /> Below is your OTP";
            body += "<br /><br /><b>OTP: </b>" + otpname;
            var view = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(view);
            mail.IsBodyHtml = true;
            SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential credentials = new NetworkCredential("<Enter the sender mail here>", "<Enter the sender mail's password>");
            smpt.Credentials = credentials;
            smpt.Send(mail);
        }

        catch(Exception ex)
        {
            lblmsg.Text = ex.ToString();
            lblmsg.Visible = true;
        }
    }

}
