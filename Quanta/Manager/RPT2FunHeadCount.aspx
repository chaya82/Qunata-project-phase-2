<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPT2FunHeadCount.aspx.cs" Inherits="Quanta.Manager.RPT2FunHeadCount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->

 

  
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Revenue per employee</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Revenue per employee</div>
            </div>
          </div>
          <div class="section-body" id="content">
<div class="row">
              <div class="col-lg-7 col-md-7 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Revenue per employee</h4>
                    <br />
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <%--   <asp:GridView ID="grdList" runat="server"></asp:GridView>--%>
                     <asp:Repeater ID="grdList"  runat="server">
                     <ItemTemplate>
                     <table class="table table-striped" style="width:100%">
                     <thead>
                     <tr>
                     <th style="width:33%">
                     Category A
                     </th>
                     <th style="width:33%">
                     Category B
                     </th>
                     <th style="width:33%">
                     Category C
                     </th>
                     </tr>
                     </thead>
                     <tbody>
                     <tr>
                     <td style="width:33%; vertical-align: baseline;">  <span>  <%#Eval("[Category A]") %></span></td>
                        <td style="width:33%; vertical-align: baseline;">  <span>  <%#Eval("[Category B]") %></span></td>
                           <td style="width:33%; vertical-align: baseline;">  <span>  <%#Eval("[Category C]") %></span></td>
                     </tr>
                     </tbody>
                     </table>
                 
                     </ItemTemplate>
                     </asp:Repeater>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-5 col-md-5 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
              sample sample sample sample sample sample sample sample sample.<br /><br />

  sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample  <br /><br />

  sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample
     </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            
         

</div>
</section>
</div>

</asp:Content>


