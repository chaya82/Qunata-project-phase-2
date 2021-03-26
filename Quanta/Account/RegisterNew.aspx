<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterNew.aspx.cs" Inherits="Quanta.Account.RegisterNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                    <li class="active"><a href="#login" aria-controls="login" class="active" role="tab" data-toggle="tab"  id="ahrfLogin">Sign In</a></li>
                                    <li ><a href="#register" aria-controls="register" role="tab" data-toggle="tab" id="ahrfcreate">Create Account</a></li>
                                </ul>
                            </div>
                            <div class="tab-content">
                            
                                <div role="tabpanel" class="tab-pane active" id="login"> 

                              <asp:Login ID="LoginUser" runat="server" EnableViewState="false"  
    RenderOuterTable="false" onloggedin="LoginUser_LoggedIn" onauthenticate="LoginUser_Authenticate" 
                                            onloggingin="LoginUser_LoggingIn">
        <LayoutTemplate>
            <span class="failureNotification input-width">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
          

                     <asp:TextBox ID="UserName" runat="server" CssClass="form-control input-width" placeholder="Email/Phone" name="email" tabindex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification input-validate" ErrorMessage="Username required." ToolTip="Username required."  Display="Dynamic"
                             ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
                             
                                            <div class="d-block">
                      
                      <div class="float-right">
                      &nbsp;
                        <%--<a href="ForgotPassword.aspx" class="text-small">
                          Forgot Password?
                        </a>--%>
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
                                            <div style="text-align:center">
                      <p class="signup" >Don't have an account? <a href="#register" Xdata-toggle="tab" class="tab-link">Sign Up</a> here.</p>
                      </div>
                                             </LayoutTemplate>
    </asp:Login>
                                </div>
                                <div role="tabpanel" class="tab-pane" id="register"> 
                                <div class="sign-up-option">
                <div class="sign-up-line"></div>
                <div class="sign-up-option-text"><strong>SIGN UP HERE</strong></div>
                <div class="sign-up-line"></div>
            </div>

            <div style="text-align:center">
                      <p class="signup" >Already have an account? <a href="#login" Xdata-toggle="tab" class="tab-link">Sign in</a></p></div>

                                    <div class="register-form">
                                       
                                       
  
               
                    <span class="signup">Please enter your account details.</span>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                         <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
                    </span>
               
                                            <div class="row">
                    <div class="form-group name-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                        <asp:Label ID="Label1" runat="server" CssClass="failureNotification"></asp:Label>
                    <div class="palceholder">
             <label for="name">Name</label>
            <span class="star">*</span>
          </div>
             <asp:TextBox ID="Name" runat="server" CssClass="form-control"  ></asp:TextBox>
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
                                     <asp:RegularExpressionValidator ID="regexEmailValid1"  Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="RegisterUserValidationGroup" CssClass="failureNotification" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
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
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="Dynamic" runat="server" ControlToValidate="Mobile" 
                                     ErrorMessage="Invalid Phone number / Only 10 digit Phone number allowed"  ValidationGroup="RegisterUserValidationGroup"
                                     ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
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

                                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Password" ID="RegularExpressionValidator2"  ForeColor="Red"
                                     ValidationExpression = "^[\s\S]{6,}$" runat="server" ErrorMessage="Password length minimum: 6 required." ValidationGroup="RegisterUserValidationGroup"></asp:RegularExpressionValidator>
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
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Industry" 
                                     Display="Dynamic" ErrorMessage="Industry is required." ToolTip="Industry is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblindustry" runat="server" ForeColor="Red"></asp:Label>
                            
	                    </div>
                    </div>
                 
                 
                  <div class="button-box">
                    <div class="custom-control custom-checkbox">
                     <div class="col-md-1">
                              
                            </div>
                            <div class="col-md-11" style="margin-top: 10px;">
<%--
                            <input type="checkbox" name="agree" class="custom-control-input" id="agree" id="chk1">
                      <label class="custom-control-label" for="agree">I am authorized to respond to a survey on my company's HR practices, and consent to the submitted information being used in accordance with the <a href="#">privacy policy</a>.</label>
                    --%>
                              <asp:CheckBox ID="chkTerms" runat="server" value="term" ClientIDMode="Static" />
                                I am authorized to respond to a survey on my company's HR practices, and consent to the submitted information being used in accordance with the <a href="#">privacy policy</a>
                            <asp:Label ID="lblchk" runat="server" ForeColor="Red"  ClientIDMode="Static"></asp:Label>
                          
                    
                            </div>
                      </div>
                  </div>
                       <div class="form-group" align="center">
                     
                            <asp:Button ID="CreateUserButton" runat="server" OnClientClick="javascript:ValidateCheckBoxes();"
                                Text="Create User"   CssClass="btn btn-auth-color btn-lg btn-block btn-width"
                                 ValidationGroup="RegisterUserValidationGroup" 
                                OnClick="CreateUserButton_Click"/>
                             
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
    <script type = "text/javascript">
        function ValidateCheckBoxes() {
            var abc = "chkTerms";
            if (document.getElementById(abc).checked == true) {
                return true;
            } else {
                var xyz = "lblchk";
                document.getElementById(xyz).innerHTML = " Please Check Accept";
                document.getElementById(xyz).focus();

                return false;
            }
        }
    </script>
</asp:Content>
