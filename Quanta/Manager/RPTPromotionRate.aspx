<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTPromotionRate.aspx.cs" Inherits="Quanta.Manager.RPTPromotionRate" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->
   <script src="/assets/bundles/chartjs/chart.min.js"></script>
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
 <style>
 
 canvas{
 
  height:400px;
}
 </style>
  
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Age Spread</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Age Spread</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Overall average age of the company</h4>
                  </div>
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
            
</div>
</section>
</div>
<script type="text/javascript">
   
    var dataHC = []
    var i=0;
    
     var chartTextColor= '#96a2b4';
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: "RPTPromotionRate.aspx/GetYearwise",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert("Error");
            }
        });
    });
    var res = "";
    function OnSuccess(response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
        
        dataHC = ResponeData;
         chart1();

   
}
   

   
    function chart1(){

	 var options = {
	          series: [{
                name:'Average Age',
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
	        colors: ['#fcbe06','#FA4BBD','#6CCBF8'],
	        plotOptions: {
	          bar: {
	            horizontal: false,
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
	        };

        var chart = new ApexCharts(
            document.querySelector("#chart1"),
            options
        );

        chart.render();
    
    }

</script>

<script>
    $(document).ready(function () {
        $('#RPTPromotionRate').addClass('active');
    });
</script>


</asp:Content>


