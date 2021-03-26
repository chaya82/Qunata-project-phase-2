<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTTFP.aspx.cs" Inherits="Quanta.Manager.RPTTFP" %>

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
  
  <script>
      
      
       
    var dates2 = []  
    
   function chartdeptagedist(yr,id)
   {
    
    $.ajax({
            type: "POST",
            url: "RPTTFP.aspx/GetAgeDistdeptWise",
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
          }

        },
        dataLabels: {
          enabled: false,
           dropShadow: {
                enabled: true
              },
          textAnchor: 'start',
          offsetX: 0,
          offsetY: 0,
         formatter: (value) => value.toFixed(1) +'%',
        },
        stroke: {
          width: 1,
          colors: ['#fff']
        },
        title: {
          text: ''
        },
        xaxis: {
          categories: dates2[1][0].cat,
          max: 100,
          tickAmount: 20,
        labels: {
      
            formatter: function (val) {
              return val +'%'
            }
          }
          },
        tooltip: {
  y: {
    formatter: function(value, opts) {
      var percent = opts.w.globals.seriesPercent[opts.seriesIndex][opts.dataPointIndex];
      return  percent.toFixed(1) + '%'
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
        chart.render();
   }
   }


   
      var dates3 = []
   function chartLevelagedist(yr,id)
   {
  
    $.ajax({
            type: "POST",
            url: "RPTTFP.aspx/GetAgeDistLevelWise",
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
        
        dates3 = ResponeData;
       

    /* Bar chart */

    /* Chart data*/
    var chartdata =dates3[0];

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
              
               
                horizontal: true
               
              }
        },
           dataLabels: {
          enabled: false,
           dropShadow: {
                enabled: true
              },
          textAnchor: 'start',
          offsetX: 0,
          offsetY: 0,
         formatter: (value) => value.toFixed(1) +'%',
        },
        stroke: {
          width: 1,
          colors: ['#fff']
        },
        title: {
          text: ''
        },
        xaxis: {
          categories: dates3[1][0].cat,
          max: 100,
          tickAmount: 20,
        labels: {
            formatter: function (value) {
              return value+"%"
            }
          }
        },
         tooltip: {
  y: {
    formatter: function(value, opts) {
      var percent = opts.w.globals.seriesPercent[opts.seriesIndex][opts.dataPointIndex];
      return  percent.toFixed(1) + '%'
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
       
        chart.render();
        
        
        }
   }
   
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>  Total Fixed Pay</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">  Total Fixed Pay</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Overall Total Fixed Pay of the Company (<asp:Label ID="lblcur" runat="server"></asp:Label> millions)</h4>
                  </div>
                  <div class="card-body">
                    <div >
                      <div id="chart1" ></div>
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
             
                             
                              <ul class="nav nav-pills" id="Ul1" role="tablist">
                           <asp:Repeater ID="rptlistyr" runat="server" >
                          
                        <ItemTemplate>
                      <li class="nav-item" id='li<%#Eval("fyear") %>'>
                        <a class="nav-link " id="uploaded-data<%#Eval("fyear") %>" data-toggle="tab" href="#uploaded<%#Eval("fyear") %>"  role="tab" aria-controls="home" aria-selected="true"><%#Eval("fyear") %></a>
                      </li>
                        
                  
                      </ItemTemplate>
                      </asp:Repeater>
               
                    
                    </ul>
                    <div class="tab-content" id="myTabContent2">
                     <asp:Repeater ID="rptlistyr1" runat="server" >
                          
                        <ItemTemplate>
                      <div class="tab-pane fade" id="uploaded<%#Eval("fyear") %>" role="tabpanel" aria-labelledby="uploaded-data">
                        
                 <div class="card" >
                  <div class="card-header">
                    <h4>  Total Fixed Pay by Department

</h4>
                  </div>
                   <div class="card-body">
                    <div id="chartdept<%#Eval("fyear") %>" ></div>
                  </div>
                 </div>
                 <div class="card">
                  <div class="card-header">
            
                    <h4>  Total Fixed Pay by Level

</h4>
                  </div>
                   <div class="card-body">
                 


                 <div id='chartlevel<%#Eval("fyear") %>'></div>
                  </div>
                 </div>
                      </div>
                      <script>
                          chartdeptagedist('<%#Eval("fyear") %>', 'chartdept<%#Eval("fyear") %>');
                          chartLevelagedist('<%#Eval("fyear") %>', 'chartlevel<%#Eval("fyear") %>');
                      </script>
                       </ItemTemplate>
                      </asp:Repeater>
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
            url: "RPTTFP.aspx/GetYearwise",
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
  var id="uploaded-data"+dataHC[0].label[dataHC[0].label.length-1]
    document.getElementById(id).click();
   
}
   

   
    function chart1(){

	 var options = {
	          series: [{
                name:'Total Fixed Pay',
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
        $('#RPTTFP').addClass('active');
    });
</script>


</asp:Content>


