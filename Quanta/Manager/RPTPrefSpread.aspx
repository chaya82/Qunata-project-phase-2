<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTPrefSpread.aspx.cs" Inherits="Quanta.Manager.RPTPrefSpread" %>
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
      function getdeptrec(id, yr) {

          $.ajax({
              type: "POST",
              url: "RPTPrefSpread.aspx/GetGenderDistrByFyear",
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
                          name: "Performance Spread ",
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
              },
              failure: function (response) {
                  alert("Error");
              }
          });

      }


  
</script>
  <script>
     
       
        
    var dates3 = [];
    var dates2 = []
   
   function chartdeptgenderdist(yr,id)
   {
    
    $.ajax({
            type: "POST",
            url: "RPTPrefSpread.aspx/GetGenderDistdeptWise",
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
         colors:['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
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
      return percent.toFixed(1) + '%'
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


   
   
   function chartLevelgenderdist(yr,id)
   {
    
    $.ajax({
            type: "POST",
            url: "RPTPrefSpread.aspx/GetgenderDistLevelWise",
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
          colors: ['#F68112','#1363A9','#D25057','#AF7763','#7E87C1','#C52027','#084E77','#FFCF6B','#E74D69','#10A8AB','#51C357','#02BB91','#F68E2E','#FBB150','#a39700','#006f35','#a66400','#257c17','#a54b00','#017071'],
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
        };

        var chart = new ApexCharts(document.querySelector("#"+id), options);
        chart.render();
   }
   }
</script>
<style>
  
  #echart_pie {
  width: 100%;
  height: 350px;
}


  </style>
  
  <script>
     
      function chartpie(yr,id) {
          var dates = []
          $.ajax({
              type: "POST",
              url: "RPTPrefSpread.aspx/GetGenderDistrByFyear",
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
                  alert(chart);
                  barChart.setOption({
                      tooltip: {
                          trigger: "item",
                          formatter: "{a} <br/>{b} : {c} ({d}%)"
                      },


                      calculable: !0,
                      series: [{
                          name: "Department",
                          type: "pie",
                          radius: "55%",
                          center: ["50%", "48%"],
                          label: {
                              normal: {
                                  formatter: '{b} : {c} ({d}%)',
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
              },
              failure: function (response) {
                  alert("Error");
              }
          });

      }


  
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Performance Spread</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Performance Spread</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Overall Performance Spread of the Company</h4>
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
             
                             
                              <ul class="nav nav-pills" id="Ul1" role="tablist">
                           <asp:Repeater ID="rptlistyr" runat="server" >
                          
                        <ItemTemplate>
                      <li class="nav-item" id='li<%#Eval("fyear") %>'>
                        <a class="nav-link " id="uploaded-data<%#Eval("fyear") %>" data-toggle="tab" href="#uploaded<%#Eval("fyear") %>" onclick="javascript:getdeptrec('echart_pie', '<%#Eval("fyear") %>');"   role="tab" aria-controls="home" aria-selected="true"><%#Eval("fyear") %></a>
                      </li>
                        
                  
                      </ItemTemplate>
                      </asp:Repeater>
               
                    
                    </ul>
                    <div class="tab-content" id="myTabContent2">
                  <div class="card">
                  <div class="card-header">
                    <h4>Organization-Wide Performance Spread
</h4>
                  </div>
                   <div class="card-body">
                        <div id='echart_pie' ></div>
                  </div>
                 </div>
                   
                        <asp:Repeater ID="rptlistyr1" runat="server" >
                          
                        <ItemTemplate>
                      <div class="tab-pane fade" id="uploaded<%#Eval("fyear") %>" role="tabpanel" aria-labelledby="uploaded-data">
                         
                 <div class="card">
                  <div class="card-header">
                    <h4>Performance Distribution by Department

</h4>
                  </div>
                   <div class="card-body">
                    <div id='chartdept<%#Eval("fyear") %>'></div>
                  </div>
                 </div>
                 <div class="card">
                  <div class="card-header">
                    <h4>Performance Distribution by Level

</h4>
                  </div>
                   <div class="card-body">
                 


                 <div id='chartlevel<%#Eval("fyear") %>'></div>
                  </div>
                 </div>

                 
                      </div>
                       <script>

                           
                           chartdeptgenderdist('<%#Eval("fyear") %>', 'chartdept<%#Eval("fyear") %>');
                           chartLevelgenderdist('<%#Eval("fyear") %>', 'chartlevel<%#Eval("fyear") %>');
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
   
   
    
     var chartTextColor= '#96a2b4';
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: "RPTPrefSpread.aspx/GetgenderDistOrgWise",
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
           foreColor: '#fff',
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
          categories: dataorg[1][0].cat,
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

        var chart = new ApexCharts(document.querySelector("#chartorg"), options);
        chart.render();
         var id="uploaded-data"+ dataorg[1][0].cat[dataorg[1][0].cat.length-1];
         document.getElementById(id).click();
   
}
   

  

</script>


<script>
    $(document).ready(function () {
        document.getElementById("ulrpt").style.display = "block";
        $('#RPTPrefSpread').addClass('active');
    });
</script>

</asp:Content>


