<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPrint.aspx.cs" Inherits="Quanta.Manager.ReportPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"/>
   
  

  
 
 
 <style>
   body {
  background: rgb(204,204,204); 
}
page {
  position: relative;
  background: white;
  display: block;
  margin: 0 auto;
  margin-bottom: 0.5cm;
  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);
}
page[size="A4"] {  
  width: 21cm;
  height: 40cm; 
}


@media print {
  body, page {
    margin: 0;
    box-shadow: 0;
    background:#fff;
  }
 
}


    </style>
    <style>
 
 canvas{
 
  height:400px;
}
 #chart1_1 {
  width: 100%;
  height: 400px;
}
 </style>
     <!-- JS Libraies -->
     <script src="/assets/js/app.min.js"></script>
   <script src="/assets/bundles/chartjs/chart.min.js"></script>
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
  
   
     <a  href="#" onclick="javascript:window.print();" style="padding: 0 4em;">Print/Save as PDF</a>
    
     <page size="A4">
   
   
     <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span>
    <span style="text-align:right"><h4 style="float:right; color: #fff;">Report Date: <asp:Label ID="lblday" runat="server"></asp:Label>/ <asp:Label ID="lblmnth" runat="server"></asp:Label>/ <asp:Label ID="lblyear" runat="server"></asp:Label></h4></span></div>
    <div class="container">
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: center;
    font-size: 60px;
    font-weight: bold;
    text-transform: capitalize; height: 3em;
    padding: 1.3em 0;">Quanta Analysis Report</div></div>
    
    <div class="row" style="padding:2em 0;">
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" >
    <img src="../assets/img/graphical.png" width="100%" />
    </div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" style="background:#fd6e15; ">
    <h1 style="color: #fff; padding: 20px;">Contents:</h1>
    <h4 style="color: #fff; padding: 1em 1em;"> &bull; inQsights <sup>Op</sup> Quanta</h4>
    <h4 style="color: #fff; padding: 1em 1em;"> &bull; How to read this report</h4>
    <h4 style="color: #fff; padding: 1em 1em;"> &bull; Quanta Analysis</h4>
    <h4 style="color: #fff; padding: 1em 1em;"> &bull; Next Steps</h4>
    <h4 style="color: #fff; padding: 1em 1em;"> &bull; About inQsights &amp; Inqubex</h4>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <h1>inQsights <sup>Op</sup> Quanta</h1>
    <h5 style="padding: 2em 0;">Quanta is a self-service tool that helps visualize &amp; synthesize high impact people analytics, covering the following areas:</h5></div>
    </div>
    <div class="row">
    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
    <div style="background: #474c51;
    padding: 2em;
    border-radius: 1em;
    text-align: center;
    color: #fff;">
    <h5 class="normal">Demographic Diversity</h5>
    <img src="../images/demographic.png" title="Icon" style="width: 100px;" alt="Icon">
    </div></div>
    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
    <div style="background: #474c51;
    padding: 2em;
    border-radius: 1em;
    text-align: center;
    color: #fff;"><h5 class="normal">Structure Efficiency</h5>
    <img src="../images/structure.png" title="Icon" style="width: 100px;" alt="Icon">
    </div>
    </div>
    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
    <div style="background: #474c51;
    padding: 2em;
    border-radius: 1em;
    text-align: center;
    color: #fff;"><h5 class="normal">Wage Productivity</h5><br />
    <img src="../images/wage.png" title="Icon" style="width: 100px;" alt="Icon">
    </div></div>
    </div>
    </div>
  
      </page>
     
<page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container">
    <div class="row" style="padding: 4em 4em 52em 4em; ">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <h1>How to read this report</h1>
    <h5 style="padding: 2em 0; line-height:40px;">This report contains the analysis and visualization of the data uploaded to the Quanta
