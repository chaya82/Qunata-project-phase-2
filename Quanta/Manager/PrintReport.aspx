<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/InnerBlank.Master" AutoEventWireup="true" CodeBehind="PrintReport.aspx.cs" Inherits="Quanta.Manager.PrintReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->
  <script src="/assets/js/app.min.js"></script>
   <script src="/assets/bundles/chartjs/chart.min.js"></script>
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
  <script src="../assets/js/print.js"></script>
  
 <style>
 
 canvas{
 
  height:400px;
}
 #chart1_1 {
  width: 100%;
  height: 400px;
}
 </style>
 
 
 
 <script type="text/javascript">


     function print() {
         printJS({
             printable: 'PrintAll',
             type: 'html',
             targetStyles: ['*']
         })
     }
  
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Download Report </h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Reports </div>
              
            </div>
          </div>
          <div class="section-body">
          <a  href="#" onclick="splPrint('PrintAll')">Print/Save as PDF</a>
              
              <div id="PrintAll">   
              <%--chart1--%>
                <div class="card">
                 <div class="card-header">
                    <h4>Head Count</h4>
                  </div>
                 <div class="card-body">
<div class="row">
  
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                 
                  <div class="card-body">
                    <div >
                      <div id="chart1" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p id="chart1_C"> The headcount is simply the number of people employed by a business at a given time.<br /><br />Organization level: The attached graph shows the trend (If multi-year data has been provided) of change in Organization Level Headcount.  <br /><br />Headcount by Function/ Department: The graph show the current spread of headcount across different departments. The % indicates the Department Headcount as a % of Total Headcount and can help you spot any pockets of over/ under staffing
     </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                  
                  <div class="card-body">
              
               
                        <div id='chart1_1' ></div>
                     
                              
                    
                     </div>
                    
                
                </div>
              </div>
              
            </div>
            </div>
            </div>

              <%--chart2--%>
               <div class="card">
                 <div class="card-header">
                    <h4>Age Spread</h4>
                  </div>
                 <div class="card-body">
               <div class="row">
               <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                
                  <div class="card-body">
                    <div >
                      <div id="chart2" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
                The Age distribution in an organization is an indicator of staff age demographic in different departments and levels</br></br>

You can see the age distribution of your employees in different departments and levels as well as the average age for each department and level</br></br>

This can help in identifying levels where a high age average can be indicative of career plateaus, functions that may be lacking desired ageprofile or potential scenario of high number of retiring staff in levels or functions 
           </p>
                    </div>
                  </div>
                </div>
              </div>
               </div>
               <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                
                  <div class="card-body">
              <ul class="nav nav-pills"  role="tablist">
                      <li class="nav-item" >
                        <a class="nav-link active" id="uploaded-data-chart2" data-toggle="tab" href="#uploaded-chart2"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart2"  runat="server" ClientIDMode="Static"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="myTabContent-chart2">     
                               <div class="tab-pane fade active show" id="uploaded-chart2" role="tabpanel" aria-labelledby="uploaded-data">
                 
                          <div class="card">
                  
                  <div class="card-body">
                     <div id='chart2_dept'></div>
                 </div>
                 </div>
                 <div class="card">
                  
                  <div class="card-body">
                     <div id='chart2_level' ></div>
                 </div>
                 </div>
                 <div class="card">
                  
                   <div class="card-body">
                    <div id="chart2_dept_stack" ></div>
                  </div>
                 </div>
                 <div class="card">
                  
                   <div class="card-body">
                 
                 <div id='chart2_level_stack'></div>
                  </div>
                 </div>
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>
            </div>
            </div>
              <%--chart3--%>
               <div class="card">
                 <div class="card-header">
                    <h4>Tenure Spread</h4>
                  </div>
                 <div class="card-body">
          <div class="row">
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                
                  <div class="card-body">
                    <div >
                      <div id="chart3" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
              The Tenure distribution in an organization is an indicator of staff retention/ organizational experience in different departments and levels<br />

You can see the Tenure distribution of your employees in different departments and levels as well as the average tenure for each department and level<br />

