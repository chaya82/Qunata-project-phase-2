<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="ManagerDashboard.aspx.cs" Inherits="Quanta.Manager.ManagerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
 <section class="section">
          <div class="section-header">
            <h1>Dashboard</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">Manager</a></div>
              
              <div class="breadcrumb-item">Dashboard</div>
            </div>
          </div>
          <div class="section-body">
            <div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="card">
                  <div class="card-header">
                    <h4>User Management</h4>
                  </div>
                  <div class="card-body card-height" style="padding:30px 70px;">
						<div class="timeline-activity">
                            <div class="activity-item1">
                                    <div class="text-muted"><a href="UserManagement.aspx" class="text-muted-purple">Create User</a></div>
                                    <p class="p-b-25"></p>
                            </div>
                            <div class="activity-item2">
                                    <div class="text-muted"><a href="UserManagement.aspx" class="text-muted-green">Assign User Type</a></div>
                                    <p class="p-b-25"></p>
                            </div>
                            <div class="activity-item3">
                                    <div class="text-muted"><a href="UserManagement.aspx" class="text-muted-pink">Delete User</a></div>
                                    <p class="p-b-25"></p>

                            </div>
                            <div class="activity-item4">
                                    <div class="text-muted"><a href="UserManagement.aspx" class="text-muted-yellow">Edit User</a></div>
                                    <p class="p-b-25"></p>
                            </div>
                        </div>
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="card">
                  <div class="card-header">
                    <h4>Reports</h4>
                  </div>
                  <div class="card-body card-height" style="text-align:center;">
						<a href="#"><img src="../images/report.png" class="img-width"  /></a>
                        </div>
                  </div>
                  </div>
                  </div>
                  <div class="row">
              <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="card">
                  <div class="card-header">
                    <h4>Data Entry</h4>
                  </div>
                  <div class="card-body card-height" style="padding:30px 70px;">
						<p class="p-b-25"><a href="DataEntry1.aspx" class="btn btn-icon btn-info btn-pad"><i class="fas fa-building"></i></a> <a href="DataEntry1.aspx"><span class="data-text">Organization Details</span></a></p>
                        <p class="p-b-25"><a href="DataInst.aspx" class="btn btn-icon btn-primary btn-pad" style="background:#ff396f"><i class="fas fa-user-alt"></i></a> <a href="DataInst.aspx"><span class="data-text">Employee Details</span></a></p>
                        <p class="p-b-25"><a href="UploadEmpData.aspx" class="btn btn-icon btn-primary btn-pad"  style="background:#6777ef"><i class="fas fa-upload"></i></a> <a href="UploadEmpData.aspx"><span class="data-text">Data upload</span></a></p>
                        </div>
                  </div>
                  </div>
                  
                  </div>

            
                  </div>
                  
        </section>
</div>
</asp:Content>
