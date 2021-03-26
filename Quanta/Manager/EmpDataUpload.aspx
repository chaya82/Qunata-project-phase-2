<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="EmpDataUpload.aspx.cs" Inherits="Quanta.Manager.EmpDataUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Data Entry (Instructions)</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Data Entry</div>
            </div>
          </div>
          <div class="section-body">
<div class="row">
                <div class="col-md-12">
                    <div class="card">
                       <div class="row">
                                <div class="col-md-12">   &nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                                </div>
                       <div class="well bs-component">
                                    <div class="form-horizontal">
                                   
                                    <div class="form-group">
                                            <div class="col-lg-6">
                                                Import Excel for Upload Step Database:<span style="color: Red">*</span><br />
                                               <asp:FileUpload ID="FileUpload1" runat="server" /> &nbsp </div>
                                                     <div class="col-lg-6"> <asp:Button ID="btnImport" CssClass="btn btn-primary"
                        runat="server"  Text="Upload" onclick="btnImport_Click" />
                        
                                            </div>
                                            </div>

                                              
                                            </div>
                                            </div>




        
    </div>
   
    </div>
    
    </div>
     <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12">
                  <span style="color:Red">*</span> Mandatory
                  </div>
                  </div>

                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center">
                  <a href="EmpDataUpload.aspx" class="btn btn-info">Continue</a>
                  </div>
                  </div>
</asp:Content>
