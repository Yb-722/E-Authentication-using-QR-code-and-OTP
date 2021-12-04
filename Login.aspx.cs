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

public partial class Login : System.Web.UI.Page
{
    string useremail = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {

        if (txtusername.Text != "")
        {
            string txtuser = txtusername.Text;
           

            tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
            EAuthDataSet.tbl_UsersDataTable itbl = new EAuthDataSet.tbl_UsersDataTable();
            itbl = iusers.GetByUserName(txtuser);
            if (itbl.Rows.Count == 0)
            {
                lblmsg.Text = "User does not Exist!";
                lblmsg.Visible = true;
            }
            else if (itbl.Rows.Count > 0)
            {
                foreach(EAuthDataSet.tbl_UsersRow irow in itbl.Rows)
                {
                    useremail = irow.email;
                }
                Session["username"] = txtuser;
                GenerateOTP();
                Response.Redirect("~/Verification.aspx");
            }
        }

    }

    private void GenerateOTP()
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabests = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";
        string characters = numbers;
        characters += alphabets + small_alphabests + numbers;
        int lenght = 5;
        string otp = string.Empty;
        for(int i=0; i <lenght; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);

            otp += character;
          
        }

        GenerateQrCode(otp);
        sendmail(otp);
    }

    private void GenerateQrCode(string otpname)
    {
        var writer = new BarcodeWriter();
        writer.Format = BarcodeFormat.QR_CODE;
        var result = writer.Write(otpname);
        string path = Server.MapPath("~/images/QrImage4.jpg");
        var barcodeBitmap = new Bitmap(result);
        using (MemoryStream memory = new MemoryStream())
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                byte[] bytes= memory.ToArray();
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        tbl_UsersTableAdapter iusers = new tbl_UsersTableAdapter();
        iusers.UpdateByUserName(otpname, "~/images/QrImage4.jpg", txtusername.Text);
    }

    private void sendmail(string otpname)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("marketplace@brainlegit.com", "E-Authentication");
            mail.To.Add(useremail);
            mail.Subject = "Account Activation";
            var inlineImage = new LinkedResource(Server.MapPath("~/images/QrImage.jpg"), "Image/jpg");
            inlineImage.ContentId = "qrcode";
            string body = "Hello " + txtusername.Text.Trim();
            body += "<br /><br /> Below are your verification credentials";
            body += "<br /><br /> <b>OTP</b> " + otpname;
            body +=string.Format("@<br /><img width='250' src=cid:qrcode />");
            var view = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            view.LinkedResources.Add(inlineImage);
            mail.AlternateViews.Add(view);
            mail.IsBodyHtml = true;
            SmtpClient smpt = new SmtpClient("mail.brainlegit.com", 2525);
            NetworkCredential credentials = new NetworkCredential("marketplace@brainlegit.com", "Marketing@1");
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