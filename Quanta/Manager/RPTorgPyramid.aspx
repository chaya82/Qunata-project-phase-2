<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTorgPyramid.aspx.cs" Inherits="Quanta.Manager.RPTorgPyramid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->

 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
  <style>
  
 yaxis: {
  tickLength: 10,
  tickColor: '#fff'
}

  </style>
  
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Organizational Pyramid</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Organizational Pyramid</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Organizational Pyramid
</h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                      <div id="chart" ></div>
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
</section>
</div>
<script type="text/javascript">
   
    var dataHC = []
    
     var chartTextColor= '#96a2b4';
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: "RPTorgPyramid.aspx/GetLeveWise",
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
        dataLabels: {
  enabled: false,
  enabledOnSeries: [1]
},
        plotOptions: {
          bar: {
            horizontal: true
           
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
         enabled: true,
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
          text: ''
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

        var chart = new ApexCharts(document.querySelector("#chart"), options);
        chart.render();
    
    }

</script>

<script>
    $(document).ready(function () {
        document.getElementById("ulrpt").style.display = "block";
        $('#RPTorgPyramid').addClass('active');
    });
</script>


</asp:Content>


