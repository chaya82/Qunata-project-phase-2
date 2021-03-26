<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Quanta.Manager.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.card-square {
    display: inline-flex;
    text-align: center;
    border-radius: 20%;
    -webkit-box-align: center;
    -ms-flex-align: center;
    align-items: center;
    -webkit-box-pack: center;
    -ms-flex-pack: center;
    justify-content: center;
    height: 35px;
    width: 35px;
    box-shadow: 0 4px 20px 0 rgba(0,0,0,.14), 0 7px 10px -5px rgba(76,175,80,.4);
}

</style>
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
              
                  
                  
                  
              <div class="col-lg-4 col-md-6 col-sm-12">
                <div style="text-align: center; border-right: solid 1px #fff;">
                  <div>
                    <h4 class="head-card">Data Entry</h4>
                  </div>
                  <div class="card-body card-height" style="text-align:center;">
						<a href="DataEntry1.aspx"><img src="../images/data-entry.png" class="img-width" style="filter: drop-shadow(1px 1px 6px #616672);"  /></a>
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-4 col-md-6 col-sm-12">
                <div style="text-align: center; border-right: solid 1px #fff;">
                  <div>
                    <h4 class="head-card">Reports</h4>
                  </div>
                  <div class="card-body card-height" style="text-align:center;">
						<a href="RPTReadRpt.aspx"><img src="../images/report.png" class="img-width" style="filter: drop-shadow(1px 1px 6px #616672);"  /></a>
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-4 col-md-6 col-sm-12">
                <div >
                  <div style="text-align: center;">
                    <h4 class="head-card">User Management</h4>
                  </div>
                  <div class="card-body card-height" style="padding:30px 40px 30px 90px;">
						<div class="timeline-activity">
                            <div class="activity-item1">
                                    <div class="text-muted"><a href="User.aspx" class="text-muted-purple">Create User</a></div>
                                    <p class="p-b-15"></p>
                            </div>
                            <div class="activity-item2">
                                    <div class="text-muted"><a href="User.aspx" class="text-muted-green">Assign User Type</a></div>
                                    <p class="p-b-15"></p>
                            </div>
                            <div class="activity-item3">
                                    <div class="text-muted"><a href="User.aspx" class="text-muted-pink">Delete User</a></div>
                                    <p class="p-b-15"></p>

                            </div>
                            <div class="activity-item4">
                                    <div class="text-muted"><a href="User.aspx" class="text-muted-yellow">Edit User</a></div>
                                    <p class="p-b-15"></p>
                            </div>
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
        $('#Dashboard').addClass('active');
    });
</script>
</asp:Content>