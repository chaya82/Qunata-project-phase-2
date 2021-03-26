<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="Quanta.Manager.test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"/>
   
    <link rel='stylesheet' href='/assets/css/style.css?v=1.0' />
    <link rel='stylesheet' href='/assets/css/components.css' />

    <!-- JS Libraies -->
     <script src="/assets/js/app.min.js"></script>
   <script src="/assets/bundles/chartjs/chart.min.js"></script>
 <script src="/assets/bundles/apexcharts/apexcharts.min.js"></script>
 <script src="/assets/bundles/echart/echarts.js"></script>
  <script src="../assets/js/print.js"></script>
  
 
 
 <style>
   body {
  background: rgb(204,204,204); 
}
page {
  position: relative;
  background: white;
  display: block;
  margin: 0 auto;
  margin-bottom: 0.5cm;
  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);
}
page[size="A4"] {  
  width: 21cm;
  height: 29.7cm; 
}



header,
footer {
  position: absolute;
  left: 0;
  right: 0;
  background-color: #fd6e15;
  
}


header {
  top: 0;
  padding-top: 5mm;
  padding-bottom: 3mm;
}
footer {
  bottom: 0;
  color: #000;
  padding-top: 3mm;
  padding-bottom: 5mm;
}

@media print {
  body, page {
    margin: 0;
    box-shadow: 0;
  }
  header,
  footer {
    position: fixed;
    left: 0;
    right: 0;
    background-color: #fd6e15;

  }
}


    </style>
</head>
<body>
    <form id="form1" runat="server">
 
     <page size="A4">
    
   <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><img src="../assets/img/inqsights.png" /></div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><h4 style="float:right; color: #fff;">Report Date:__/__/__</h4></div>
    </div>
    
    
    
    
    

      </page>
   
    </form>
</body>
</html>
