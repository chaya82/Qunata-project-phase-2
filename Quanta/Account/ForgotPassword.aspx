<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Site1.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Quanta.Account.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="app">
    <section class="section">
      <div class="container mt-3">
        <div class="row">
          <div class="col-12 col-sm-8 offset-sm-2 col-md-6 offset-md-3 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4">
            <div class="login-brand login-brand-color">
            	QUANTA
             
            </div>
            <div class="card" >
            <div class="card-header card-header-auth">
                <h4>Retrieve Password</h4>
              </div>
 <div class="card-body">

  <asp:Label id="Msg" runat="server" ForeColor="red" /><br />

  <asp:Textbox id="UsernameTextBox" Columns="30" runat="server" AutoPostBack="true" CssClass="form-control input-width" placeholder="Username" />
            <asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server" ControlToValidate="UsernameTextBox" ForeColor="red" Display="Static" ErrorMessage="Required" /><br />

  <asp:Button id="EmailPasswordButton" Text="Email My Password" CssClass="btn btn-lg btn-block btn-auth-color" OnClick="EmailPassword_OnClick" runat="server" />
              </div>

 </div>
           
          </div>
        </div>
      </div>
    </section>
  </div>



</asp:Content>