This can help in identifying Levels and Departments with high or low tenure compared to the Organizational average. Indicative of possible lack of fresh blood in the company or lack of organizational experience. Ideal company spreads should have a balance between organizational experience and new perspectives. Low tenure averages can also reflect on the organization’s ability to retain staff 
    </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                
                  <div class="card-body">
              <ul class="nav nav-pills"  role="tablist">
                      <li class="nav-item" >
                        <a class="nav-link active" id="uploaded-data-chart3" data-toggle="tab" href="#uploaded-chart3"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart3"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="myTabContent-chart3">     
                               <div class="tab-pane fade active show" id="uploaded-chart3" role="tabpanel" aria-labelledby="uploaded-data">
                 
                          <div class="card">
                  
                  <div class="card-body">
                     <div id='chart3_dept'></div>
                 </div>
                 </div>
                 <div class="card">
                  
                  <div class="card-body">
                     <div id='chart3_level' ></div>
                 </div>
                 </div>
                 <div class="card">
                  
                   <div class="card-body">
                    <div id="chart3_dept_stack" ></div>
                  </div>
                 </div>
                 <div class="card">
                  
                   <div class="card-body">
                 
                 <div id='chart3_level_stack'></div>
                  </div>
                 </div>
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>

            </div>
            </div>

              <%--chart4--%>
               <div class="card">
                 <div class="card-header">
                    <h4>Diversity</h4>
                  </div>
                 <div class="card-body">
               <div class="row">
               <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                
                  <div class="card-body">
                    <div >
                      <div id="chart4" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
                Research has shown that diversity has a positive impact on organizational productivity. Gender Diversity refers to the ratio of men and women in the workforce. It is an indicator of an employer’s commitment to providing equal opportunities to men and women. <br /><br />

You can see the Gender distribution in your workforce and in different departments and levels. Seeing the skew in the gender distribution, you can identify pockets of the organization where focussed action might be required for enhancing gender diversity.
</p>
                    </div>
                  </div>
                </div>
              </div>
               </div>
               <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                
                  <div class="card-body">
              <ul class="nav nav-pills"  role="tablist">
                      <li class="nav-item" >
                        <a class="nav-link active" id="uploaded-data-chart4" data-toggle="tab" href="#uploaded-chart4"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart4"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="myTabContent-chart4">     
                               <div class="tab-pane fade active show" id="uploaded-chart4" role="tabpanel" aria-labelledby="uploaded-data">
                 
                
                 <div class="card">
                   <div class="card-body">
                    <div id="chart4_dept_stack" ></div>
                  </div>
                 </div>
                 <div class="card">
                   <div class="card-body">
                 
                 <div id='chart4_level_stack'></div>
                  </div>
                 </div>
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>


               </div>
               </div>
                 <%--chart5--%>
                  <div class="card">
                 <div class="card-header">
                    <h4>Pyramid</h4>
                  </div>
                 <div class="card-body">
            <div class="row">
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                
                  <div class="card-body">
                    <div >
                      <div id="chart5" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
               The organization pyramid shows the distribution of staff strength across different levels and grades. Typically the pyramids are broad at the bottom and narrow at the top.
               <br />
               <img src="../images/Pyramid representation.png" style="width:50%" />
               <br />
                By looking at the shape of your organizational pyramid, you can see possible levels which may be overstaffed or understaffed.  </p>
                    </div>
                  </div>
                </div>
              </div>
              
            </div>
            </div>
            </div>
              <%--chart6--%>
               <div class="card">
                 <div class="card-header">
                    <h4>Span of Control</h4>
                  </div>
                 <div class="card-body">
               <div class="row">
               <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                 
                  <div class="card-body">
                    <div >
                      <div id="chart6" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
               Span of control indicates the number of subordinates a supervisor has and for an organization or team is represented as an average ratio.<br /><br />

