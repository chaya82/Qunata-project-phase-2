<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/inner.Master" AutoEventWireup="true" CodeBehind="AddBenchmark.aspx.cs" Inherits="Quanta.Admin.AddBenchmark" %>
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
.dark .table-striped tbody tr:nth-of-type(odd) {
    background-color: rgb(26 32 46);
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Add Benchmark</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">Add Benchmark</a></div>
              
              <div class="breadcrumb-item">Add Benchmark</div>
            </div>
          </div>
          <div class="section-body">
            <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="card" >
                <div class="card-header">
                    <h4>Add Benchmark</h4>
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
            <div class="form-group col-lg-5 col-md-12 col-sm-12 col-xs-12">
                      <div class="palceholder">
            <label for="Orgnaisation">Select Metric</label>
            <span class="star">*</span>
          </div>
                         <asp:DropDownList ID="ddlRType" runat="server" CssClass="form-control" 
                          AutoPostBack="true" onselectedindexchanged="ddlRType_SelectedIndexChanged" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRType" 
                                     Display="Dynamic" ErrorMessage="Select Metric." ToolTip="Select Metric"   ForeColor="Red"
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </div>
                    
                    
                  
                  
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
                    <h4>Benchmark List</h4>
                  </div>
                  <div class="card-body">
                    <div class="table-responsive">
                     
                        <asp:Repeater ID="rptlist" runat="server" OnItemDataBound="rptGrade_ItemDataBound">
                        <HeaderTemplate>
                         <table class="table table-striped table-hover" style="width:100%;">
                        <thead>
                          <tr>
                           <th style="width:25%">Industry</th>
                           
                    
                            <th style="text-align: center; width:25%"><100</th>
                              <th style="text-align: center; width:25%">100-500</th>
                                <th style="text-align: center; width:25%">500</th>
                                 
                        
                          </tr>
                        </thead>
                        <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                        <tr>
                    
                            <td>  <asp:HiddenField ID="hdnid" runat="server" Value=' <%#Eval("id") %>'></asp:HiddenField><asp:Label ID="lblindustry" runat="server" Text=' <%#Eval("name") %>'></asp:Label></td>
                          <td style="text-align: center;">  
                          <div class="row">
                          <div class="col-lg-12" style="display:inline-table">   <asp:TextBox ID="txtbm1_1" runat="server"  value="0.00" type="number" step="0.01" Width="100px"  Text='<%#Eval("bm1_1")%>'></asp:TextBox>
                           <asp:TextBox ID="txtbm1_2" runat="server" type="number"  step="0.01"  value="0.00" Width="100px"  Text='<%#Eval("bm1_2")%>' Visible="false"></asp:TextBox>
                           </div>
                          </div>
                         
                        
                          </td>
                          <td  style="text-align: center;">  
                           <div class="row">
                             <div class="col-lg-12" style="display:inline-table"> 
                         <asp:TextBox ID="txtbm2_1" runat="server" type="number" step="0.01" value="0.00"  Width="100px" Text='<%#Eval("bm2_1")%>'></asp:TextBox>
                         
                          <asp:TextBox ID="txtbm2_2" runat="server" type="number" step="0.01"  value="0.00"   Width="100px"  Text='<%#Eval("bm2_2")%>' Visible="false"></asp:TextBox>
                          </div>
                          </div>
                          </td>
                           <td  style="text-align: center;">
                            <div class="row">
                          <div class="col-lg-12" style="display:inline-table">  
                            <asp:TextBox ID="txtbm3_1" runat="server" type="number" step="0.01"  value="0.00" Width="100px"  Text='<%#Eval("bm3_1")%>'></asp:TextBox>
                           
                          <asp:TextBox ID="txtbm3_2" runat="server" type="number" step="0.01"  value="0.00" Width="100px"  Text='<%#Eval("bm3_2")%>' Visible="false"></asp:TextBox>
                          </div></div>
                          </td>
                            
                           
                          <%-- <td>
                                <asp:LinkButton ID="lnkedit" runat="server" CommandName="modify" ToolTip="Edit Records" OnClick="editUser"
                                        Width="20px" CommandArgument='<%#Eval("id") %>'> <i class="fa fa-edit"></i></asp:LinkButton>
                                                  
                           </td>--%>
                          </tr>
                        
                        </ItemTemplate>
                        <FooterTemplate>
                        </tbody>
                      </table>
                      </FooterTemplate>
                        </asp:Repeater>
                          
                    
                        <div id="accordion">
                      <asp:Repeater ID="rptListCurr" runat="server"  OnItemDataBound="rptListCurr_ItemDataBound">
                      <ItemTemplate>
                  <div class="accordion">
                        <div class="accordion-header" role="button" data-toggle="collapse" data-target="#panel-body-<%#Eval("id") %>">
                          <h4>  <asp:Label ID="lblcurr" runat="server" Text=' <%#Eval("name") %>'></asp:Label></h4>
                        </div>
                        <div class="accordion-body collapse " id="panel-body-<%#Eval("id") %>" data-parent="#accordion">
                          <table class="table table-striped table-hover" style="width:100%;">
                        <thead>
                          <tr>
                           <th>Industry</th>
                           
                    
                            <th style="text-align: center; "><100</th>
                              <th style="text-align: center; ">100-500</th>
                                <th style="text-align: center; ">>500</th>
                                 
                        
                          </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="rptinnerlist" runat="server" OnItemDataBound="rptGrade_ItemDataBound">
                        <ItemTemplate>
                        <tr>
                    
                            <td><%#Eval("name")%></td>
                          <td style="text-align: center; ">  
                            <asp:TextBox ID="txtbm1_1" runat="server" type="number" Width="100px"  Text='<%#Eval("bm1_1")%>'></asp:TextBox>
                          <asp:TextBox ID="txtbm1_2" runat="server" type="number"  Width="100px"   Text='<%#Eval("bm1_2")%>' Visible="false"></asp:TextBox>
                          </td>
                          <td style="text-align: center; ">  
                            <asp:TextBox ID="txtbm2_1" runat="server" type="number"  Width="100px"  Text='<%#Eval("bm2_1")%>'></asp:TextBox>
                          <asp:TextBox ID="txtbm2_2" runat="server" type="number"   Width="100px" Text='<%#Eval("bm2_2")%>' Visible="false"></asp:TextBox>
                          </td>
                           <td style="text-align: center; ">  
                            <asp:TextBox ID="txtbm3_1" runat="server" type="number"  Width="100px"  Text='<%#Eval("bm3_1")%>'></asp:TextBox>
                          <asp:TextBox ID="txtbm3_2" runat="server" type="number"  Width="100px" Text='<%#Eval("bm3_2")%>' Visible="false"></asp:TextBox>
                          </td>
                         
                          </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                          
                    
                        </tbody>
                      </table>
                        </div>
                      </div>
  
 

                      </ItemTemplate>
                      </asp:Repeater>
                       </div>
                      <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center">
                            <asp:Button ID="CreateButton" runat="server" Visible="false"
                                Text="Save"   CssClass="btn btn-warning"
                                 ValidationGroup="RegisterUserValidationGroup" onclick="CreateButton_Click" 
                              />
                                
                             
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
//          $(document).ready(function () {
//              $('#UserMgmt').addClass('active');
//          });
</script>
</asp:Content>