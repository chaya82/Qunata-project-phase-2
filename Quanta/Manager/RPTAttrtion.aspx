<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTAttrtion.aspx.cs" Inherits="Quanta.Manager.RPTAttrtion" %>

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
            <h1>Attrition </h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Attrition </div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Overall Attrition of the Company</h4>
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
                  
              Indicates the % of employees who are leaving the organization each year.<br /><br />
Reflects on the ability of the organization to retain staff. A reducing trend in attrition is considered positive
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
            url: "RPTAttrtion.aspx/GetYearwise",
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
                name:'Average Attrition',
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
            
         yaxis: {
 

 
  labels: {
    formatter: (value) => value.toFixed(0) +'%',
  },
}
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
        document.getElementById("ulrpt").style.display = "block";
        $('#RPTAttrtion').addClass('active');
       
    });
</script>



</asp:Content>


