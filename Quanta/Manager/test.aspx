<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Quanta.Manager.test" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <div class="card">
                 <asp:Chart ID="Chart1" runat="server" Height="340px" Palette="None" 
        Width="360px" BackColor="Transparent" BorderlineColor="Transparent" >  
         <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
            LegendStyle="Row" />
    </Legends>
        <Series>  
            <asp:Series Name="Series1"  YValuesPerPoint="12">  
            </asp:Series>  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" BackColor="Transparent" 
                BackImageTransparentColor="Transparent">  
            </asp:ChartArea>  
        </ChartAreas>  
    </asp:Chart>  


                </div>
                </div>
                </div>
          </div>
</section>
</div>
</asp:Content>
