<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="Quanta.Account.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <asp:CreateUserWizard ID="RegisterUser" runat="server" 
                                            EnableViewState="false"  DisableCreatedUser="True" ContinueDestinationPageUrl="~/Account/Login.aspx" 
        OnCreatedUser="RegisterUser_CreatedUser" 
        oncreatinguser="RegisterUser_CreatingUser" 
        onsendingmail="CreateUserWizard1_SendingMail" onfinishbuttonclick="RegisterUser_FinishButtonClick">
<MailDefinition From="admin@baithaks.in" 
                Subject="Confirmation mail" 
                BodyFileName="~/mail.txt">
</MailDefinition>
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                  <div class="row">
                    <div class="form-group name-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
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
                   <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Continue"  CssClass="btn btn-auth-color btn-lg btn-block"
                                 ValidationGroup="RegisterUserValidationGroup"/>
                   
                  </div>
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-muted">
                <span style="color:red">*</span>Mandatory
              </div>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" >
            <ContentTemplate>
            <table border="0" style="height: 100%; width: 100%;">
                      <tr>
                        <td align="center" colspan="2">
                           Your account has been successfully created.</td>
                      </tr>
                      <tr>
                        <td>
                         
                          An email has been sent to your account. Please view the email and confirm your account to complete the registration process.</td>
                      </tr>
                      
                    </table>
            </ContentTemplate>
            </asp:CompleteWizardStep>
               </WizardSteps>
    </asp:CreateUserWizard>
    </form>
</body>
</html>
