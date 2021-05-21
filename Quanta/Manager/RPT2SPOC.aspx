<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPT2SPOC.aspx.cs" Inherits="Quanta.Manager.RPT2SPOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->
  
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1> SPOC</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item"> SPOC</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Overall Gender Mix of the Company</h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                      <div id="chartorg" ></div>
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
            
</div>
</section>
</div>
<script type="text/javascript">
   
   
    
     var chartTextColor= '#96a2b4';
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: "RPT2SPOC.aspx/GetSPOCData",
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
     var dataorg = []
    function OnSuccess(response) {
        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
       var ResponeData = JSON.parse(response.d);
        
        dataorg = ResponeData;
        var ResponeData = JSON.parse(response.d);
        
     
       

    /* Bar chart */

    /* Chart data*/
    var chartdata =dataorg[0];

     var options = {
          series: chartdata,
           chart: {
	          type: 'bar',
              foreColor: chartTextColor,
	          height: 350,
	          toolbar : {
					show : false
				}
	        },
	        colors: ['#F68112','#1363A9'],
	        plotOptions: {
	          bar: {
	            horizontal: false,
               
	            dataLabels: {
	              position: 'top'
	            }
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
	          categories:dataorg[1][0].cat,
	        },
	        };

        var chart = new ApexCharts(document.querySelector("#chartorg"), options);
        chart.render();
       
        
   
}
   

  

</script>

<script>
   
</script>


</asp:Content>


