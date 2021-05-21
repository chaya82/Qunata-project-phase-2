<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPT2TFPCompa.aspx.cs" Inherits="Quanta.Manager.RPT2TFPCompa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->
  
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1> Gender Mix</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item"> Gender Mix</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
              <div class="col-lg-7 col-md-7 col-sm-12 col-sm-12">
                <div class="card " style="height:520px">
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
              <div class="col-lg-5 col-md-5 col-sm-12 col-sm-12" >
                <div class="card " style="height:520px">
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
   
   
     var dataorg = []
     var chartTextColor= '#96a2b4';
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: "RPT2TFPCompa.aspx/Getdata",
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
          height: 450,
          stacked: true,
          stackType: '100%',
          toolbar : {
					show : false
				}
        },
       
        plotOptions: {
          bar: {
            horizontal: true,
          },
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
        
          max:100,
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
          position: 'bottom',
          
        },
       
        };

        var chart = new ApexCharts(document.querySelector("#chartorg"), options);
        chart.render();
       
     
   
}
   

  

</script>

<script>
    $(document).ready(function () {
        document.getElementById("ulrpt").style.display = "block";
        $('#RPTGenderDist').addClass('active');
    });
</script>


</asp:Content>


