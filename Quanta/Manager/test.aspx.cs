using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using NDS.DAL; 

namespace Quanta.Manager
{
    public partial class test : System.Web.UI.Page
    {
        private SqlConnection con;
        private SqlCommand com;
        private string constr, query;
        private void connection()
        {
            constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
            con.Open();

          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DALCommon cmn = new DALCommon();
                string strBody = cmn.prcFindInFile(Server.MapPath("login.html").ToString(), "#UserName#", "");


                cmn.SendHtmlFormattedEmail("chaya.pandey@gmail.com", "Account Created", strBody);

                Bindchart();

            }
        }

        private void Bindchart()
        {
            string qry = "[dbo].SP_GetRptTFPOverAll " + HttpContext.Current.Session["orgid"].ToString() + "";
            MyCLS.clsExecuteStoredProcSql clsESPSql = new MyCLS.clsExecuteStoredProcSql();
            DataTable dt = clsESPSql.ExecQuery(qry);

            DataTable ChartData = dt;

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["fyear"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["cnt"]);


            }
            //binding chart control  
            Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            Chart1.Series[0].BorderWidth = 10;
            //setting Chart type   
            Chart1.Series[0].ChartType = SeriesChartType.RangeColumn;
            //Chart1.Legends(0).Enabled = True;
            //Hide or show chart back GridLines  
            // Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;  
            // Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;  

            //Enabled 3D  
            //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;  
           

        }  
    }
}