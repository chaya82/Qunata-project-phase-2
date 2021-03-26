using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDS.LIB;
using NDS.DAL;
using System.Data;
using System.IO;
using System.Globalization;

namespace Quanta.Manager
{
    public partial class DataInst : System.Web.UI.Page
    {
        MyCLS.clsExecuteStoredProcSql objBll = new MyCLS.clsExecuteStoredProcSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
            if (!Page.IsPostBack)
            {
                bindGridGradedata();
                bindGridPerformancedata();
                lblCurrency.Text = Session["cur"].ToString();
            }
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
        }

    
      
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try{
                DataTable dtNew = new DataTable();
                dtNew.Columns.Add("ORGID", typeof(string));

                dtNew.Columns.Add("DOB", typeof(string));
                dtNew.Columns.Add("Currency", typeof(string));
                string strDOB_age = "";
                
            //LIBtblmstInstruction objLIBtblmstInstruction = new LIBtblmstInstruction();
            //DALtblmstInstruction objDALtblmstInstruction = new DALtblmstInstruction();
            //MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

            //objLIBtblmstInstruction.ID = -1;
            //objLIBtblmstInstruction.currency = ddlCurrency.SelectedValue.ToString();
                if (rdoAge.Checked)
                {
                    strDOB_age = "Age";
                }

                if (rdoDOB.Checked)
                {
                    strDOB_age = "DOB";
                }
                dtNew.Rows.Add(Session["orgid"].ToString(), strDOB_age, Session["cur"].ToString());
                Session["dtinst"] = dtNew;
            //tp.MessagePacket = objLIBtblmstInstruction;
            //tp = objDALtblmstInstruction.InserttblmstInstruction(tp);

            //            if (tp.MessageId > -1)
            //    {
            //        string[] strOutParamValues = (string[])tp.MessageResultset;
                    
            //        ClientScript.RegisterStartupScript(GetType(), "Save", "<SCRIPT LANGUAGE='javascript'>javascript:alert('Saved  Successfully!');location.href='" + Request.Url.AbsoluteUri + "';</script>");
                   Response.Redirect("UploadEmpData.aspx", false);
            //    }
           
        }
        catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }
       
        
        }
        #region Performance
        protected void bindControls(string id)
        {
            try
            {

                DataTable dt = (DataTable)ViewState["dt"];

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.RowFilter = " ID=" + id.ToString();
                    lnkSavePerformance.Text = "Update";
                    hdnperid.Value = dt.DefaultView[0]["ID"].ToString();
                    //txtPerformance.Text = dt.DefaultView[0]["LatestPerformance"].ToString();
                    //ddlyr.SelectedIndex = ddlyr.Items.IndexOf(ddlyr.Items.FindByText(dt.DefaultView[0]["PerLevel"].ToString()));
                   //txtPerlevel.Text = dt.DefaultView[0]["PerLevel"].ToString();
                    Page.ClientScript.RegisterStartupScript(GetType(), "popupDesi", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('modalPerformance');</script>");


                }
            }
            catch (Exception ex)
            {
            }
        }
        void bindGridPerformancedata()
        {
            try
            {


                string qry = "SP_List4AddPerformance " + Session["orgid"].ToString();
                MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                DataTable dt = clsESPSql.ExecQuery(qry);

                ViewState["dt"] = dt;
                if (dt.Rows.Count > 0)
                {
                    rptListPer.DataSource = dt;
                    rptListPer.DataBind();
                }
                dt.DefaultView.RowFilter = "LatestPerformance<>''";
                if (dt.DefaultView.Count > 0)
                {
                    LinkButton lnkremove = (LinkButton)rptListPer.Items[dt.DefaultView.Count - 1].FindControl("lnkremove");
                    lnkremove.Visible = true;
                }

                dt.DefaultView.RowFilter = "";


                }
            catch (Exception ex)
            { }

        }
        protected void rptListCorrect_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                lblsuccessmsg.Text = "";
                lblmsg.Text = "";
                if (e.CommandName == "modify")
                {
                    bindControls(e.CommandArgument.ToString());
                }
                if (e.CommandName == "remove")
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "popupDesi", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('modalPerformance');</script>");
                    string qry = "SELECT TOP 1 1 FROM tblmstPerformance where ID=" + e.CommandArgument.ToString() + " and LatestPerformance  in (select LatestPerformance from tblmstEmployee where orgid=tblmstPerformance.orgid)";
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    DataTable dt = clsESPSql.ExecQuery(qry);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            lblmsg.Text = "Can not be deleted, Already in use! ";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }

                    int res = clsESPSql.DeleteSYData(" where ID=" + e.CommandArgument.ToString() + " and LatestPerformance not in (select LatestPerformance from tblmstEmployee where orgid=tblmstPerformance.orgid)", "tblmstPerformance");
                    string strpg = Request.Url.ToString();
                    lblmsg.Text = "Deleted Successfuly";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    bindGridPerformancedata();
                    Page.ClientScript.RegisterStartupScript(GetType(), "desiSubmit", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('modalPerformance');</script>");
                  

                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void lnkSavePerformance_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                lblsuccessmsg.Text = "";
                //txtSubType.Text = "";
                string no = "";
                int add = 0;
                int upd = 0;
                for (int i = 0; i < rptListPer.Items.Count; i++)
                {
                    TextBox txtPerformance = (TextBox)rptListPer.Items[i].FindControl("txt1");
                    Label lblno = (Label)rptListPer.Items[i].FindControl("lblno");
                    HiddenField hdnid = (HiddenField)rptListPer.Items[i].FindControl("hdnid");

                    LIBtblmstPerformance objLIBtblmstPerformance = new LIBtblmstPerformance();
                    DALtblmstPerformance objDALtblmstPerformance = new DALtblmstPerformance();
                    MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();
                    if (txtPerformance.Text.Trim() != "")
                    {
                        if (hdnid.Value == "")
                        {

                            objLIBtblmstPerformance.id = -1;
                        }
                        else
                        {
                           
                            objLIBtblmstPerformance.id = Convert.ToInt32(hdnid.Value);
                        }


                        objLIBtblmstPerformance.LatestPerformance = txtPerformance.Text.Trim().Length > 0 ? txtPerformance.Text.Replace("'", "''") : "";
                        objLIBtblmstPerformance.PerLevel = Convert.ToInt32(lblno.Text.Trim());
                        objLIBtblmstPerformance.orgid = Convert.ToInt32(Session["orgid"]);
                        tp.MessagePacket = objLIBtblmstPerformance;
                        tp = objDALtblmstPerformance.InserttblmstPerformance(tp);

                        string[] strOutParamValues = (string[])tp.MessageResultset;
                        if (strOutParamValues.Length > 0)
                        {
                            if (strOutParamValues[0].ToString() == "-3")
                            {
                                no = no + "," + lblno.Text.Trim();
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                              
                            }
                            else if (strOutParamValues[0].ToString() == "-2")
                            {
                                lblmsg.Text = lblmsg.Text + "-- " + txtPerformance.Text.Trim() + " This Performance Already Exist.";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                               
                            }
                           
                            else
                            {
                                if (hdnid.Value != "")
                                {
                                    upd = upd + 1;
                                }
                                else
                                {
                                    add = add + 1;
                                }
                               
                               
                                 
                               
                            }
                          
                        }
                    }
                }
                if (add > 0 || upd > 0)
                {
                    lblsuccessmsg.Text =  "Performance mapping saved successfully";
                }
                //if (upd > 0)
                //{
                //    lblsuccessmsg.Text =lblsuccessmsg.Text+"/"+ upd.ToString() + " Performance Modified Successfully";
                //}
                bindGridPerformancedata();
                //Response.Redirect(Request.Url.ToString(), false);
                if (no != "")
                {
                    lblmsg.Text = no + " Preformance  Rating should be in sequence";
                }
                string msg = lblsuccessmsg.Text +  lblmsg.Text;
                ClientScript.RegisterStartupScript(GetType(), "Save", "<SCRIPT LANGUAGE='javascript'>javascript:alert('" + msg + "');</script>");
             
              //  lnkSavePerformance.Text = "Add";
                
            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }


        }
        #endregion Performance

        #region Grade
        protected void bindControlsGrade(string id)
        {
            try
            {

                DataTable dt = (DataTable)ViewState["dtGrade"];

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.RowFilter = " ID=" + id.ToString();
                    lnkSaveGrade.Text = "Update";
                    hdnID.Value = dt.DefaultView[0]["ID"].ToString();
                    //txtGrade.Text = dt.DefaultView[0]["Grade"].ToString();
                    //ddllevel.SelectedIndex =ddllevel.Items.IndexOf(ddllevel.Items.FindByText( dt.DefaultView[0]["GLevel"].ToString()));
                    Page.ClientScript.RegisterStartupScript(GetType(), "popupDesi", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('newModal');</script>");


                }
            }
            catch (Exception ex)
            {
            }
        }
        void bindGridGradedata()
        {
            try
            {


                string qry = "SP_List4AddGrade " + Session["orgid"].ToString();
                MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                DataTable dt = clsESPSql.ExecQuery(qry);
                ViewState["dtGrade"] = dt;
                rptGrade.DataSource = dt;
                rptGrade.DataBind();
                dt.DefaultView.RowFilter = "Grade<>''";
                if (dt.DefaultView.Count > 0)
                {
                    LinkButton lnkremove = (LinkButton)rptGrade.Items[dt.DefaultView.Count-1].FindControl("lnkremove");
                    lnkremove.Visible = true;
                }

                dt.DefaultView.RowFilter = "";

            }
            catch (Exception ex)
            { }

        }
        protected void rptListGrade_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                lblmsg1.Text = "";
                lblsuccessmsg1.Text = "";
                if (e.CommandName == "modify")
                {
                    bindControlsGrade(e.CommandArgument.ToString());
                    Page.ClientScript.RegisterStartupScript(GetType(), "popupDesi", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('newModal');</script>");
                }
                if (e.CommandName == "remove")
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "popupDesi", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('newModal');</script>");
                    string qry = "SELECT TOP 1 1 FROM tblmstgrade where ID=" + e.CommandArgument.ToString() + " and Grade  in (select Grade from tblmstEmployee where orgid=tblmstgrade.orgid)";
                    MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
                    DataTable dt = clsESPSql.ExecQuery(qry);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            lblmsg1.Text = "Can not be deleted, Already in use! ";
                            lblmsg1.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }

                    int res = clsESPSql.DeleteSYData(" where ID=" + e.CommandArgument.ToString() + " and  Grade not in (select Grade from tblmstEmployee where orgid=tblmstgrade.orgid)", "tblmstgrade");
                    string strpg = Request.Url.ToString();
                    lblmsg1.Text = "Deleted Successfuly";
                    lblmsg1.ForeColor = System.Drawing.Color.Red;
                    bindGridGradedata();
                    Page.ClientScript.RegisterStartupScript(GetType(), "desiSubmit", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('newModal');</script>");


                }
            }
            catch (Exception ex)
            {
            }
        }
      
        protected void lnkSaveGrade_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg1.Text = "";
                lblsuccessmsg1.Text = "";
                //txtSubType.Text = "";
                string no = "";
                int add = 0;
                int upd = 0;
                for (int i = 0; i < rptGrade.Items.Count; i++)
                {
                    TextBox txtGrade = (TextBox)rptGrade.Items[i].FindControl("txt1");
                    Label lblno = (Label)rptGrade.Items[i].FindControl("lblno");
                    HiddenField hdnid = (HiddenField)rptGrade.Items[i].FindControl("hdnid");
                    if (txtGrade.Text != "")
                    {
                        LIBtblmstgrade objLIBtblmstgrade = new LIBtblmstgrade();
                        DALtblmstgrade objDALtblmstgrade = new DALtblmstgrade();
                        MyCLS.TransportationPacket tp = new MyCLS.TransportationPacket();

                        if (hdnid.Value == "")
                        {

                            objLIBtblmstgrade.id = -1;
                        }
                        else
                        {

                            objLIBtblmstgrade.id = Convert.ToInt32(hdnid.Value);
                        }


                        objLIBtblmstgrade.Grade = txtGrade.Text.Trim().Length > 0 ? txtGrade.Text.Replace("'", "''") : "";
                        objLIBtblmstgrade.GLevel = Convert.ToInt32(lblno.Text.Trim());
                        objLIBtblmstgrade.orgid = Convert.ToInt32(Session["orgid"]);
                        tp.MessagePacket = objLIBtblmstgrade;
                        tp = objDALtblmstgrade.Inserttblmstgrade(tp);

                        string[] strOutParamValues = (string[])tp.MessageResultset;
                        if (strOutParamValues.Length > 0)
                        {
                            if (strOutParamValues[0].ToString() == "-3")
                            {
                                no = no + "," + lblno.Text.Trim();

                                lblmsg1.ForeColor = System.Drawing.Color.Red;
                               

                            }
                            else  if (strOutParamValues[0].ToString() == "-2")
                            {
                                lblmsg1.Text = lblmsg1.Text + "--" + txtGrade.Text.Trim() + ":  Grade Already Exist.";

                                lblmsg1.ForeColor = System.Drawing.Color.Red;

                            }

                            else
                            {

                                if (hdnid.Value != "")
                                {
                                    upd = upd + 1;
                                }
                                else
                                {
                                    add = add + 1;
                                }

                            }

                        }
                    }
                }
                if (add > 0 || upd > 0)
                {
                    lblsuccessmsg1.Text = "  Grade mapping saved successfully";
                  
                }
                //if (upd > 0)
                //{
                //    lblsuccessmsg1.Text = lblsuccessmsg1.Text + "/" + upd.ToString() + " Grade Modified Successfully";
                //}
                bindGridGradedata();
                //Response.Redirect(Request.Url.ToString(), false);
                if (no != "")
                {
                    lblmsg1.Text = no + " : Grade Position should be in sequence ";
                }
                string msg = lblsuccessmsg1.Text   + lblmsg1.Text;
                ClientScript.RegisterStartupScript(GetType(), "Save", "<SCRIPT LANGUAGE='javascript'>javascript:alert('"+msg+"');</script>");

            }
            catch (Exception ex)
            {
                MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString(), true);
            }


        }
        #endregion Grade

        protected void rptListPer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    TextBox txtPerformance = (TextBox)e.Item.FindControl("txt1");
                    LinkButton lnkremove = (LinkButton)e.Item.FindControl("lnkremove");
                    if (txtPerformance.Text.Trim() == "")
                    {
                        lnkremove.Visible = false;

                    }

                }

                catch (Exception ex)
                {
                }
            }
        }
        protected void rptGrade_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    TextBox txtPerformance = (TextBox)e.Item.FindControl("txt1");
                    LinkButton lnkremove = (LinkButton)e.Item.FindControl("lnkremove");
                    if (txtPerformance.Text.Trim() == "")
                    {
                        lnkremove.Visible = false;

                    }

                }

                catch (Exception ex)
                {
                }
            }
        }



        protected void lnkaddmore_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["dt"];

                DataTable dtNew = new DataTable();
                dtNew.Columns.Add("Number", typeof(string));
                dtNew.Columns.Add("LatestPerformance", typeof(string));
                dtNew.Columns.Add("ID", typeof(string));
                for (int i = 0; i < rptListPer.Items.Count; i++)
                {
                    TextBox txtGrade = (TextBox)rptListPer.Items[i].FindControl("txt1");
                    Label lblno = (Label)rptListPer.Items[i].FindControl("lblno");
                    HiddenField hdnid = (HiddenField)rptListPer.Items[i].FindControl("hdnid");

                    dtNew.Rows.Add(lblno.Text, txtGrade.Text, hdnid.Value);

                }

                dtNew.Rows.Add(rptListPer.Items.Count + 1, null, null);
                dtNew.AcceptChanges();
                rptListPer.DataSource = dtNew;
                rptListPer.DataBind();
                dt.DefaultView.RowFilter = "LatestPerformance<>''";
                if (dt.DefaultView.Count > 0)
                {
                    LinkButton lnkremove = (LinkButton)rptListPer.Items[dt.DefaultView.Count - 1].FindControl("lnkremove");
                    lnkremove.Visible = true;
                }

                dt.DefaultView.RowFilter = "";
                Page.ClientScript.RegisterStartupScript(GetType(), "desiSubmit", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('modalPerformance');</script>");
            }
            catch (Exception ex)
            {
            }
        }
        protected void lnkaddmoreGrade_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["dtGrade"];
                //dt.DefaultView.RowFilter = "id=''";

                //int rcnt = dt.Rows.Count + 1;
                DataTable dtNew = new DataTable();
                dtNew.Columns.Add("Number", typeof(string));
                dtNew.Columns.Add("Grade", typeof(string));
                dtNew.Columns.Add("ID", typeof(string));
                for (int i = 0; i < rptGrade.Items.Count; i++)
                {
                    TextBox txtGrade = (TextBox)rptGrade.Items[i].FindControl("txt1");
                    Label lblno = (Label)rptGrade.Items[i].FindControl("lblno");
                    HiddenField hdnid = (HiddenField)rptGrade.Items[i].FindControl("hdnid");

                    dtNew.Rows.Add(lblno.Text, txtGrade.Text, hdnid.Value);
                    
                }

                dtNew.Rows.Add(rptGrade.Items.Count+1, null, null);
                dtNew.AcceptChanges();
                rptGrade.DataSource = dtNew;
                rptGrade.DataBind();
                dt.DefaultView.RowFilter = "Grade<>''";
                if (dt.DefaultView.Count > 0)
                {
                    LinkButton lnkremove = (LinkButton)rptGrade.Items[dt.DefaultView.Count - 1].FindControl("lnkremove");
                    lnkremove.Visible = true;
                }

                dt.DefaultView.RowFilter = "";
                Page.ClientScript.RegisterStartupScript(GetType(), "newrow", "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp('newModal');</script>");
            }
            catch (Exception ex)
            {
            }
        }
        protected void closemodal(object sender, EventArgs e)
        {
            try
            {
                bindGridGradedata();
                lblsuccessmsg1.Text = "";
                lblmsg1.Text = "";
                
            }
            catch (Exception ex)
            {
            }
        }
        protected void closemodalper(object sender, EventArgs e)
        {
            try
            {
                bindGridPerformancedata();
                lblsuccessmsg.Text = "";
                lblmsg.Text = "";

            }
            catch (Exception ex)
            {
            }
        }
    }
}