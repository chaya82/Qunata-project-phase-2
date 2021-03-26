<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPTReadRpt.aspx.cs" Inherits="Quanta.Manager.RPTReadRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="main-content" >
        <section class="section">
          <div class="section-header">
            <h1>How to Read this Report</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">How to Read this Report</div>
            </div>
          </div>
          <div class="section-body">
            <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12">
              <div class="card">
                 
                  <div class="card-body">
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12" style="text-align: justify; padding: 1em 1em 10em 1em; ">
                  Congratulations! Your report is ready. It is divided into different sections, providing analysis & commentary on different parameters and aspects of organization productivity, such as headcount distribution, wage bill spread, gender diversity, etc.<br /><br />

You may access each section from the ‘Reports’ panel on the left, and download the entire report for offline access from the ‘Download PDF Report’ section in the end.<br /><br />

In case of any queries or clarifications on the report, please write to <a href="mailto:quanta@inqsights.com" class="link-blue">quanta@inqsights.com</a>. <br /><br />

To continue, please click ‘Next’ below.

                  </div>
                  </div>
                  
                  </div>
                  </div>
                 
              </div>
              </div>
              <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center ">
                  <a href="RPTHeadCount.aspx" class="btn btn-warning" style="color:#fff">Next
                 </a>
                  </div>
                  </div>
          </div>
          </section>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        document.getElementById("ulrpt").style.display="block";
      
        $("RPTReadRpt").addClass('active');
    }
 );
    function liactive(id) {
        document.getElementById("rptlnk").click();
        $(id).siblings().removeClass('active');
        $(id).addClass('active');
    }
      </script>
</asp:Content>
