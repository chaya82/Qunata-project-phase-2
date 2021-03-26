<%@ Page Title="Register" Language="C#" MasterPageFile="~/Account/Site1.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Quanta.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

<style>
    .check-auth 
    {
        margin-top: 10px;
    position: relative;
    left: 20px;
    top: -28px;
    }
    .header-tab-menu .nav-tabs li a.active {
    color: #ff470f;
    border-bottom: solid 2px #ff470f;}
    .theme-coral a 
    {color: #ff470f;}
.sign-up-option {
    align-items: center;
    display: flex;
    flex: 0 0 auto;
    justify-content: center;
    margin: 25px 0;
    color:#232323;
    font-size: 16px;
}
.sign-up-line {
    border-top: 1px solid #b2b2b2;
    flex: 1 1 auto;
}
.sign-up-option-text {
    margin: 0 10px;
}
.signup 
{
    color: #232323;
    font-weight: bold;
}
.input-width {width: 80%;
    margin: 0px 40px;}
.input-validate {width: 80%;
    margin: 0px 40px;}
    .mt-20 {margin-top:20px;}
 
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager ID="scrr" runat="server"></asp:ScriptManager>
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
                                    <li class="active"><a href="#login" aria-controls="login" class="active" role="tab" data-toggle="tab"  id="ahrfLogin">Sign In</a></li>
                                   <%-- <li ><a href="#register" aria-controls="register" role="tab" data-toggle="tab" id="ahrfcreate">Create Account</a></li>--%>
                                </ul>
                            </div>
                            <div class="tab-content">
                            
                                <div role="tabpanel" class="tab-pane active" id="login"> 

                                <div class="sign-up-option" style="visibility:hidden;">
                <div class="sign-up-line"></div>
                <div class="sign-up-option-text"><strong>SIGN IN TO YOUR DASHBOARDS</strong></div>
                <div class="sign-up-line"></div>
            </div>
                                    <div class="login-form-container col-12 col-sm-10 offset-sm-1 col-md-8 offset-md-2 col-lg-8 offset-lg-2 col-xl-8 offset-xl-2">
                                      <asp:Login ID="LoginUser" runat="server" EnableViewState="false"  
    RenderOuterTable="false" onloggedin="LoginUser_LoggedIn" onauthenticate="LoginUser_Authenticate" 
                                          >
        <LayoutTemplate>
            <span class="failureNotification input-width">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
          

                     <asp:TextBox ID="UserName" runat="server" CssClass="form-control input-width" placeholder="Email/Phone" name="email" tabindex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification input-validate" ErrorMessage="Username required." ToolTip="Username required."  Display="Dynamic"
                             ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
                             
                                            <div class="d-block input-width">
                      
                      <div class="float-right ">
                      &nbsp;
                        <a href="ForgotPassword.aspx" class="text-small">
                          Forgot Password?
                        </a>
                      </div>
                    </div>
                        <asp:TextBox ID="Password" runat="server" placeholder="Password" CssClass="form-control input-width mt-20"  tabindex="2" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Display="Dynamic"
                             CssClass="failureNotification input-validate" ErrorMessage="Password required." ToolTip="Password required." 
                             ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
                                            
                                            <div class="button-box">
                                                <div class="custom-control custom-checkbox">
                                                   <asp:CheckBox ID="RememberMe" runat="server"  CssClass="custom-control-input" tabindex="3" Visible="false" />
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="custom-control-label form-group" Visible="false" >Keep me logged in</asp:Label>
  
                    </div>
                     
                                           
                                            </div>
                                            <div align="center"><asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" CssClass="btn btn-lg btn-block btn-auth-color btn-width" /></div>
                                            <div class="row">&nbsp;</div>
                                            <div style="text-align:center; display:none" >   <p class="signup" >Don't have an account? <a href="#" data-toggle="modal" data-target="#ContactForm" Xdata-toggle="tab" class="tab-link">Sign Up</a> here.</p>
                    
                      </div>
                                             </LayoutTemplate>
    </asp:Login>
                                        
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
   <div class="modal fade" id="ContactForm" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Contact Form</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <div class="contact animated fadeIn visible" data-animation="fadeIn" data-animation-delay="200">
				<!-- Contact Form -->
				<form id="contact-form" name="cform" class="clearfix" method="post" action="http://north.goldeyestheme.com/north/php/gmail.php">
					<!-- Left Inputs -->
					<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <!-- Name -->
                        <asp:TextBox ID="txtname" runat="server" CssClass="form light-form oswald" placeholder="NAME"></asp:TextBox>
						 <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="txtname" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Name is required." ToolTip="Name is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <!-- organization -->
                         <asp:TextBox ID="txtORGANIZATION" runat="server" CssClass="form light-form oswald" placeholder="ORGANIZATION"></asp:TextBox>
					 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtORGANIZATION" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Organization is required." ToolTip="Organization is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <!-- designation -->
                         <asp:TextBox ID="txtDESIGNATION" runat="server" CssClass="form light-form oswald" placeholder="DESIGNATION"></asp:TextBox>
						 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDESIGNATION" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Designation is required." ToolTip="Designation is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
						<!-- Email -->
                         <asp:TextBox ID="txtEmail" runat="server" CssClass="form light-form oswald" placeholder="E-MAIL"></asp:TextBox>
						 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Email is required." ToolTip="Email is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="regexEmailValid1"  Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="RegisterUserValidationGroup" CssClass="failureNotification" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <!-- phone -->
                         <asp:TextBox ID="txtPHONE" runat="server" CssClass="form light-form oswald" placeholder="PHONE"></asp:TextBox>
						 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPHONE" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Phone is required." ToolTip="Phone is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="Dynamic" runat="server" ControlToValidate="txtPHONE" 
                                     ErrorMessage="Invalid Phone number / Only 10 digit Phone number allowed"  ValidationGroup="RegisterUserValidationGroup"
                                     ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="padding: 5px 30px;">
                        <!-- phone -->
						I am interested in: <div class="radio">
                        <asp:RadioButton ID="rdoBasic" runat="server" GroupName="interested" Text="Quanta Basic" Checked="true" />
                         <asp:RadioButton ID="rdoPro" runat="server" GroupName="interested" Text="Quanta Pro" />
 
</div>
                        </div>
					
					<!-- Send Button -->
					<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
						<!-- Button -->
                         <asp:Button ID="SendButton" runat="server" CommandName="MoveNext" Text="SEND EMAIL"  OnClick="SendButton_Click" CssClass="form contact-form-button light-form oswald"
                                 ValidationGroup="RegisterUserValidationGroup"/>
					
					</div>
					<!-- End Send Button -->
				</form>
				<!-- End Form -->

				<!-- Your Mail Message -->
				<div class="mail-message-area">
					<!-- Message -->
					<div class="alert light-form mail-message not-visible-message">
						<strong>Thank You !</strong> Your email has been delivered.
					</div>
				</div>
				<!-- End Mail Message -->
			</div>
      </div>
      <div class="modal-footer">
        
        
      </div>
    </div>
  </div>
</div>
</asp:Content>
