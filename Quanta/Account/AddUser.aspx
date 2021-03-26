<%@ Page Title="Register" Language="C#" MasterPageFile="~/Account/Site1.Master" AutoEventWireup="true"
    CodeBehind="AddUser.aspx.cs" Inherits="Quanta.Account.AddUser" %>

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
                      
                            
                                
                            
                                <div class="sign-up-option" style="visibility:hidden;">
                <div class="sign-up-line"></div>
                <div class="sign-up-option-text"><strong>SIGN UP HERE</strong></div>
                <div class="sign-up-line"></div>
            </div>

        

                                    <div class="register-form">
                                       
                                       
    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="true"  DisableCreatedUser="True" ContinueDestinationPageUrl="~/Account/Register.aspx" 
     
        OnCreatedUser="RegisterUser_CreatedUser" 
        oncreatinguser="RegisterUser_CreatingUser" 
        onsendingmail="CreateUserWizard1_SendingMail">
<MailDefinition From="admin@baithaks.in" 
                Subject="Confirmation mail" 
                BodyFileName="~/mail.html">
</MailDefinition>
        
        <WizardSteps>
        
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
               
                    <span class="signup">Please enter your details.</span>
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
             <asp:TextBox ID="Name" runat="server" CssClass="form-control" autofocus ></asp:TextBox>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Visible="false" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Name is required." ToolTip="Name is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                   
                    </div>
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
                                     Display="Dynamic" ErrorMessage="Organization is required." ToolTip="Organization is required."   ForeColor="Red"
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
                              <asp:CheckBox ID="chkTerms" runat="server" value="term" />
                            </div>
                            <div class="col-md-11 check-auth">
<%--
                            <input type="checkbox" name="agree" class="custom-control-input" id="agree" id="chk1">
                      <label class="custom-control-label" for="agree">I am authorized to provide data regarding the company and generate analytics reports basis the same. I consent to the submitted information being used in accordance with the  <a href="#">privacy policy</a>.</label>
                    --%>
                              
                                I am authorized to provide data regarding the company and generate analytics reports basis the same. I consent to the submitted information being used in accordance with the <a href="#">privacy policy</a>.<br />
                            <asp:Label ID="lblchk" runat="server" ForeColor="Red"></asp:Label>
                     
                    
                            </div>
                      </div>
                  </div>
                       <div class="form-group" align="center">
                     
                            <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Create User"   CssClass="btn btn-auth-color btn-lg btn-block btn-width"
                                 ValidationGroup="RegisterUserValidationGroup"/>
                             
                  </div>

                  
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-muted">
                <span style="color:red">*</span>Mandatory
              </div>
                    </div>

                   
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" >
            <%--<ContentTemplate>
            <div class="card">
              <div class="card-header card-header-auth">
                <h4>User Verification</h4>
              </div>
              <!-- <center>
              <div class="logo-auth">
              	<img alt="image" src="assets/img/logo.png" />
          	  </div>
          	  <div>
          	  	<span class="logo-name-auth">Grexa</span>
          	  </div>
          	  </center> -->
              <div class="card-body">
                <p class="text-muted">We have sent a verification url link to your registerd emailid. Click on link to confirm your email address.</p>
               
                
                  <div class="form-group">
                   
                    <p class="text-muted">If you have not received, then click resend button after <span id="spnTm">180</span> Seconds.</p>
                    <asp:Button ID="btnresend" runat="server" Text="Resend"  CssClass="btn btn-lg btn-block btn-auth-color" TabIndex="5" />
                 
                  </div>
               
              </div>
            </div>
            </ContentTemplate>--%>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
      </div>
                               
  
						</div>


              
            </div>
           
          </div>
        </div>
      </div>
    </section>
  </div>
  <%--<script>
      var myvar;
      var z = document.getElementById('spnTm').innerHTML;
      function resendActiveTime() {
          if (z >= 0) {
              document.getElementById('spnTm').innerHTML = parseInt(z);
              z = parseInt(z) - 1
          }
          else {
              $('#btnresend').attr("style", "display:block");
              clearInterval(myVar)
          }

      }

      $(document).ready(function () {
          myvar = setInterval(resendActiveTime, 1000)
      })
    </script>--%>
    <script>
        $('.tab-link').on('click', function (event) {
            // Prevent url change
            event.preventDefault();

            // `this` is the clicked <a> tag
            $('[data-toggle="tab"][href="' + this.hash + '"]').trigger('click');
        })
    </script>

    
    <script type = "text/javascript">
        function ValidateCheckBoxes() {
        var abc= "MainContent_RegisterUser_CreateUserStepContainer_chkTerms";
        if (document.getElementById(abc).checked == true) {
            return true;
        } else {
        var xyz = "MainContent_RegisterUser_CreateUserStepContainer_lblchk";
                document.getElementById(xyz).innerHTML = " Please select privacy policy checkbox";
                document.getElementById(xyz).focus();
                
                return false;
            }
        }
    </script>
</asp:Content>
