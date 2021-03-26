<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="Quanta.Manager.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
#label {margin-left:5px;}
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
                <div class="card">
                <div class="card-header">
                    <h4>Create User</h4>
                  </div>
                 <div class="card-body">
                  <div class="row">
                             <div class="col-lg-6 col-md-6 col-sm-12">
                                    <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                             </div>
                             <div class="col-lg-6 col-md-6 col-sm-12">
                                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                             </div>
                  </div>
                  <div class="row">&nbsp;</div>
                   <div class="row">

                             <div class="col-lg-6 col-md-6 col-sm-12">
                                    <asp:TextBox ID="TxtPhone" runat="server" CssClass="form-control" placeholder="Phone"></asp:TextBox>
                             </div>
                             <div class="col-lg-6 col-md-6 col-sm-12">
                                    <asp:TextBox ID="TxtUser" runat="server" CssClass="form-control" placeholder="User Type"></asp:TextBox>
                             </div>
                  </div>
                  <div class="row">&nbsp;</div>
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center">
                  <asp:Button ID="btnSave" runat="server" Text="Save User" CssClass="btn btn-warning"  />
                  
                  </div>
                  </div>
                  </div>
                  </div>
                  </div>
                  </div>

          <div class="row">
              
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                  
                  <div class="card-body">
                    <table class="table table-striped">
                      <thead>
                        <tr>
                          <th scope="col">S.No.</th>
                          <th scope="col">User Name</th>
                          <th scope="col">User Type</th>
                          <th scope="col">Email</th>
                          <th scope="col">&nbsp;</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td>1</td>
                          <td>ABC</td>
                          <td>Data Entry</td>
                          <td>abc@gmail.com</td>
                          <td><a href="#"><i class="fa fa-edit"></i></a>  <a href="#"><i class="fas fa-user-times"></i></a></td>
                        </tr>
                        <tr>
                          <td>2</td>
                          <td>XYZ</td>
                          <td>Manager</td>
                          <td>xyz@gmail.com</td>
                          <td><a href="#"><i class="fa fa-edit"></i></a>  <a href="#"><i class="fas fa-user-times"></i></a></td>
                        </tr>
                        
                      </tbody>
                    </table>
                    
                  </div>
                </div>
                
                
              </div>
              
            </div>
          </div>
          </section>
</div>


</asp:Content>
