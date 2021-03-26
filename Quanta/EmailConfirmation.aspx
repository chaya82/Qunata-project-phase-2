<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Site1.Master" AutoEventWireup="true" CodeBehind="EmailConfirmation.aspx.cs" Inherits="Quanta.EmailConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="app">
    <section class="section">
      <div class="container mt-3">
        <div class="row">
          <div class="col-12 col-sm-10 offset-sm-1 col-md-8 offset-md-2 col-lg-8 offset-lg-2 col-xl-8 offset-xl-2">
            <div class="login-brand login-brand-color">
            	QUANTA
             
            </div>
            <div class="card" style="text-align:center; padding:50px; color:#000">

 <h2><asp:Label ID="lblMessage" runat="server"></asp:Label></h2>

 </div>
 <asp:Login ID="LoginUser" runat="server" EnableViewState="false"  Visible="false"
    RenderOuterTable="false" onauthenticate="LoginUser_Authenticate" onloggingin="LoginUser_LoggingIn" 
                                            >
                                            </asp:Login>
           
          </div>
        </div>
      </div>
    </section>
  </div>
</asp:Content>
