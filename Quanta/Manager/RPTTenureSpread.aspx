<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTTenureSpread.aspx.cs" Inherits="Quanta.Manager.RPTTenureSpread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->
   
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
 <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
 <style>
 
 canvas{
 
  height:400px;
}
 </style>
  
  <script>
       var dates = []
        var dates2 = []
         var dates3 = []
      
      function chartdept(yr,id){
     
       $.ajax({
              type: "POST",
              url: "RPTTenureSpread.aspx/GetdeptWise",
              data: '{yr:"' + yr + '"}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {

               var ResponeData = JSON.parse(response.d);
        
                dates = ResponeData;
                  var options = {
	          series: [{
              name:'Average Tenure',
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
    function chartGrade(yr,id){
     var datesGrade = []
       $.ajax({
              type: "POST",
              url: "RPTTenureSpread.aspx/GetgradeWise",
              data: '{yr:"' + yr + '"}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {
               var ResponeData = JSON.parse(response.d);
        
        datesGrade = ResponeData;
                  var options = {
	          series: [{
                 name:'Average Tenure',
	          data: datesGrade[0].value
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
                 columnWidth: '45%',
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
	          categories:datesGrade[0].label,
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

   
   function chartdeptagedist(yr,id)
   {
   
    $.ajax({
            type: "POST",
            url: "RPTTenureSpread.aspx/GetAgeDistdeptWise",
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
           foreColor: '#96a2b4',
          height: 350,
          stacked: true,
          stackType: '100%',
          toolbar : {
					show : false
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
           dataLabels: {
	          enabled: false
	          },
        xaxis: {
          categories: dates2[1][0].cat,
        },
         yaxis: {
 
  max: 100,
  tickAmount: 5,
  labels: {
    formatter: (value) => value.toFixed(0) +'%',
  },
},
        fill: {
          opacity: 1
        },
         tooltip: {
  y: {
    formatter: function(value, opts) {
      var percent = opts.w.globals.seriesPercent[opts.seriesIndex][opts.dataPointIndex];
      return percent.toFixed(2) + '%'
    }
  }
},
        legend: {
          position: 'right',
          offsetX: 0,
          offsetY: 50
        },
        };

        var chart = new ApexCharts(document.querySelector("#"+id), options);
        chart.render();
   }
   }


   
   
   function chartLevelagedist(yr,id)
   {
   
    $.ajax({
            type: "POST",
            url: "RPTTenureSpread.aspx/GetAgeDistLevelWise",
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
           foreColor: '#96a2b4',
          height: 350,
          stacked: true,
          stackType: '100%',
          toolbar : {
					show : false
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
         colors:['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
          dataLabels: {
	          enabled: false
	          },
        xaxis: {
          categories: dates3[1][0].cat,
        },
         yaxis: {
 
  max: 100,
  tickAmount: 5,
  labels: {
    formatter: (value) => value.toFixed(0) +'%',
  },
},
        fill: {
          opacity: 1
        },
       tooltip: {
  y: {
    formatter: function(value, opts) {
      var percent = opts.w.globals.seriesPercent[opts.seriesIndex][opts.dataPointIndex];
      return '</br>'+  value+ ' Headcount :'+ percent.toFixed(2) + '%'
    }
  }
},
        legend: {
          position: 'right',
          offsetX: 0,
          offsetY: 50
        },
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
            <h1>Tenure distribution </h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Tenure distribution </div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Overall Average Tenure of the Company</h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
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
                    <h4>Average Tenure by Department
</h4>
                  </div>
                  <div class="card-body">
                     <div id='echart_bardept<%#Eval("fyear") %>'></div>
                 </div>
                 </div>
                 <div class="card">
                  <div class="card-header">
                    <h4>Average Tenure by Level
</h4>
                  </div>
                  <div class="card-body">
                     <div id='echart_barlevel<%#Eval("fyear") %>' ></div>
                 </div>
                 </div>
                 <div class="card">
                  <div class="card-header">
                    <h4>Tenure Distribution by Department

</h4>
                  </div>
                   <div class="card-body">
                    <div id="echart_bar<%#Eval("fyear") %>" ></div>
                  </div>
                 </div>
                 <div class="card">
                  <div class="card-header">
                    <h4>Tenure Distribution by Level

</h4>
                  </div>
                   <div class="card-body">
                 


                 <div id='chart<%#Eval("fyear") %>'></div>
                  </div>
                 </div>
                      </div>
                      
                        


  <script>
      chartdept('<%#Eval("fyear") %>', 'echart_bardept<%#Eval("fyear") %>');
      chartGrade('<%#Eval("fyear") %>','echart_barlevel<%#Eval("fyear") %>' );
      chartdeptagedist('<%#Eval("fyear") %>','echart_bar<%#Eval("fyear") %>');
      chartLevelagedist('<%#Eval("fyear") %>','chart<%#Eval("fyear") %>');
     
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
            url: "RPTTenureSpread.aspx/GetYearwise",
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
                name:'Average Tenure',
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

$(function (e) {
});
</script>
<script>
    $(document).ready(function () {
        document.getElementById("ulrpt").style.display = "block";
        $('#RPTTenureSpread').addClass('active');
    });
</script>

</asp:Content>


