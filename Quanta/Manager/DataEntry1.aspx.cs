using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NDS.LIB;
using NDS.DAL;

namespace Quanta.Manager
{
    public partial class DataEntry1 : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DataTable ds = new DataTable();
                    ds = clsESPSql.ExecQuery("SP_GetNatureofBussines_Org " + Session["orgid"].ToString());
                    
                    
                    rptChlList.DataSource = ds;
                    rptChlList.DataBind();
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("yr", typeof(string));
                    dtNew.Rows.Add(DateTime.Now.Year.ToString());
                    dtNew.Rows.Add((DateTime.Now.Year - 1).ToString());
                    ddlfyear.DataSource = dtNew;
                    ddlfyear.DataTextField = "yr";
                    ddlfyear.DataValueField = "yr";
                    ddlfyear.DataBind();
                    ddlfyear.Items.Insert(0, new ListItem("Select First Year", ""));
                    bindyearvalue();
                    Session["remarks"] = null;
                    Session["correct"] = null;
                    Session["dtprogess"] = null;
                    Session["dtinst"] = null;
                    
                    
                   
                    
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void bindyearvalue()
        {
            try
            {
               

                    DataTable dt = new DataTable();
                    dt = clsESPSql.ExecQuery("SP_GettblmstOrgInfo " + Session["orgid"].ToString());
                    if (dt.Rows.Count > 0)
                    { string fyear1 ="";
                        if (ddlfyear.SelectedIndex == 0)
                        {
                             fyear1 = dt.Rows[0]["year"].ToString();
                             ddlfyear.SelectedIndex = ddlfyear.Items.IndexOf(ddlfyear.Items.FindByText(fyear1));
                        }
                        else
                        {
                            fyear1 = ddlfyear.SelectedItem.Text;
                        }
                       
                        dt.DefaultView.RowFilter = "year='" + ddlfyear.SelectedItem.Text + "'";
                        if (dt.DefaultView.Count > 0)
                        {
                            DataTable dtyr = dt.DefaultView.ToTable();
                            txtAttrition1.Text = dtyr.Rows[0]["Attrtion"].ToString();
                            txtHeadCount1.Text = dtyr.Rows[0]["HeadCount"].ToString();
                            txtProfit1.Text = dtyr.Rows[0]["Profit"].ToString();
                            txtturn1.Text = dtyr.Rows[0]["turnover"].ToString();
                            txtWage1.Text = dtyr.Rows[0]["WageBill"].ToString();
                        }
                        else
                        {
                            txtAttrition1.Text = "";
                            txtHeadCount1.Text = "";
                            txtProfit1.Text ="";
                            txtturn1.Text = "";
                            txtWage1.Text = "";
                        }


                        string str = ddlfyear.SelectedItem.Text;
                      
                      
                            int fyear = Convert.ToInt32(str);

                            lblyr1.Text = (fyear - 1).ToString() ;
                            dt.DefaultView.RowFilter = "";
                            dt.DefaultView.RowFilter = "year='" + lblyr1.Text + "'";
                            if (dt.DefaultView.Count > 0)
                            {
                                DataTable dtyr = dt.DefaultView.ToTable();
                                txtAttrition2.Text = dtyr.Rows[0]["Attrtion"].ToString();
                                txtHeadCount2.Text = dtyr.Rows[0]["HeadCount"].ToString();
                                txtProfit2.Text = dtyr.Rows[0]["Profit"].ToString();
                                txtturn2.Text = dtyr.Rows[0]["turnover"].ToString();
                                txtWage2.Text = dtyr.Rows[0]["WageBill"].ToString();
                            }
                            else
                            {
                                txtAttrition2.Text = "";
                                txtHeadCount2.Text = "";
                                txtProfit2.Text = "";
                                txtturn2.Text = "";
                                txtWage2.Text = "";
                            }
                            lblyr2.Text = (fyear - 2).ToString();
                            dt.DefaultView.RowFilter = "";
                            dt.DefaultView.RowFilter = "year='" + lblyr2.Text + "'";
                            if (dt.DefaultView.Count > 0)
                            {
                                DataTable dtyr = dt.DefaultView.ToTable();
                                txtAttrition3.Text = dtyr.Rows[0]["Attrtion"].ToString();
                                txtHeadCount3.Text = dtyr.Rows[0]["HeadCount"].ToString();
                                txtProfit3.Text = dtyr.Rows[0]["Profit"].ToString();
                                txtturn3.Text = dtyr.Rows[0]["turnover"].ToString();
                                txtWage3.Text = dtyr.Rows[0]["WageBill"].ToString();
                            }
                            else
                            {
                                txtAttrition3.Text = "";
                                txtHeadCount3.Text = "";
                                txtProfit3.Text = "";
                                txtturn3.Text = "";
                                txtWage3.Text = "";
                            }
                        ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText(dt.Rows[0]["currency"].ToString()));
                        if (ddlCurrency.SelectedIndex > 0)
                        {
                            lblcurrency.Text = ddlCurrency.SelectedItem.Text;
                            lblcurrency1.Text = ddlCurrency.SelectedItem.Text;
                            lblcurrency2.Text = ddlCurrency.SelectedItem.Text;
                        }
                        else
                        {
                            lblcurrency.Text = "USD";
                            lblcurrency1.Text = "USD";
                            lblcurrency2.Text = "USD";
                        }
                    }

                    else
                    {
                        ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText("USD"));
                        lblcurrency.Text = "USD";
                        lblcurrency1.Text = "USD";
                        lblcurrency2.Text = "USD";
                    }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlfyear.SelectedIndex == 0)
                {
                    lblerrormsg.Text = "Select First Year";
                    return;
                }
                bool ischkd = false;
                for (int i = 0; i < rptChlList.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rptChlList.Items[i].FindControl("chk1");
                    HiddenField hdnid = (HiddenField)rptChlList.Items[i].FindControl("hdnid");
                    if (chk.Checked)
                    {
                        ischkd = true;
                        AddNatureofBussiness(Convert.ToInt32(hdnid.Value));
                    }
                }
                if (!ischkd)
                {
                    lblerrormsg.Text = "Select Nature of bussiness";
                    return;
                }
                int ret = 0;
                if (txtturn1.Text != "" && txtHeadCount1.Text != "" && txtProfit1.Text != "" && txtWage1.Text != "" && txtAttrition1.Text != "")
                {
                    decimal turnover, headcount, profit, wagebill, attrtion;
                    turnover = Convert.ToDecimal(txtturn1.Text);
                    headcount = Convert.ToDecimal(txtHeadCount1.Text);
                    profit = Convert.ToDecimal(txtProfit1.Text);
                    wagebill = Convert.ToDecimal(txtWage1.Text);
                    attrtion = Convert.ToDecimal(txtAttrition1.Text);
                    ret = AddOrgInfo(ddlfyear.SelectedItem.Text, turnover, headcount, profit, wagebill, attrtion);
                }
                if (txtturn2.Text != "" && txtHeadCount2.Text != "" && txtProfit2.Text != "" && txtWage2.Text != "" && txtAttrition2.Text != "")
                {
                    decimal turnover, headcount, profit, wagebill, attrtion;
                    turnover = Convert.ToDecimal(txtturn2.Text);
                    headcount = Convert.ToDecimal(txtHeadCount2.Text);
                    profit = Convert.ToDecimal(txtProfit2.Text);
                    wagebill = Convert.ToDecimal(txtWage2.Text);
                    attrtion = Convert.ToDecimal(txtAttrition2.Text);
                    ret = AddOrgInfo(lblyr1.Text, turnover, headcount, profit, wagebill, attrtion);
                }
                if (txtturn3.Text != "" && txtHeadCount3.Text != "" && txtProfit3.Text != "" && txtWage3.Text != "" && txtAttrition3.Text != "")
                {
                    decimal turnover, headcount, profit, wagebill, attrtion;
                    turnover = Convert.ToDecimal(txtturn3.Text);
                    headcount = Convert.ToDecimal(txtHeadCount3.Text);
                    profit = Convert.ToDecimal(txtProfit3.Text);
                    wagebill = Convert.ToDecimal(txtWage3.Text);
                    attrtion = Convert.ToDecimal(txtAttrition3.Text);
                    ret = AddOrgInfo(lblyr2.Text, turnover, headcount, profit, wagebill, attrtion);
                }
                if (ret > 0)
                {
                    Response.Redirect("DataInst.aspx", false);
                }

            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }


        }
        protected int AddOrgInfo(string fyear,decimal turnover,decimal headcount,decimal profit,decimal wagebill,decimal attrtion)
        {
            int ret=0;
            try
            {
                
                LIBtblmstOrgInfo objLIBtblmstOrgInfo = new LIBtblmstOrgInfo();
                DALtblmstOrgInfo objDALtblmstOrgInfo = new DALtblmstOrgInfo();
                MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                objLIBtblmstOrgInfo.id = -1;
                objLIBtblmstOrgInfo.orgid = Convert.ToInt32(Session["orgid"].ToString());
                objLIBtblmstOrgInfo.year = fyear;
                objLIBtblmstOrgInfo.turnover = turnover;
                objLIBtblmstOrgInfo.HeadCount = headcount;
                objLIBtblmstOrgInfo.Profit = profit;
                objLIBtblmstOrgInfo.WageBill = wagebill;
                objLIBtblmstOrgInfo.Attrtion = attrtion;
                objLIBtblmstOrgInfo.createdBy = User.Identity.Name;
                objLIBtblmstOrgInfo.dt = DateTime.Now.ToShortDateString();
                objLIBtblmstOrgInfo.Currency = ddlCurrency.SelectedItem.Text;
                tp.MessagePacket = objLIBtblmstOrgInfo;
                tp = objDALtblmstOrgInfo.InserttblmstOrgInfo(tp);
                Session["cur"] = ddlCurrency.SelectedItem.Text;

                if (tp.MessageId > -1)
                {
                    string[] strOutParamValues = (string[])tp.MessageResultset;
                    ret = 1;
                }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
            return ret;
        }
        protected void AddNatureofBussiness(int nid)
        {
            try
            {
                LIBtblOrgNatureofBussiness objLIBtblOrgNatureofBussiness = new LIBtblOrgNatureofBussiness();
                DALtblOrgNatureofBussiness objDALtblOrgNatureofBussiness = new DALtblOrgNatureofBussiness();
                MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                objLIBtblOrgNatureofBussiness.id = -1;
                objLIBtblOrgNatureofBussiness.orgid = Convert.ToInt32(Session["orgid"].ToString());
                objLIBtblOrgNatureofBussiness.natureid = nid;
                objLIBtblOrgNatureofBussiness.createdBy =User.Identity.Name;
                objLIBtblOrgNatureofBussiness.dt = DateTime.Now.ToShortDateString();
                tp.MessagePacket = objLIBtblOrgNatureofBussiness;
                tp = objDALtblOrgNatureofBussiness.InserttblOrgNatureofBussiness(tp);

                if (tp.MessageId > -1)
                {
                    string[] strOutParamValues = (string[])tp.MessageResultset;
                   
                }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
        }
        protected void ddlfyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlfyear.SelectedIndex > 0)
                {
                    //string str = ddlfyear.SelectedItem.Text;
                    //string[] strnew = str.Split('-');
                    //if (strnew.Length > 0)
                    //{
                    int fyear = Convert.ToInt32(ddlfyear.SelectedItem.Text);

                    lblyr1.Text = (fyear - 1).ToString();

                        lblyr2.Text = (fyear - 2).ToString() ;
                    //}
                    bindyearvalue();
                }
                else
                {
                    lblyr1.Text = "";
                    lblyr2.Text = "";
                    txtAttrition1.Text = "";
                    txtAttrition2.Text = "";
                    txtAttrition3.Text = "";

                    txtHeadCount1.Text = "";
                    txtHeadCount2.Text = "";
                    txtHeadCount3.Text = "";

                    txtProfit1.Text = "";
                    txtProfit2.Text = "";
                    txtProfit3.Text = "";

                    txtturn1.Text = "";
                    txtturn2.Text = "";
                    txtturn3.Text = "";

                    txtWage1.Text = "";
                    txtWage2.Text = "";
                    txtWage3.Text = "";
                }

            }
            catch (Exception ex)
            {
            }
        }
        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlfyear.SelectedIndex > 0)
                {
                    lblcurrency.Text = ddlCurrency.SelectedItem.Text;
                    lblcurrency1.Text = ddlCurrency.SelectedItem.Text;
                    lblcurrency2.Text = ddlCurrency.SelectedItem.Text;
                }
                else
                {
                    lblcurrency.Text = "USD";
                    lblcurrency1.Text = "USD";
                    lblcurrency2.Text = "USD";
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}