This is a very helpful metric for determining manager utilization. A very low SpOC can be indicative of under utilization of the managers and a very high SpOC can indicate over burdening of the manager (thereby reducing their effectiveness). 
   </p>
                    </div>
                  </div>
                </div>
              </div>
               </div>
               <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                
                  <div class="card-body">
              <ul class="nav nav-pills"  role="tablist">
                      <li class="nav-item" >
                        <a class="nav-link active" id="uploaded-data-chart5" data-toggle="tab" href="#uploaded-chart6"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart6"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="myTabContent-chart5">     
                               <div class="tab-pane fade active show" id="uploaded-chart6" role="tabpanel" aria-labelledby="uploaded-data">
                 
                
                 <div class="card">
                   <div class="card-body">
                    <div id="chart6_dept" ></div>
                  </div>
                 </div>
                 <div class="card">
                   <div class="card-body">
                 
                 <div id='chart6_level'></div>
                  </div>
                 </div>
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>


               </div>
               </div>

                 <%--chart7--%>
                  <div class="card">
                 <div class="card-header">
                    <h4>Total Fixed Pay</h4>
                  </div>
                 <div class="card-body">
            <div class="row">
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
               
                  <div class="card-body">
                    <div >
                      <div id="chart7" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
                Total Fixed Pay represents the aggregate of the fixed wage cost for the organization<br />

By looking at the TFP spread for departments and for levels you can determine if there is a skew/ disproportionate allocation in TFP for any pocket. It can help provide direction for any correction/ more equitable distribution
            </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                
                  <div class="card-body">
              <ul class="nav nav-pills"  role="tablist">
                      <li class="nav-item" >
                        <a class="nav-link active" id="A1" data-toggle="tab" href="#uploaded-chart7"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart7"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="Div1">     
                               <div class="tab-pane fade active show" id="uploaded-chart7" role="tabpanel" aria-labelledby="uploaded-data">
                 
                
                 <div class="card">
                   <div class="card-body">
                    <div id="chart7_dept" ></div>
                  </div>
                 </div>
                 <div class="card">
                   <div class="card-body">
                 
                 <div id='chart7_level'></div>
                  </div>
                 </div>
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>


            </div>
            </div>
              <%--chart8--%>
               <div class="card">
                 <div class="card-header">
                    <h4>Performance Spread</h4>
                  </div>
                 <div class="card-body">
             <div class="row">
             <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                
                  <div class="card-body">
                    <div >
                      <div id="chart8" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
                The performance spread indicates what % of the employees are falling in which performance category at the organization, Department and Grade levels<br /><br />

It is a good way to identify overall spread in light of business performance (assuming good business performance reflects good individual performance and vice versa) and also potential biases in performance rating spread in any department/ level
</p>
                    </div>
                  </div>
                </div>
              </div>
             </div>
             <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                
                  <div class="card-body">
              <ul class="nav nav-pills"  role="tablist">
                      <li class="nav-item" >
                        <a class="nav-link active" id="uploaded-data-chart8" data-toggle="tab" href="#uploaded-chart8"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart8"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="myTabContent-chart8">     
                               <div class="tab-pane fade active show" id="uploaded-chart8" role="tabpanel" aria-labelledby="uploaded-data">
                 
                
                 <div class="card">
                   <div class="card-body">
                    <div id="chart8_dept_stack" ></div>
                  </div>
                 </div>
                 <div class="card">
                   <div class="card-body">
                 
                 <div id='chart8_level_stack'></div>
                  </div>
                 </div>
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>


             </div>
             </div>
               <%--chart9--%>
                <div class="card">
                 <div class="card-header">
                    <h4>Attrition</h4>
                  </div>
                 <div class="card-body">
            <div class="row">
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                
                  <div class="card-body">
                    <div >
                      <div id="chart9" ></div>
                    </div>
                  </div>
                </div>
              </div>
                 <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
              Indicates the % of employees who are leaving the organization each year.<br /><br />
Reflects on the ability of the organization to retain staff. A reducing trend in attrition is considered positive
  </p>
                    </div>
                  </div>
                </div>
              </div>
              <a class='btn btn-warning add-btn' href='javascript:window.print();'>Print</a>
            </div>  
            </div>
            </div>
            </div>
