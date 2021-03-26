<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Account/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Quanta.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<style>.theme-coral a {
    color: #ff470f;
}</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <div id="app">
    <section class="section">
      <div class="container mt-3">
        <div class="row">
          <div class="col-12 col-sm-8 offset-sm-2 col-md-6 offset-md-3 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4">
            <div class="login-brand login-brand-color">
            	QUANTA
             
            </div>
            <div class="card">
            <div class="card-header card-header-auth">
                <h4>Change Password</h4>
              </div>
               <div class="card-body">
               
                                <div class="sign-up-option" style="visibility:hidden;">
                <div class="sign-up-line"></div>
                <div class="sign-up-option-text"><strong>SIGN UP HERE</strong></div>
                <div class="sign-up-line"></div>
            </div>

        

                                    <div class="register-form">
       <span class="signup">
        New passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
   </span>
    <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/Manager/dashboard.aspx" EnableViewState="false" RenderOuterTable="false" 
         SuccessPageUrl="~/Manager/dashboard.aspx">
        <ChangePasswordTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
        
         
                
           
                                           
                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword" style="display:none" >Old Password:</asp:Label>
                         
                          
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="form-control input-width" placeholder="Old Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" Display="Dynamic"
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required." 
                             ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                   
                         <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword" style="display:none">New Password:</asp:Label>
                          
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="form-control input-width" placeholder="New Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"  Display="Dynamic"
                             CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required." 
                             ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                   
                      <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword" style="display:none">Confirm New Password:</asp:Label>
                       
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="form-control input-width" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                             ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                             ValidationGroup="ChangeUserPasswordValidationGroup"></asp:CompareValidator>
                             <div class="row">&nbsp;</div>
                   <div class="row">
                   <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-lg btn-auth-color" />
                    
                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Change Password" CssClass="btn btn-lg btn-auth-color" ValidationGroup="ChangeUserPasswordValidationGroup"/>
                    </div>
                    </div>
                
            
          
        </ChangePasswordTemplate>
    </asp:ChangePassword>
    </div>
       </div>
            </div>
           
          </div>
        </div>
      </div>
    </section>
   </div>
</asp:Content>
