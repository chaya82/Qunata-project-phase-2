<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTSPOC.aspx.cs" Inherits="Quanta.Manager.RPTSPOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->
  
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
 <style>
 
 canvas{
 
  height:400px;
}
 </style>
  
  <script>
       var dates = []
       
     
    
    var dates2 = []
   function chartdeptdist(yr,id)
   {
   
    $.ajax({
            type: "POST",
            url: "RPTSPOC.aspx/GetDistdeptWise",
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
	              text: "",
	              style: {
	                color: '#fcbe06',
	              }
	            },
	            tooltip: {
	              enabled: true,

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


   
    var dates3 = [];
   function chartLeveldist(yr,id)
   {
   
    $.ajax({
            type: "POST",
            url: "RPTSPOC.aspx/GetDistLevelWise",
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
	          width:  4
	        },
              markers: {
          size: 0
          },
	        title: {
	          text: ''
	          
	        },
          
	        xaxis: {
	          categories:  dates3[1][0].cat,
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
	              text: " ",
	              style: {
	                color: '#fcbe06',
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
</script>

  
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Span of control</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Span of control</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-6 col-md-6 col-lg-6">
                <div class="card card-height-report"">
                  <div class="card-header">
                    <h4>Average Span of Control of the Company</h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
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
                         
                 <div class="card">
                  <div class="card-header">
                    <h4>Span of Control  by Department

</h4>
                  </div>
                   <div class="card-body">
                    <div id="chartdept<%#Eval("fyear") %>"></div>
                  </div>
                 </div>
                 <div class="card">
                  <div class="card-header">
                    <h4>Span of Control by Level

</h4>
                  </div>
                   <div class="card-body">
                  


                 <div id='chartlevel<%#Eval("fyear") %>'></div>
                  </div>
                 </div>
                      </div>
                      <script>

                          chartdeptdist('<%#Eval("fyear") %>','chartdept<%#Eval("fyear") %>');
                          chartLeveldist('<%#Eval("fyear") %>','chartlevel<%#Eval("fyear") %>');
                         
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
    
     var chartTextColor= '#96a2b4';
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: "RPTSPOC.aspx/GetOrgWise",
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
                name:'Average SPOC',
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
        $('#RPTSPOC').addClass('active');
    });
</script>


</asp:Content>