</div>
</section>
</div>
<script type="text/javascript">
   
  var dataur=[];
    var i=0;
     var yr=document.getElementById("lblchart2").innerHTML;
    var chartTextColor= '#96a2b4';
    $(document).ready(function () {
    chart( "RPTHeadCount.aspx/GetHC_Yearwise","chart1",'Average Headcount','Overall Headcount of the Company',1);
    getPie( "RPTHeadCount.aspx/GetHC_deptWise","chart1_1",'Department',1.1,0);
//    Age Spread
       chart("RPTAgeSpread.aspx/GetYearwise","chart2",'Average Age','Overall Age Spread of the Company',2);
       chartbar("RPTAgeSpread.aspx/GetdeptWise","chart2_dept",'Average Age','Average Age by Department',2.1);
       chartbar("RPTAgeSpread.aspx/GetgradeWise","chart2_level",'Average Age','Average Age by Level',2.2);
       chart2("RPTAgeSpread.aspx/GetAgeDistdeptWise","chart2_dept_stack","Age Distribution by Department","yes",2.3);
       chart2("RPTAgeSpread.aspx/GetAgeDistLevelWise","chart2_level_stack","Age Distribution by Level","yes",2.4);

       chart("RPTTenureSpread.aspx/GetYearwise","chart3",'Average Tenure','Overall Average Tenure of the Company',3);
       chartbar("RPTTenureSpread.aspx/GetdeptWise","chart3_dept",'Average Tenure','Average Tenure by Department',3.1);
       chartbar("RPTTenureSpread.aspx/GetgradeWise","chart3_level",'Average Tenure','Average Tenure by Level',3.2);
       chart2("RPTTenureSpread.aspx/GetAgeDistdeptWise","chart3_dept_stack","Tenure Distribution by Department","yes",3.3);
       chart2("RPTTenureSpread.aspx/GetAgeDistLevelWise","chart3_level_stack","Tenure Distribution by Level","yes",3.4);


       chart2("RPTGenderDist.aspx/GetgenderDistOrgWise","chart4","Overall Gender Mix of the Company","",4);
        chart2("RPTGenderDist.aspx/GetGenderDistdeptWise","chart4_dept_stack","Gender Distribution by Department","yes",4.1);
       chart2("RPTGenderDist.aspx/GetgenderDistLevelWise","chart4_level_stack","Gender Distribution by Level","yes",4.2);


       chart3("RPTorgPyramid.aspx/GetLeveWise","chart5","Population Distribution by Grade of the Company",5);


        chart("RPTSPOC.aspx/GetOrgWise","chart6",'Average SPOC','Average Span of Control of the Company',6);
        chartbarline("RPTSPOC.aspx/GetDistdeptWise","chart6_dept",'Span of Control  by Department',6.1);
        chartbarline("RPTSPOC.aspx/GetDistLevelWise","chart6_level",'Span of Control  by Level',6.2);

       chart("RPTTFP.aspx/GetYearwise","chart7",'Average Gross Pay','Overall Total Fixed Pay of the Company',7);
       chartHorbar("RPTTFP.aspx/GetAgeDistdeptWise","chart7_dept",'Overall Total Fixed Pay of the Company',7.1);
       chartHorbar("RPTTFP.aspx/GetAgeDistLevelWise","chart7_level",'Overall Total Fixed Pay of the Company',7.2);

       chart2( "RPTPrefSpread.aspx/GetgenderDistOrgWise","chart8","Overall Organization Performance Spread","",8);
           chart2("RPTPrefSpread.aspx/GetGenderDistdeptWise","chart8_dept_stack","Performance Distribution by Department","yes",8.1);
       chart2("RPTPrefSpread.aspx/GetgenderDistLevelWise","chart8_level_stack","Performance Distribution by Level","yes",8.2);

       chartAttr("RPTAttrtion.aspx/GetYearwise","chart9",'Average Attrtion','Organization-wide Attrition',9);
    });
    
   

   
    function chart(url,id,name,title,no){
      var dataHC = []
     $.ajax({
            type: "POST",
            url: url,
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success:  function OnSuccess(response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
        
        dataHC = ResponeData;
         var options = {
	          series: [{
                name:name,
	          data: dataHC[0].value
	        }],
	          chart: {
	          type: 'bar',
              foreColor: chartTextColor,
	          height: 350,
	          toolbar : {
					show : false
				}
	        },
	        colors: ['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
	        plotOptions: {
	          bar: {
	            horizontal: false,
                distributed: true,
	            dataLabels: {
	              position: 'top',
	            },
	          }
	        },
             tooltip: {
      enabled: true,
      y: {
    formatter: function(value, { series, seriesIndex, dataPointIndex, w }) {
      return value
    }
  }
        },
	        dataLabels: {
	          enabled: true,
	          offsetX: 0,
	          style: {
	            fontSize: '12px',
	            colors: ['#fff']
	          }
	        },
	        stroke: {
	          show: false,
	          width: 1,
	          colors: ['#fff']
	        },
	        xaxis: {
            name:"year",
	          categories:dataHC[0].label,
	        },
            title: {
          text: title,
           style: {
                    fontWeight:  'bold'
                  }
        }
	        };

        var chart = new ApexCharts(
            document.querySelector("#"+id),
            options
        );

        chart.render().then(() => {
    window.setTimeout(function() {
        chart.dataURI().then((uri) => {
        var eachElement = {};
        eachElement.title = Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
         
        })
    }, 1000) 
})
   
        },

            failure: function (response) {
                alert("Error");
            }
        });
	
    
    }


     function chart2(url,id,title,dat,no){
     var strdata="";
     if(dat=="")
     {
     strdata='{}';
     }
     else
     {
     strdata= '{yr:"' + yr + '"}'
     }

      $.ajax({
            type: "POST",
            url: url,
            data: strdata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
         var dataorg = []
        dataorg = ResponeData;
        var ResponeData = JSON.parse(response.d);
        
     
       

    /* Bar chart */

    /* Chart data*/
    var chartdata =dataorg[0];

     var options = {
          series: chartdata,
          chart: {
          type: 'bar',
           foreColor: '#96a2b4',
          height: 350,
          stacked: true,
          stackType: '100%',
          toolbar : {
					show : false
				}
        },
         dataLabels: {
          enabled: false
        },
        responsive: [{
          breakpoint: 480,
          options: {
            legend: {
              position: 'bottom',
              offsetX: -10,
              offsetY: 0
            }
          }
        }],
          colors: ['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
        xaxis: {
          categories: dataorg[1][0].cat,
        },
          yaxis: {
 
  max: 100,
  tickAmount: 5,
  labels: {
    formatter: (value) => value.toFixed(0) +'%',
  },
},
      tooltip: {
  y: {
    formatter: function(value, opts) {
      var percent = opts.w.globals.seriesPercent[opts.seriesIndex][opts.dataPointIndex];
      return percent.toFixed(1) + '%'
    }
  }
},  
        fill: {
          opacity: 1
        },
        legend: {
          position: 'right',
          offsetX: 0,
          offsetY: 50
        },
         title: {
          text: title,
           style: {
                    fontWeight:  'bold'
                  }
        }
        };

        var chart = new ApexCharts(document.querySelector("#"+id), options);
       chart.render().then(() => {
    window.setTimeout(function() {
        chart.dataURI().then((uri) => {
        var eachElement = {};
        eachElement.title= Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
        })
    }, 1000) 
})
   
        
},
            failure: function (response) {
                alert("Error");
            }
        });
     }
     function chart3(url,id,title,no){
       var dataHC = []
      $.ajax({
            type: "POST",
            url: url,
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
        
        dataHC = ResponeData;
        var options = {
          series: dataHC[0],
          chart: {
          type: 'bar',
          foreColor: chartTextColor,
         height: 350,
          stacked: true,
          toolbar : {
					show : false
				}
        },
        colors: ['#008FFB'],
        plotOptions: {
          bar: {
            horizontal: true
           
         
        
          },
        },
        dataLabels: {
          enabled: false
        },
        stroke: {
          width: 1,
          colors: ["#fff"]
        },
        legend: {
    show: false
  },
        grid: {
          xaxis: {
            lines: {
              show: false
            }
          }
        },
        yaxis: {
         
          title: {
            text: 'Grade',
          },
        },
        tooltip: {
          shared: false,
          x: {
            formatter: function (val) {
              return val
            }
          },
          y: {
            formatter: function (val) {
              return Math.abs(val) 
            }
          }
        },
        title: {
          text: title,
           style: {
                    fontWeight:  'bold'
                  }
        },
        xaxis: {
          categories: dataHC[1][0].cat,
          
          labels: {
            formatter: function (val) {
              return ""
            }
          }
        },
        };

        var chart = new ApexCharts(document.querySelector("#"+id), options);
      chart.render().then(() => {
    window.setTimeout(function() {
        chart.dataURI().then((uri) => {
        var eachElement = {};
        eachElement.title= Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
        })
    }, 1000) 
})
   
        
},
            failure: function (response) {
                alert("Error");
            }
        });
   
	
    
    }

    function chartAttr(url,id,name,title,no){
      var dataHC = []
     $.ajax({
            type: "POST",
            url: url,
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success:  function OnSuccess(response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
        
        dataHC = ResponeData;
         var options = {
	          series: [{
                name:name,
	          data: dataHC[0].value
	        }],
	          chart: {
	          type: 'bar',
              foreColor: chartTextColor,
	          height: 350,
	          toolbar : {
					show : false
				}
	        },
	        colors: ['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
	        plotOptions: {
	          bar: {
	            horizontal: false,
                distributed: true,
	            dataLabels: {
	              position: 'top',
	            },
	          }
	        },
	        dataLabels: {
	          enabled: true,
	          offsetX: 0,
	          style: {
	            fontSize: '12px',
	            colors: ['#fff']
	          },
              formatter: function(val, opt) {
      return  val+ "%"
  }
	        },
	        stroke: {
	          show: false,
	          width: 1,
	          colors: ['#fff']
	        },
	        xaxis: {
            name:"year",
	          categories:dataHC[0].label,
	        },
             title: {
          text: title,
           style: {
                    fontWeight:  'bold'
                  }
        },
            yaxis: {
 
 
  tickAmount: 5,
  labels: {
    formatter: (value) => value.toFixed(0) +'%',
  },
}
	        };

        var chart = new ApexCharts(
            document.querySelector("#"+id),
            options
        );

       chart.render().then(() => {
    window.setTimeout(function() {
        chart.dataURI().then((uri) => {
       var eachElement = {};
        eachElement.title= Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
        })
    }, 1000) 
})
   
        },

            failure: function (response) {
                alert("Error");
            }
        });
	
    
    }
   
       function chartbar(url,id,name,title,no){
     
       $.ajax({
              type: "POST",
              url: url,
              data: '{yr:"' + yr + '"}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {

               var ResponeData = JSON.parse(response.d);
         var dates = []
                dates = ResponeData;
                  var options = {
	          series: [{
                name:name,
	          data: dates[0].value
	        }],
	          chart: {
	          type: 'bar',
              foreColor: '#96a2b4',
	          height: 350,
	          toolbar : {
					show : false
				}
	        },
	        colors: ['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
	        plotOptions: {
	          bar: {
	            horizontal: false,
                distributed: true,
	            dataLabels: {
	              position: 'top',
	            },
	          }
	        },
             tooltip: {
      enabled: true,
      y: {
    formatter: function(value, { series, seriesIndex, dataPointIndex, w }) {
      return value
    }
  }
        },
	        dataLabels: {
	          enabled: true,
	          offsetX: 0,
	          style: {
	            fontSize: '12px',
	            colors: ['#fff']
	          }
	        },
	        stroke: {
	          show: false,
	          width: 1,
	          colors: ['#fff']
	        },
             title: {
          text: title,
           style: {
                    fontWeight:  'bold'
                  }
        },
	        xaxis: {
	          categories:dates[0].label,
	        }
	        };

        var chart = new ApexCharts(
            document.querySelector("#"+id),
            options
        );

       chart.render().then(() => {
    window.setTimeout(function() {
        chart.dataURI().then((uri) => {
       var eachElement = {};
        eachElement.title= Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
        })
    }, 1000) 
})
              },
              failure: function (response) {
                  alert("Error");
              }
          });
	 
    
    }

    function chartbarline(url,id,title,no)
   {
    var dates2 = []
    $.ajax({
            type: "POST",
            url: url,
          data: '{yr:"' + yr + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessageDist,
            failure: function (response) {
                alert("Error");
            }
        });

          function OnSuccessageDist(response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
        
        dates2 = ResponeData;
       

    /* Bar chart */

    /* Chart data*/
    var chartdata =dates2[0];

 var options = {
	          series: chartdata,
	          chart: {
	          height: 350,
	          type: 'line',
               foreColor: chartTextColor,
	          stacked: false,
          toolbar : {
					show : false
				}
	        },
            colors: ['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
	        dataLabels: {
	          enabled: false
	        },
	        stroke: {
	          width: 4

             
	        },
            markers: {
          size: 0
          },
	        title: {
	          text: ''
	          
	        },
	        xaxis: {
	          categories:  dates2[1][0].cat,
	        },
	        yaxis: [
	          {
	            axisTicks: {
	              show: true,
	            },
	            axisBorder: {
	              show: true,
	              color: '#fcbe06'
	            },
	            labels: {
	              style: {
	                colors: '#fcbe06',
	              }
	            },
	            title: {
	              text: title,
           style: {
                    fontWeight:  'bold'
                  }
	            },
	            tooltip: {
	              enabled: true
	            }
	          },
	          
	          
	        ],
	        tooltip: {
	          fixed: {
	            enabled: true,
	            position: 'topLeft',
	            offsetY: 30,
	            offsetX: 60
	          },
	        },
	        legend: {
	          horizontalAlign: 'left',
	          offsetX: 40
	        }
	        };

    var chart = new ApexCharts(
      document.querySelector("#"+id),
      options
    );

     chart.render().then(() => {
    window.setTimeout(function() {
        chart.dataURI().then((uri) => {
       var eachElement = {};
        eachElement.title= Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
        })
    }, 1000) 
})
   }
   }
    function chartHorbar(url,id,title,no)
   {
    var dates2 = []
    
    $.ajax({
            type: "POST",
            url: url,
          data: '{yr:"' + yr + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessageDist,
            failure: function (response) {
                alert("Error");
            }
        });

          function OnSuccessageDist(response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
        
        dates2 = ResponeData;
       

    /* Bar chart */

    /* Chart data*/
    var chartdata =dates2[0];

  var options = {
          series: chartdata,
          chart: {
          type: 'bar',
           foreColor: chartTextColor,
          height: 350,
          stacked: true,
          stackType: '100%',
          toolbar : {
					show : false
				}
          
        },
        colors:['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
        plotOptions: {
          bar: {
            horizontal: true,
          },
        },
        stroke: {
          width: 1,
          colors: ['#fff']
        },
        title: {
          text: title,
           style: {
                    fontWeight:  'bold'
                  }
        },
        xaxis: {
          categories: dates2[1][0].cat,
          max: 100,
          tickAmount: 10,
        labels: {
            formatter: function (val) {
              return val + "%"
            }
          }
          },
        tooltip: {
          y: {
            formatter: function (val) {
              return val + "M"
            }
          }
        },
        fill: {
          opacity: 1
        
        },
        legend: {
          position: 'bottom',
          horizontalAlign: 'left',
          offsetX: 40
        }
        };
       
        var chart = new ApexCharts(document.querySelector("#"+id), options);
        chart.render().then(() => {
    window.setTimeout(function() {
        chart.dataURI().then((uri) => {
       var eachElement = {};
        eachElement.title= Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
        })
    }, 1000) 
});
   }
   }

   function getPie(url,id,title,no,cnvno) {

          $.ajax({
              type: "POST",
              url: url,
              data: '{yr:"' + yr + '"}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {
                  //res = response;
                  // var ResponeData1 = JSON.stringify(response.d);
                  var ResponeData = JSON.parse(response.d);

                  dates = ResponeData;


                  var chart = document.getElementById(id);
                  var barChart = echarts.init(chart);

                  barChart.setOption({
                     tooltip: {
                          trigger: 'item',
                          formatter: function (item) {
                              return item.seriesName + ' <br/>' + item.name +
                            ' : ' + item.value + ' (' + (item.percent).toFixed(1) + '%)';
                          }
                      },


                      calculable: !0,
                      series: [{
                          name: title,
                          type: "pie",
                          radius: "55%",
                          center: ["50%", "48%"],
                         label: {
                              normal: {
                                  formatter: function (item) {
                                      return item.name +
                            ' : ' + item.value + ' (' + (item.percent).toFixed(1) + '%)';

                                  },

                                  position: 'outside'
                              }
                          },
                          labelLine: {
                              show: true
                          },

                          data: dates
                      }],
                 
                      color: ['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071']
                  });

                   window.setTimeout(function() {
                       var uri = ($('canvas')[cnvno]).toDataURL("image/png");
       var eachElement = {};
        eachElement.title= Number(no);
        eachElement.url = uri;
            dataur.push(eachElement);
       
    }, 1000)
              },
              failure: function (response) {
                  alert("Error");
              }
          });

      }
     function splPrint(divName) {
          window.print();
        }



</script>
<script>
    $(document).ready(function () {
        $('#Report').addClass('active');
    });
</script>



</asp:Content>