tool, with summary commentary on each section/ exhibit. This report provides a
multi-perspective visualization of the organization’s employee base, and is a useful
starting point for conversations around strategic manpower planning, organization
productivity, etc.</h5></div>
    </div>
    </div>
    
 </page>



     
   <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span>
    <span style="text-align:right"><h4 style="float:right; color: #fff;">Quanta Analysis Report</h4></span></div>
    <div class="container">
     <%--chart1--%><br /><h1>Quanta Analysis</h1><br />
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
    </div>
    
 </page>
         
    <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
                 
                         
                     <div id='chart2_dept'></div>
                 
                 </div>
                       </div> 
                   
                    </div>
                     </div>
                </div>
     
 
            </div>
               </div>
               </div>    
   </div>
    
 </page>
         
     <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
    
 </page>
 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
            </div>
            </div>
               <%--chart3--%>
          
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
                 </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div> 
            
 </div>
   
 </page>
 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
    
 </page>
 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>

 
               </div>
               </div>
 </div>
    
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
    <div class="card">
                   <div class="card-body">
                 
                 <div id='chart4_level_stack'></div>
                  </div>
                 </div>
 </div>
   
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
     <%--chart5--%>
                  <div class="card">
                 <div class="card-header">
                    <h4>Pyramid</h4>
                  </div>
                 <div class="card-body">
            <div class="row">
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card">
                  <div class="card-header">
                    <h6>Population Distribution by Grade of the Company </h6>
                  </div>
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
 </div>
   
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
               </div>
               </div>
               
<div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                
                  <div class="card-body">
              <ul class="nav nav-pills"  role="tablist">
                      <li class="nav-item" >
                        <a class="nav-link active" id="A1" data-toggle="tab" href="#uploaded-chart4"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart6"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="Div1">     
                               <div class="tab-pane fade active show" id="Div2" role="tabpanel" aria-labelledby="uploaded-data">
                 
             <div class="card">
                   <div class="card-body">
                    <div id="chart6_dept" ></div>
                  </div>
                 </div>
                       </div>
                       </div> 
                   
                    </div>
                     </div>
                    
               
                
                </div>
           
              
            </div>

 
 </div>
    
 </page>
 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
    <div class="card">
                   <div class="card-body">
                 
                 <div id='chart6_level'></div>
                  </div>
                 </div>
 </div>
    
 </page>


 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
                    <asp:HiddenField ID="lblcur" runat="server" ClientIDMode="Static" ></asp:HiddenField>
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
                        <a class="nav-link active" id="A2" data-toggle="tab" href="#uploaded-chart4"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart7"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="Div3">     
                               <div class="tab-pane fade active show" id="Div4" role="tabpanel" aria-labelledby="uploaded-data">
                 <div class="card">
                   <div class="card-body">
                    <div id="chart7_dept" ></div>
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

 </div>
    
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
    <div class="card">
                   <div class="card-body">
                 
                 <div id='chart7_level'></div>
                  </div>
                 </div>
 </div>
    
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
                        <a class="nav-link active" id="A3" data-toggle="tab" href="#uploaded-chart4"  role="tab" aria-controls="home" aria-selected="true">
                       <asp:Label ID="lblchart8"  runat="server"></asp:Label>
                        </a>
                      </li>
                      </ul>        
                          <div class="tab-content" id="Div5">     
                               <div class="tab-pane fade active show" id="Div6" role="tabpanel" aria-labelledby="uploaded-data">
                 <div class="card">
                   <div class="card-body">
                    <div id="chart8_dept_stack" ></div>
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
 </div>
    
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
    <div class="card">
                   <div class="card-body">
                 
                 <div id='chart8_level_stack'></div>
                  </div>
                 </div>
 </div>
   
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container"> <br />
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
             
            </div>  
            </div>
            </div>
 </div>
    
 </page>

 <page size="A4">
       
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container">
    <div class="row" style="padding: 3em 3em 0 3em">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <h1>Next Steps</h1>
    <h5 >This report is designed to serve as a starting point for dialogue around strategic manpower
planning, organization productivity, managerial effectiveness, and more. The following are
some questions/ areas that this report helps explore:
    </h5></div>
    </div>
    
    <div class="row" style="padding: 0 4em; ">
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Head Count</h4>
<p >Trend across years
Distribution across departments &amp;
levels</p>
<p ><em>"Are there any pockets of over/ under-
staffing?"</em></p></div>
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Tenure Spread</h4>
<p >Average tenure &amp; distribution across
the organization/ departments/ levels</p>
<p ><em>"Is the experience base in different
teams aligned to their responsibilities/
challenges?"</em></p></div>
  
    </div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Age Spread</h4>
