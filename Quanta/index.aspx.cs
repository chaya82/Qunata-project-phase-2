using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDS.DAL;
using NDS.LIB;

namespace Quanta
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void sendmailuser()
        {
            try
            {
                DALCommon cmn = new DALCommon();
                string strBody = cmn.prcFindInFile(Server.MapPath("sendmail.html").ToString(), "", "");
                cmn.SendHtmlFormattedEmail(txtEmail.Text.ToLower(), "Thank you for your intrest", strBody);
                ClientScript.RegisterStartupScript(GetType(), "Save", "<SCRIPT LANGUAGE='javascript'>javascript:alert('Your message has been sent. Thank you for your interest!');</script>");
                
            }
            catch (Exception e)
            {
            }
        }
        protected void SendButton_Click(object sender, EventArgs e)
        {
            string intrest = "";
            try
            {
                LIBtblmstContact objLIBtblmstContact = new LIBtblmstContact();
                DALtblmstContact objDALtblmstContact = new DALtblmstContact();
                MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                objLIBtblmstContact.id = -1;
                objLIBtblmstContact.Name = txtname.Text;
                objLIBtblmstContact.Email = txtEmail.Text;
                objLIBtblmstContact.phone = txtPHONE.Text;
                objLIBtblmstContact.designation = txtDESIGNATION.Text;
                objLIBtblmstContact.OrgName = txtORGANIZATION.Text;
                objLIBtblmstContact.dt = DateTime.Now.ToShortDateString() ;
                if (rdoBasic.Checked == true)
                {
                    objLIBtblmstContact.INTREST = rdoBasic.Text;
                }
                if (rdoPro.Checked == true)
                {
                    objLIBtblmstContact.INTREST = rdoPro.Text;
                }
                tp.MessagePacket = objLIBtblmstContact;
                tp = objDALtblmstContact.InserttblmstContact(tp);
                intrest = objLIBtblmstContact.INTREST;
                if (tp.MessageId > -1)
                {
                    string[] strOutParamValues = (string[])tp.MessageResultset;
                   
                }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
            try
            {

                DALCommon cmn1 = new DALCommon();
                string strBody1 = cmn1.prcFindInFile(Server.MapPath("sendmailadmin.html").ToString(), "#name#", txtname.Text);
                strBody1 = cmn1.prcFindInString(strBody1, "#Designation#", txtDESIGNATION.Text);
                strBody1 = cmn1.prcFindInString(strBody1, "#Email#", txtEmail.Text);
                strBody1 = cmn1.prcFindInString(strBody1, "#Phone#", txtPHONE.Text);
                strBody1 = cmn1.prcFindInString(strBody1, "#Organisation#", txtORGANIZATION.Text);
                strBody1 = cmn1.prcFindInString(strBody1, "#Intrested#", intrest);


                // strBody = "Hi " + txtname.Text + ", You or someone with your id signed up at this site, Your new account is almost ready, but before you can login you need to confirm your email id by visitng the link below: http://localhost:56941/EmailConfirmation.aspx?ID=" + userInfo.ProviderUserKey.ToString() + " Once you have visited the verification URL, your account will be activated. If you have any problems or questions, please reply to this email. Thanks!";

                cmn1.SendHtmlFormattedEmail("contactus@inqsights.com", "inQsights Op Contact Form submission", strBody1);
                sendmailuser();
            }
            catch (HttpException ex)
            {

            }
        }
    }
}