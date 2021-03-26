<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="Quanta.Manager.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.table-new 
{
    background: #ff470f!important;
    color: #fff!important;
}

.input-width1 {width:38%;}
@media only screen and (max-width: 1440px) 
{
 .input-width1 {width:38%;}   
} 
@media only screen and (max-width: 425px) 
{
 .input-width1 {width:100%;}   
} 

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>User Management</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User Management</a></div>
              
              <div class="breadcrumb-item">Create User</div>
            </div>
          </div>
          <div class="section-body">
            <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="card" >
                <div class="card-header">
                    <h4>Create User</h4>
                  </div>
                 <div class="card-body ">
                    
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                     <asp:Label ID="lblerrormsg"  runat="server"></asp:Label>
                      <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                         <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
                    </span>
                     </div>
                     <div class="row">
                             <div class="col-lg-6 col-md-6 col-sm-12">
                                   <asp:TextBox ID="Name" runat="server" CssClass="form-control" placeholder="Name" ></asp:TextBox>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Visible="false" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name" Display="Dynamic" CssClass="failureNotification" 
                                     ErrorMessage="Name is required." ToolTip="Name is required."   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                             </div>
                             <div class="col-lg-6 col-md-6 col-sm-12">
                                        <asp:TextBox ID="Email" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"  CssClass="failureNotification" 
                                      ErrorMessage="E-mail is required." ToolTip="E-mail is required."  Display="Dynamic"  ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="regexEmailValid1"  Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="RegisterUserValidationGroup" CssClass="failureNotification" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                
                             </div>
                  </div>
                  <div class="row">&nbsp;</div>
                   
                  <div class="row">

                             <div class="col-lg-6 col-md-6 col-sm-12">
                                     <asp:TextBox ID="Mobile" runat="server" CssClass="form-control"  type="number" MaxLength="10" placeholder="Mobile"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Mobile" 
                                     Display="Dynamic" ErrorMessage="Mobile No. is required." ToolTip="Mobile No. is required."  CssClass="failureNotification"  ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="Dynamic" runat="server" ControlToValidate="Mobile" 
                                     ErrorMessage="Invalid Phone number / Only 10 digit Phone number allowed"  ValidationGroup="RegisterUserValidationGroup"
                                     ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                             </div>
                             <div class="col-lg-6 col-md-6 col-sm-12">
                                       <asp:DropDownList ID="UserType" runat="server" CssClass="form-control">
                  <asp:ListItem Value="">Select User Type</asp:ListItem>
                   <asp:ListItem Value="DataEntry">Data Entry Operator</asp:ListItem>
                  </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserType"  CssClass="failureNotification" 
                                      ErrorMessage="UserType required." ToolTip="UserType is required."  Display="Dynamic"  ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                             </div>
                  </div>
                  <div class="row">&nbsp;</div>
                                            
			

                  <div class="row" style="display:none">
                    <div class=" col-lg-6 col-md-12 col-sm-12 ">
                   
                 <asp:TextBox ID="Password" runat="server" CssClass="form-control"  placeholder="Password"></asp:TextBox>
                                </div>
                    <div class=" col-lg-6 col-md-12 col-sm-12 ">
                  
                     
                    </div>
                  
                  
                  </div>

                    <div class="row">&nbsp;</div>
                                            
                 
                 
                  
                     <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center">
                            <asp:Button ID="CreateUserButton" runat="server" 
                                Text="Create User"   CssClass="btn btn-warning"
                                 ValidationGroup="RegisterUserValidationGroup" 
                                OnClick="CreateUserButton_Click"/>
                                  <asp:Button ID="UpdateUser" runat="server" Visible="false"
                                Text="Update User"   CssClass="btn btn-warning"
                                 ValidationGroup="RegisterUserValidationGroup" 
                                OnClick="UpdateUserButton_Click"/>
                             
                  </div>

                  
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-muted">
                <span style="color:red">*</span>Mandatory
              </div>
                  
                  </div>
                </div>
              </div>
           </div>
           <div class="row">
              <div class="col-12">
                <div class="card">
                  <div class="card-header">
                    <h4>User List</h4>
                  </div>
                  <div class="card-body">
                    <div class="table-responsive">
                      <table class="table table-striped table-hover" id="save-stage" style="width:100%;">
                        <thead>
                          <tr>
                           <th>Name</th>
                            <th>UserName</th>
                            <th>Password</th>
                            <th>Email</th>
                            <th>Mobile</th>
                          <th>Edit/Delete</th>
                          </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="rptuserlist" runat="server">
                        <ItemTemplate>
                        <tr>
                         <td><%#Eval("name") %></td>
                            <td><%#Eval("username") %></td>
                            <td><%#Eval("pwd") %></td>
                            <td><%#Eval("username") %></td>
                            <td><%#Eval("MobileAlias")%></td>
                           <td>
                                <asp:LinkButton ID="lnkedit" runat="server" CommandName="modify" ToolTip="Edit Records" OnClick="editUser"
                                        Width="20px" CommandArgument='<%#Eval("username") %>'> <i class="fa fa-edit"></i></asp:LinkButton>
                                       
                                           <asp:LinkButton ID="lnkremove" runat="server" CommandName="remove" ToolTip="Delete Records" OnClick="deleteUser" OnClientClick="javascript:confirm('Are you sure you want delete?');" 
                                        Width="20px" CommandArgument='<%#Eval("username") %>'> <i class="fas fa-trash-alt"></i></asp:LinkButton>
                                      
                           </td>
                          </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                          
                    
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
        
      </div>
      <script>
          $(document).ready(function () {
              $('#UserMgmt').addClass('active');
          });
</script>
</asp:Content>