<p >Average age &amp; distribution across the
organization/ departments/ levels</p>
<p ><em>"Are there pockets at risk (too close to
retirement/ too young for
responsibilities/ etc.)?"</em></p></div>
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Diversity</h4>
<p >Gender mix across the years (org
wide/ across departments/ levels)</p>
<p ><em>"Are there any D&amp;I blindspots in the
organization?"</em></p></div>
    
    </div>
   
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
    
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Span of Control</h4>
<p >Average managerial span of control trend Average spans across departments &amp; levels</p>
<p ><em>"Are there any pockets of managerial under-utilization/ overstretch?"</em></p></div>
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Performance Spread</h4>
<p >Performance distribution trend Distribution across departments &amp; levels</p>
<p ><em>"Are there any skews in performance ratings in a department/ level?"</em></p></div>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
    
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Total Fixed Pay (TFP)</h4>
<p >Total Fixed Pay (TFP) Organization-wide TFP trend TFP distribution across departments &amp; levels</p>
<p ><em>"Are there any pockets with disproportionately high/ low TFP?"</em></p></div>
    <div style="padding: 1em;
    background: #f1f1f1;
    border-radius: 1em; height:13em; margin: 1em 0;"><h4>Attrition</h4>
<p >Attrition trend across the years</p>
<p ><em>"Are there any spikes attrition that merit further investigation?"</em></p></div>
    </div>
    <h5 style="line-height:30px">For more advanced insights, you can upgrade to Quanta Pro which provides a more detailed
report with cross-parametric analysis to help achieve greater impact. You can access the
sample report <a href="#">here</a>.</h5>
    </div>
    </div>
   
 </page>
     <page size="A4">
    <div class="container" style="background:#fd6e15; width:100%; padding: 1em;"><span><img src="../assets/img/inqsights.png" /></span></div>
    <div class="container">
    <div class="row" style="padding: 4em 4em 0em 4em; ">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <h1>About inQsights</h1>
    <h5 style="padding: 2em 0; line-height:40px;">inQsights was started with the fundamental belief that Human Resource Management
functions needed to become more measurable &amp; data-driven. We felt decision-making around
people &amp; organization management would benefit from easier access to analytics around
team performance, productivity, capability &amp; motivation.</h5>
<h5 style="padding: 0 0 2em 0; line-height:40px;">inQsights serves as a modular, easy to deploy suite of applications, which help provide insight
on some core dimensions of an organization’s people management and information needs.</h5>
</div>
    </div>
    <div class="row" style="padding: 0 4em; ">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><img src="../images/inQsights offerings.png" style="width:100%" /></div>
    </div>
    
    <div class="row" style="padding: 4em 4em 0em 4em; ">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <h1>About Inqubex Consulting</h1>
    <h5 style="padding: 2em 0; line-height:40px;">The roots for inQsights lie with its parent, Inqubex Consulting and its extensive work since
2009, providing sage HR consulting advice to corporates across India, the Middle East and
South East Asia.</h5>
<h5 style="padding: 0 0 2em 0 ; line-height:40px;">For more information, please visit <a href="http://www.inqubex.com">www.inqubex.com</a> or write to <a href="mailto:contactus@inqubex.com">contactus@inqubex.com</a>.</h5>
    </div>
    </div>
    </div> 
      
   </page>


    </form>
    

<script type="text/javascript">
   
  var dataur=[];
    var i=0;
     var yr=document.getElementById("lblchart2").innerHTML;
      var comptxt=document.getElementById("lblcur").value;
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

       chart("RPTTFP.aspx/GetYearwise","chart7",'Total Fixed Pay','Overall Total Fixed Pay ('+comptxt+' millions)',7);
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

        chart.render();
   
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
          enabled: true,
            style: {
      fontSize: '8px'
     
  },
          formatter: function(val, opt) {
         
                
      return val.toFixed(1) + '%'
         
      
  }
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

         var chart = new ApexCharts(
            document.querySelector("#"+id),
            options
        );

        chart.render();
   
        
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
            horizontal: true,
           dataLabels: {
      position: 'top'
    }
         
        
          },

        },
        dataLabels: {
          enabled: true,
          offsetX:30,
           style: {
      fontSize: '8px',  colors: ['#333']
     
  },
   formatter: function(val, opt) {
         
      if(val>0)
      {          
      return val
      }
      else{
     return ''
      }
         
      
  }

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
          text: '',
          
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

            var chart = new ApexCharts(
            document.querySelector("#"+id),
            options
        );

        chart.render();
   
        
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

        chart.render();
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

        chart.render();
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

        chart.render();
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
       
            var chart = new ApexCharts(
            document.querySelector("#"+id),
            options
        );

        chart.render();
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
</body>
</html>
