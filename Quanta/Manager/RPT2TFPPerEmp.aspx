<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPT2TFPPerEmp.aspx.cs" Inherits="Quanta.Manager.RPT2TFPPerEmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->

 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>

  
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>TFP/FTE</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">TFP/FTE</div>
            </div>
          </div>
          <div class="section-body" id="content">
<div class="row">
              <div class="col-lg-7 col-md-7 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>TFP/FTE</h4>
                    
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                      <div id="chart1" ></div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-5 col-md-5 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
              sample sample sample sample sample sample sample sample sample.<br /><br />

  sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample  <br /><br />

  sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample
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
    
     var chartTextColor= '#96A2B4';
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: "RPT2TFPPerEmp.aspx/Revenue_employee",
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
         //var id="uploaded-data"+dataHC[0].label[dataHC[0].label.length-1]
   //document.getElementById(id).click();
}
   

   
    function chart1(){

	 var options = {
	          series: [{
              name: 'TFP/FTE ',
	          data: dataHC[0].value
	        }],
	          chart: {
	        type: 'line',
	          height: 350,
             
              foreColor: chartTextColor,
	          toolbar : {
					show : false
				}
	        },

	        fill: {
          type: 'gradient',
          gradient: {
            shade: 'dark',
            gradientToColors: [ '#FDD835'],
            shadeIntensity: 1,
            type: 'horizontal',
            opacityFrom: 1,
            opacityTo: 1,
            stops: [0, 50, 100],
          },
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
	          width: 7,
          curve: 'smooth'
	        },
	        xaxis: {
	          categories:dataHC[0].label,
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
        document.getElementById("ulmanpower").style.display = "block";
        $('#rptRevenue').addClass('active');
    });
</script>

</asp:Content>


