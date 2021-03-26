<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTHeadCount.aspx.cs" Inherits="Quanta.Manager.RPTHeadCount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->

 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
  <style>
  
  #echart_pie {
  width: 100%;
  height: 400px;
}


  </style>
  
  <script>
      var dates = []
      var dataur=[];
      function getdeptrec(id, yr) {

          $.ajax({
              type: "POST",
              url: "RPTHeadCount.aspx/GetHC_deptWise",
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
                          name: "Department",
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
                       var uri = ($('canvas')[0]).toDataURL("image/png");
       var eachElement = {};
        eachElement.title= Number(1);
        eachElement.url = uri;
            dataur.push(eachElement);
       
    }, 1000)
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
            <h1>Head Count</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Head Count</div>
            </div>
          </div>
          <div class="section-body" id="content">
<div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Head Count</h4>
                    
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
                  
               The headcount is simply the number of people employed by a business at a given time.<br /><br />

Organization level: The attached graph shows the trend (If multi-year data has been provided) of change in Organization Level Headcount.  <br /><br />

Headcount by Function/ Department: The graph show the current spread of headcount across different departments. The % indicates the Department Headcount as a % of Total Headcount and can help you spot any pockets of over/ under staffing
     </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-12 col-md-12 col-lg-12">
                <div class="card">
                  <div class="card-header">
                    <h4>Headcount Distribution by Department
</h4>
                  </div>
                  <div class="card-body">
              
               
                    
                     
                              <ul class="nav nav-pills" id="Ul1" role="tablist">
                           <asp:Repeater ID="rptlistyr" runat="server" >
                          
                        <ItemTemplate>
                      <li class="nav-item" id='li<%#Eval("fyear") %>'>
                        <a class="nav-link " id="uploaded-data<%#Eval("fyear") %>" data-toggle="tab" href="#uploaded" onclick="javascript:getdeptrec('echart_pie', '<%#Eval("fyear") %>');" role="tab" aria-controls="home" aria-selected="true"><%#Eval("fyear") %></a>
                      </li>
                        
                  
                      </ItemTemplate>
                      </asp:Repeater>
               
                    
                    </ul>
                    <div class="tab-content" id="myTabContent2">
                      <div class="tab-pane fade show active" id="uploaded" role="tabpanel" aria-labelledby="uploaded-data">
                        
                     <div id='echart_pie' ></div>
                 
                      </div>
                      
                      
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
            url: "RPTHeadCount.aspx/GetHC_Yearwise",
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
              name: 'Head Count',
	          data: dataHC[0].value
	        }],
	          chart: {
	          type: 'bar',
	          height: 350,
              foreColor: chartTextColor,
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
	          }
	        },
	        stroke: {
	          show: false,
	          width: 1,
	          colors: ['#fff']
	        },
	        xaxis: {
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
        $('#RPTHeadCount').addClass('active');
    });
</script>

</asp:Content>


