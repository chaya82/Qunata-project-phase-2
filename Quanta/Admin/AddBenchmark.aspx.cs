using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NDS.LIB;
using NDS.DAL;


namespace Quanta.Admin
{
    public partial class AddBenchmark : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // bool flg1 = Membership.DeleteUser("chaya.pandey@gmail.com", true);


                if (!Page.IsPostBack)
                {

                    DataTable dt = clsESPSql.ExecQuery("select convert(varchar(10),id)+'_'+convert(varchar(10),inputno) as inputno,name from tblmstMetric where IsBenchmark=1 ");
                
                    ddlRType.DataSource = dt;
                    ddlRType.DataValueField = "inputno";
                    ddlRType.DataTextField = "name";
                    ddlRType.DataBind();
                    ddlRType.Items.Insert(0, new ListItem("Select Metric", ""));
                }


            }
            catch (Exception ex)
            {
            }

        }
        public void bindInd()
        {
            try
            {
                string strtype = "";
                if(ddlRType.SelectedIndex>0)
                {
                    strtype=ddlRType.SelectedItem.Text;
                }
                DataTable dt = clsESPSql.ExecQuery("SP_GetBenchmark '" + strtype+"'");
                rptlist.DataSource = dt;
                rptlist.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
        protected void ddlRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRType.SelectedIndex > 0)
                {
                    CreateButton.Visible = true;
                    if (ddlRType.SelectedItem.Text == "Revenue/Employee" || ddlRType.SelectedItem.Text == "TFP/FTE")
                    {
                        rptListCurr.Visible = true;
                        rptlist.Visible = false;
                        DataTable dt = clsESPSql.ExecQuery("select * from tblmstCurrency ");
                        rptListCurr.DataSource = dt;
                        rptListCurr.DataBind();
                      
                    }
                    else
                    {
                      
                        rptListCurr.Visible = false;
                        rptlist.Visible = true;
                        bindInd();
                    }
                }
                else
                {
                    CreateButton.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void rptGrade_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    TextBox txtbm1_2 = (TextBox)e.Item.FindControl("txtbm1_2");
                    TextBox txtbm2_2 = (TextBox)e.Item.FindControl("txtbm2_2");
                    TextBox txtbm3_2 = (TextBox)e.Item.FindControl("txtbm3_2");
                    string[] str = ddlRType.SelectedValue.ToString().Split('_');
                    if (str[1].ToString() == "2")
                    {
                        txtbm1_2.Visible = true;
                        txtbm2_2.Visible = true;
                        txtbm3_2.Visible = true;

                    }
                    else
                    {
                        txtbm1_2.Visible = false;
                        txtbm2_2.Visible = false;
                        txtbm3_2.Visible = false;
                    }

                }

                catch (Exception ex)
                {
                }
            }
        }
        protected void insertRecord(decimal bm1_1, decimal bm1_2, decimal bm2_1, decimal bm2_2, decimal bm3_1, decimal bm3_2,string curr,int industryid)
        {
            try
            {
                LIBtblmstBenchmark objLIBtblmstBenchmark = new LIBtblmstBenchmark();
                DALtblmstBenchmark objDALtblmstBenchmark = new DALtblmstBenchmark();
                MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                objLIBtblmstBenchmark.id = -1;
                objLIBtblmstBenchmark.industryid = industryid;
                objLIBtblmstBenchmark.bm1_1 = bm1_1;
                objLIBtblmstBenchmark.bm1_2 = bm1_2;
                objLIBtblmstBenchmark.bm2_1 = bm2_1;
                objLIBtblmstBenchmark.bm2_2 = bm2_2;
                objLIBtblmstBenchmark.bm3_1 = bm3_1;
                objLIBtblmstBenchmark.bm3_2 = bm3_2;
                objLIBtblmstBenchmark.currency = curr;
                objLIBtblmstBenchmark.metric = ddlRType.SelectedItem.Text;
                tp.MessagePacket = objLIBtblmstBenchmark;
                tp = objDALtblmstBenchmark.InserttblmstBenchmark(tp);

                if (tp.MessageId > -1)
                {
                    string[] strOutParamValues = (string[])tp.MessageResultset;
                    //MessageBox.Show(strOutParamValues[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlRType.SelectedItem.Text == "Revenue/Employee" || ddlRType.SelectedItem.Text == "TFP/FTE")
                {
                    foreach (RepeaterItem itemmain in rptListCurr.Items)
                    {
                        Repeater rptinnerlist = (Repeater)itemmain.FindControl("rptinnerlist");
                        Label lblcurr = (Label)itemmain.FindControl("lblcurr");
                        readList(rptlist, lblcurr.Text);


                    }
                }
                else
                {
                    readList(rptlist, "");
                }
                Response.Redirect(Request.Url.ToString(), false);
            }

            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
        }
        protected void readList(Repeater rpt,string curr)
        {
            try{
                foreach (RepeaterItem item in rpt.Items)
                {
                    int industry = -1;
                    HiddenField hdnid = (HiddenField)item.FindControl("hdnid");
                    TextBox txtbm1_1 =(TextBox)item.FindControl("txtbm1_1");
                    TextBox txtbm1_2 = (TextBox)item.FindControl("txtbm1_2");
                    TextBox txtbm2_1 = (TextBox)item.FindControl("txtbm2_1");
                    TextBox txtbm2_2 = (TextBox)item.FindControl("txtbm2_2");
                    TextBox txtbm3_1 = (TextBox)item.FindControl("txtbm3_1");
                    TextBox txtbm3_2 = (TextBox)item.FindControl("txtbm3_2");
                    decimal bm1_1 = Convert.ToDecimal(txtbm1_1.Text.Trim() != "" ? txtbm1_1.Text.Trim() : "0");
                    decimal bm1_2 = Convert.ToDecimal(txtbm1_2.Text.Trim() != "" ? txtbm1_2.Text.Trim() : "0");
                    decimal bm2_1 = Convert.ToDecimal(txtbm2_1.Text.Trim() != "" ? txtbm2_1.Text.Trim() : "0");
                    decimal bm2_2 = Convert.ToDecimal(txtbm2_2.Text.Trim() != "" ? txtbm2_2.Text.Trim() : "0");
                    decimal bm3_1 = Convert.ToDecimal(txtbm3_1.Text.Trim() != "" ? txtbm3_1.Text.Trim() : "0");
                    decimal bm3_2 = Convert.ToDecimal(txtbm3_2.Text.Trim() != "" ? txtbm3_2.Text.Trim() : "0");
                    industry = Convert.ToInt32(hdnid.Value);
                    insertRecord(bm1_1, bm1_2,bm2_1, bm2_2, bm3_1, bm3_2, curr,industry);

                   
                }
             }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
        }

        protected void rptListCurr_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Label lblcurr = (Label)e.Item.FindControl("lblcurr");
                    Repeater rptinnerlist = (Repeater)e.Item.FindControl("rptinnerlist");
                    string strtype = "";
                    if (ddlRType.SelectedIndex > 0)
                    {
                        strtype = ddlRType.SelectedItem.Text;
                    }
                    DataTable dt = clsESPSql.ExecQuery("SP_GetBenchmark '" + strtype + "','"+lblcurr.Text+"'");
                   
                    rptinnerlist.DataSource = dt;
                    rptinnerlist.DataBind();

                }

                catch (Exception ex)
                {
                }
            }
        }
    }
}