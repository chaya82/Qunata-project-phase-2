<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginNew.aspx.cs" Inherits="Quanta.Account.LoginNew" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

  <meta charset="UTF-8">
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" name="viewport">
  <title>Quanta</title>
  <!-- General CSS Files -->
  <link rel="stylesheet" href="/assets/css/app.min.css">
  <link rel="stylesheet" href="/assets/bundles/bootstrap-social/bootstrap-social.css">
  <!-- Template CSS -->
  <link rel="stylesheet" href="/assets/css/style.css">
  <link rel="stylesheet" href="/assets/css/components.css">
  <!-- Custom style CSS -->
  
  <link rel='shortcut icon' type='image/x-icon' href='/assets/img/favicon.ico' />
<style>
.dark{background: linear-gradient(to bottom, rgba(0,0,0,0.7) 0%, rgba(0,0,0,0.7) 100%),url(/assets/img/auth-background-image.jpg);}.dark .card{border:0;background-color:#11151e;color:#96a2b4}
.card {
    background-color: #fff !important;
    }
.form-control, .input-group-text, .custom-select, .custom-file-label {
    background-color: #fdfdff !important;}
.dark .card .card-header {
    border-bottom-color: #fff!important;
}
.dark .form-group>label {
    color: #34395e;
}
.text-muted {
    color: #6c757d !important;
}
.theme-coral a {
    color: #0091EA;
}
.header-tab-menu {
    margin-bottom: 20px;
}
.header-tab-menu .nav-tabs li {
    background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
    border-color: rgba(0, 0, 0, 0);
    cursor: pointer;
    display: inline-block;
    float: left;
    margin: 0 20px 0 0;
    padding: 0;
    text-transform: uppercase;
    -webkit-transition: all 300ms ease 0s;
    transition: all 300ms ease 0s;
}

.header-tab-menu .nav-tabs li a {
    background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
    border: 1px solid rgba(0, 0, 0, 0);
    color: #444;
    font-size: 20px;
    font-weight: 500;
    margin: 0;
    padding: 0 0 6px;
    text-transform: capitalize;
}
.header-tab-menu .nav-tabs li a.active {
    color: #0091EA;
    border-bottom:solid 2px #0091EA;
}
.nav-tabs {
    border-bottom: none;
}
.form-group{
  position: relative;
  }
  .palceholder{
   position: absolute;
   top: 7px;
   left: 8px;
    color: #B1B1B1;
    display: none;
  }
  label{
   font-wight: normal;
    color: #B1B1B1;
    margin-left: 20px;
  } 
  .star{
    color: red
  }


</style>
</head>
<body>
    <form  runat="server">
   <div class="loader"></div>
  <div id="app">
    <section class="section">
      <div class="container mt-3">
        <div class="row">
          <div class="col-12 col-sm-10 offset-sm-1 col-md-8 offset-md-2 col-lg-8 offset-lg-2 col-xl-8 offset-xl-2">
            <div class="login-brand login-brand-color">
            	QUANTA
             
            </div>
            <div class="card">
             

              <div class="modal-body">
                            <div class="header-tab-menu">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a href="#login" aria-controls="login" class="active" role="tab" data-toggle="tab">Sign In</a></li>
                                    <li ><a href="#register" aria-controls="register" role="tab" data-toggle="tab">Create Account</a></li>
                                </ul>
                            </div>
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="login"> 
                                    <div class="login-form-container col-12 col-sm-10 offset-sm-1 col-md-8 offset-md-2 col-lg-8 offset-lg-2 col-xl-8 offset-xl-2">
                                     
                                            <input  type="email" class="form-control mb-10" placeholder="Email/Phone" name="email" tabindex="1"   />
                                            <div class="d-block">
                      
                      <div class="float-right">
                        <a href="forgot-password.html" class="text-small">
                          Forgot Password?
                        </a>
                      </div>
                    </div>
                                            <input id="password" type="password" placeholder="Password" class="form-control" name="password" tabindex="2"  />
                                            
                                            <div class="button-box">
                                                <div class="custom-control custom-checkbox">
                      <input type="checkbox" name="remember" class="custom-control-input" tabindex="3" id="remember-me"  />
                      <label class="custom-control-label form-group" for="remember-me">Remember Me</label>
                    </div>
                                                <button type="submit" class="btn btn-lg btn-block btn-auth-color">Login</button>
                                            </div>
                                        
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane" id="register"> 
                                    <div class="register-form">
                                        <span>Please enter your account details.</span>
                                             <div class="row">
                    <div class="form-group name-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
                    <div class="palceholder">
             <label for="name">Name</label>
            <span class="star">*</span>
          </div>
             <asp:TextBox ID="Name" runat="server" CssClass="form-control" autofocus ></asp:TextBox>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Visible="false" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Name is required." ToolTip="Name is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                   
                    </div>
                    <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                     <div class="palceholder">
          <label for="Designation">Designation</label>
            <span class="star">*</span>
          </div>
                        <asp:TextBox ID="Designation" runat="server" CssClass="form-control" ></asp:TextBox>
                               
                                <asp:RequiredFieldValidator ID="DesignationRequired" runat="server" ControlToValidate="Designation"  CssClass="failureNotification" 
                                     ErrorMessage="Designation is required." ToolTip="Designation is required." Display="Dynamic"  ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </div>
                  </div>
			<div class="row">
                    <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                      <div class="palceholder">
        <label for="Email">Email</label>
            <span class="star">*</span>
          </div>
                  <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"  CssClass="failureNotification" 
                                      ErrorMessage="E-mail is required." ToolTip="E-mail is required."  Display="Dynamic"  ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    <div class="invalid-feedback">
                    </div></div>
                    <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                      <div class="palceholder">
          <label for="Mobile">Mobile</label>
            <span class="star">*</span>
          </div>
                        <asp:TextBox ID="Mobile" runat="server" CssClass="form-control"  type="number" MaxLength="10"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mobile" 
                                     Display="Dynamic" ErrorMessage="Mobile No. is required." ToolTip="Mobile No. is required."  CssClass="failureNotification"  ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </div>
                  
                  
                  </div>

                  <div class="row">
                    <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                      <div class="palceholder">
        <label for="Email">Password</label>
            <span class="star">*</span>
          </div>
                 <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" CssClass="failureNotification"  ForeColor="Red"
                                     Display="Dynamic" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    <div class="invalid-feedback">
                    </div></div>
                    <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                      <div class="palceholder">
          <label for="Mobile">Confirm Password</label>
            <span class="star">*</span>
          </div>
                       <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword"  Display="Dynamic" CssClass="failureNotification" ForeColor="Red"
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="failureNotification" 
                                      Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup"></asp:CompareValidator>
                    </div>
                  
                  
                  </div>
                  <div class="row">
                    <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                      <div class="palceholder">
            <label for="Orgnaisation">Organization</label>
            <span class="star">*</span>
          </div>
                       <asp:TextBox ID="Orgnaisation" runat="server" CssClass="form-control" ></asp:TextBox>

                                <asp:RequiredFieldValidator ID="OrgnaisationRequired" runat="server" ControlToValidate="Orgnaisation" 
                                     Display="Dynamic" ErrorMessage="Orgnaisation is required." ToolTip="Orgnaisation is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                        <asp:DropDownList ID="Industry" runat="server" CssClass="form-control" ></asp:DropDownList>
	                    </div>
                    </div>
                  
                  <div class="button-box">
                    <div class="custom-control custom-checkbox">
                      <input type="checkbox" name="agree" class="custom-control-input" id="agree">
                      <label class="custom-control-label" for="agree">I am authorized to respond to a survey on my company's HR practices, and consent to the submitted information being used in accordance with the <a href="#">privacy policy</a>.</label>
                    </div>
                  </div>
                  <div class="form-group">
                   <asp:Button ID="CreateUserButton" runat="server"  Text="Continue"  CssClass="btn btn-auth-color btn-lg btn-block"
                                 ValidationGroup="RegisterUserValidationGroup" 
                          onclick="CreateUserButton_Click"/>
                   
                  </div>
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-muted">
                <span style="color:red">*</span>Mandatory
              </div>
                                    </div>
                                </div>
                            </div>    
						</div>


              
            </div>
           
          </div>
        </div>
      </div>
    </section>
  </div>
  <!-- General JS Scripts -->
  <script src="/assets/js/app.min.js"></script>
  <!-- JS Libraies -->
  <!-- Page Specific JS File -->
  <!-- Template JS File -->
  <script src="/assets/js/scripts.js"></script>
  <script>
      /***********
      Making placeholder star specifically red 
      ****************/


      $('.palceholder').click(function () {
          $(this).siblings('input').focus();
      });
      $('.form-control').focus(function () {
          $(this).siblings('.palceholder').hide();
      });
      $('.form-control').blur(function () {
          var $this = $(this);
          if ($this.val().length == 0)
              $(this).siblings('.palceholder').show();
      });
      $('.form-control').blur();
  </script>
    </form>
</body>
</html>
