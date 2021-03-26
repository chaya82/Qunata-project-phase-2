<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="DataInst.aspx.cs" Inherits="Quanta.Manager.DataInst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.table td {
    color: #e2e2e2;
}
    .theme-coral a {
    color: #96a2b4;
}
.theme-coral a:hover {
    color: #ff470f;
}
    .table:not(.table-sm):not(.table-md):not(.dataTable) td, .table:not(.table-sm):not(.table-md):not(.dataTable) th {height:60px;}
    .modal-bg 
    {
        background: #38424b;
    color: #96a2b4;}
    
.table-new 
{
    background: #ff470f!important;
    color: #fff!important;
}

.add-btn 
{
    color: #fff;
    padding: 7px 10px;
    margin-bottom: 7px;}
    
.input-width1 {width:38%;}
@media only screen and (max-width: 1440px) 
{
 .input-width1 {width:38%;}   
 .add-btn {margin-bottom: 7px;}
} 
@media only screen and (max-width: 768px) 
{
 .add-btn {margin-bottom: 26px;}
} 
@media only screen and (max-width: 425px) 
{
 .input-width1 {width:100%;} 
 .add-btn {margin-bottom: 7px;}  
} 

</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
  <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
           
        <section class="section">
          <div class="section-header">
            <h1>Data Entry (Instructions for Data Upload)</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Data Entry</div>
            </div>
          </div>
          <div class="section-body">
            <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="card" style="overflow:auto">
                 <div class="card-body p-0">
                    <table class="table table-striped">
                      <thead>
                   
                        <tr>
                          <th scope="col" width="20%">Data Field</th>
                          <th scope="col" width="50%">Description/Instruction</th>
                          <th scope="col" width="30%"><input  class="form-check-input" id="selectAll" type="checkbox" />
                            <label class="form-check-label" for="defaultCheck1">Action</label></th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td>Emp ID</td>
                          <td>Mandatory unique identifier for each employee (we don’t need employee names)</td>
                          <td><div class="form-check">

                          <asp:CheckBox class="form-check-input" ID="chkEmpId" runat="server" />
	                       <%-- <input class="form-check-input" type="checkbox" id="chkEmpId">--%>
                          
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        <tr style="background: #1a2233;">
                          <td>Date of Birth/ Age</td>
                          <td>You need to enter either date of birth in dd-mm-yyyy format, or the current age of each employee</td>
                          <td>I will upload: <div class="form-check">
                          <asp:RadioButton ID="rdoDOB" GroupName="DOBAge" Text="DOB" runat="server" onclick="ShowHideDiv()" />
<asp:RadioButton ID="rdoAge" GroupName="DOBAge" Text="Age" runat="server" onclick="ShowHideDiv()" />
	                        
                            
                            
                            
	                       <%-- <label class="form-check-label" for="exampleRadios1">
	                          DOB
	                        </label>--%>
	                      </div>
                          <div class="form-check">
	                      <%--  <input class="form-check-input" type="radio" name="exampleRadios" id="Radio1" checked="">--%>
	                      <%--  <label class="form-check-label" for="exampleRadios1">
	                          Age
	                        </label>--%>
	                      </div></td>
                        </tr>
                        <tr>
                          <td>Date of Joining</td>
                          <td>You need to enter the Date of Joining for each employee, in dd-mm-yyyy format</td>
                          <td><div class="form-check">
	                        <asp:CheckBox class="form-check-input" ID="chkDtJoin" runat="server" />
                            <%--<input class="form-check-input" type="checkbox" id="Checkbox2">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        <tr style="background: #1a2233;">
                          <td>Gender</td>
                          <td>Please indicate the gender only as 'Male', 'Female' or 'Non-Binary'</td>
                          <td><div class="form-check">
                            <asp:CheckBox class="form-check-input" ID="chkGender" runat="server" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox3">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        <tr>
                          <td>Department</td>
                          <td>Please ensure you maintain consistency in department names within/ across sheets (e.g. Human Resource vs HR)</td>
                          <td><div class="form-check">
                          <asp:CheckBox class="form-check-input" ID="chkDept" runat="server" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox4">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                       
                        <tr style="background: #1a2233;">
                          <td>Grade/Career Level</td>
                          <td>Please indicate the Grade/ Career Level (and not designation/ job title)</td>
                          <td><div class="form-check" style="display:none;">
                          <asp:CheckBox class="form-check-input" ID="chkGrade" runat="server" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox6">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it | Click <a href="#" data-toggle="modal" data-target="#newModal"><span style="color:#ff470f">here</span></a> to provide grade mapping
	                        </label>
	                      </div>
                          Click <a href="#" data-toggle="modal" data-target="#newModal"><span style="color:#ff470f">here</span></a> to provide grade mapping
                           </td>
                        </tr>
                        <tr>
                          <td>Manager Emp ID</td>
                          <td>Mandatory unique identifier for each Manager (we don’t need names).<br />
As all Managers are also employees, these IDs will also feature as Emp IDs</td>
                          <td><div class="form-check">
	                        <asp:CheckBox class="form-check-input" ID="chkManagerID" runat="server" />
                            <%--<input class="form-check-input" type="checkbox" id="Checkbox7">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        <tr style="background: #1a2233;">
                          <td>Latest Performance Rating</td>
                          <td>Please provide each employee’s latest Performance Rating. In case an employee has not had any performance reviews yet, please leave blank</td>
                          <td><div class="form-check" style="display:none;">
                          <asp:CheckBox class="form-check-input" ID="chkLatestPer" runat="server" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox8">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it | Click <a href="#" data-toggle="modal" data-target="#modalPerformance"><span style="color:#ff470f">here</span></a> to provide Performance Rating mapping
	                        </label>
	                      </div> 
                          Click <a href="#" data-toggle="modal" data-target="#modalPerformance"><span style="color:#ff470f">here</span></a> to provide Performance Rating mapping
                          </td>
                        </tr>
                        <tr style="display:none;">
                          <td>Year of Last Promotion</td>
                          <td>Please provide the year in which an employee was last promoted. In case an employee has not been promoted yet, please leave blank</td>
                          <td><div class="form-check">
                            <asp:CheckBox class="form-check-input" ID="chkPromotion" runat="server" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox9">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                       <tr >
                          <td>Total Fixed/Gross Pay</td>
                          <td>Please provide the Total Fixed/ Gross Pay for each employee (i.e. do not include any incentives/ variable pay/ benefits/ etc.)</td>
                        <td><div class="form-check">
                        <asp:Label ID="lblCurrency" runat="server" Visible="false"></asp:Label>
                            <asp:CheckBox class="form-check-input" ID="chkTFP" runat="server" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox9">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                      </tbody>


                     


                    </table>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                     <asp:Label ID="lblerrormsg"  runat="server"></asp:Label>
                     </div>
                     <div align="center">
                     <asp:Button ID="btnContinue" Text="Continue" runat="server" 
                             OnClientClick="javascript : return ValidateCheckBoxes();" CssClass="btn btn-warning"
                             onclick="btnContinue_Click" /><br /><br />
                     </div>
                  </div>
                </div>
              </div>
           </div>
           
          </div>
        </section>
        
      </div>

      <div class="modal fade bd-example-modal-lg" id="newModal" tabindex="-1" role="dialog" aria-Labeledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content modal-bg">
        <div class="modal-header">
          <h4 class="modal-title" id="H2">Grade/ Career Level Mapping</h4>
        <asp:LinkButton CssClass="close" ID="LinkButton1" runat="server"  OnClick="closemodal"><span aria-hidden="true">&times;</span></asp:LinkButton>
        
          
        </div>
        <div class="modal-body" style="overflow: auto; font-weight: lighter; height: 600px;">
        <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="lblmsg1" runat="server" Visible="false"></asp:Label>
                                       <asp:Label ID="lblsuccessmsg1" runat="server" Visible="false"  ForeColor="#96a2b4"></asp:Label>
                                    <asp:HiddenField ID="hdnID" runat="server" />
                                    
                                </div>
                            </div>
                            
                                   
                                    <div class="row" style="overflow:auto">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                               <div class="card-body">
                      <div class="table">
                       <asp:updatepanel id="UpdatePanel2" runat="server">
    <contenttemplate>  
                      <table class="table table-sm">
                      <thead>
                        <tr>
                          <th scope="col" class="table-new" style="width:30%">S. No.</th>
                          <th scope="col" class="table-new" style="width:40%">Grade</th>
                         
                        
                          <th scope="col" class="table-new" style="width:30%">Edit/Delete</th>
                         
                        </tr>
                      </thead>
                      <tbody>
                      <tr><td colspan="3" style="height:40px">(S. no. 1 senior-most)</td></tr>
                              <asp:Repeater ID="rptGrade" runat="server" OnItemCommand="rptListGrade_ItemCommand"  onitemdatabound="rptGrade_ItemDataBound">
                        <HeaderTemplate>
                        
                   </HeaderTemplate>
                        <ItemTemplate>
                        <tr>
                         <td style="text-align:center; height:40px;">
                          <asp:Label ID="lblno" runat="server" Text=' <%#Eval("Number")%>'></asp:Label>
                          </td>
                          <td style="height:40px;">
                          <asp:TextBox ID="txt1" CssClass="form-control" Height="30px"  runat="server" Text='<%#Eval("Grade")%>'></asp:TextBox>
                              <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("ID") %>' />
                          </td>
                    
                         
                       
                           <td style="text-align:center; height:40px;">
                     
                                       
                                           <asp:LinkButton ID="lnkremove" runat="server" CommandName="remove" ToolTip="Delete Records" Visible="false"
                                        Width="20px" CommandArgument='<%#Eval("ID") %>'> <i class="fas fa-trash-alt"></i></asp:LinkButton>
                           </td>
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate> 
                 </FooterTemplate>
                        </asp:Repeater>
                         </tbody>  
                         <tfoot>
                         <tr>
                         <td colspan="2">&nbsp;</td>
                         <td style="text-align:center; height:40px"">
                         <asp:LinkButton ID="lnkaddmoreGrade" runat="server" OnClick="lnkaddmoreGrade_Click" CssClass="btn btn-outline-warning add-btn" Text="Add More" style="color:#fff"  ><i class="fa fa-plus"></i></asp:LinkButton>
                         </td>
                         </tr>
                         </tfoot>
                          </table>
                            </contenttemplate>
    <triggers>
    <asp:asyncpostbacktrigger controlid="lnkaddmoreGrade" eventname="Click" />
    </triggers>
    </asp:updatepanel>
                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center; height:40px""><asp:LinkButton ID="lnkSaveGrade"  runat="server" OnClick="lnkSaveGrade_Click" CssClass="btn btn-warning add-btn" Text="Save" style="color:#fff"   OnClientClick="javascript : return ValidateGrade();"></asp:LinkButton></div>
                         </div>
                         </div>
                         </div>
                            </div>
                            </div>
        </div>
       <%-- <div class="modal-footer">
          <button type="button" class="btn btn-info" data-dismiss="modal">ok</button>
        </div>--%>
      </div>
      </div>
      </div>

       <div class="modal fade " id="modalPerformance" tabindex="-1" role="dialog" aria-Labeledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog" >
    
      <div class="modal-content modal-bg">
        <div class="modal-header">
          <h4 class="modal-title" id="H1">Performance Rating</h4>
     <asp:LinkButton CssClass="close" ID="lnkclose" runat="server"  OnClick="closemodalper"><span aria-hidden="true">&times;</span></asp:LinkButton>
        
          
        </div>
        <div class="modal-body" style="overflow: auto; font-weight: lighter; height: 600px;">
        <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="lblmsg" runat="server"  ForeColor="Red" Visible="false"></asp:Label>
                                    <br />
                                      <asp:Label ID="lblsuccessmsg" runat="server"  Visible="false" ForeColor="#96a2b4"></asp:Label>
                                    <asp:HiddenField ID="hdnperid" runat="server" />
                                    
                                </div>
                            </div>
                        
                                    <div class="row" style="overflow:auto">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                               <div class="card-body">
                      <div class="table">
                      <asp:updatepanel id="UpdatePanel1" runat="server">
    <contenttemplate>   
                            
                      <table class="table table-sm" id="maintable">
                      <thead>
                        <tr>
                          <th scope="col" class="table-new" style="width:30%">S. No.</th>
                         
                          <th scope="col" class="table-new" style="width:40%">Performance Rating</th>
                          <th scope="col" class="table-new" style="width:30%">Edit/Delete</th>
                         
                        </tr>
                      </thead>
                      <tbody>
                      <tr><td colspan="3" style="height:40px">(S. no. 1 highest rating)</td></tr>
                              <asp:Repeater ID="rptListPer" runat="server" 
                                  OnItemCommand="rptListCorrect_ItemCommand" 
                                  onitemdatabound="rptListPer_ItemDataBound">
                        <HeaderTemplate>
                        
                   </HeaderTemplate>
                        <ItemTemplate>
                        <tr class="data-contact-person">
                          <td style="text-align:center; height:40px">
                          <asp:Label ID="lblno" runat="server" Text=' <%#Eval("Number")%>'></asp:Label>
                          </td>
                          <td style="height:40px">
                          <asp:TextBox ID="txt1" CssClass="form-control" Height="30px" runat="server" Text='<%#Eval("LatestPerformance")%>'></asp:TextBox></td>
                        <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("ID") %>' />
                           <td style="text-align:center; height:40px">
                             
                                           <asp:LinkButton ID="lnkremove" runat="server" CommandName="remove" ToolTip="Delete Records" Visible="false"
                                        Width="20px" CommandArgument='<%#Eval("ID") %>'> <i class="fas fa-trash-alt"></i></asp:LinkButton>
                                     
                           </td>
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate> 
                 </FooterTemplate>
                        </asp:Repeater>
                         </tbody>  
                         
                         <tfoot>
                         <tr>
                         <td colspan="2">&nbsp;</td>
                         <td style="text-align:center; height:40px">
                      
                         <asp:LinkButton ID="lnkaddmore" runat="server" OnClick="lnkaddmore_Click" CssClass="btn btn-outline-warning add-btn" Text="Add More" style="color:#fff"  ><i class="fa fa-plus"></i></asp:LinkButton>
                      </td>
                         </tr>
                         </tfoot>
                          </table>
                           </contenttemplate>
    <triggers>
    <asp:asyncpostbacktrigger controlid="lnkaddmore" eventname="Click" />
    </triggers>
    </asp:updatepanel>
                        
                           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center; height:40px"><asp:LinkButton ID="lnkSavePerformance" runat="server" OnClick="lnkSavePerformance_Click" CssClass="btn btn-warning add-btn" Text="Save" style="color:#fff"  OnClientClick="javascript : return ValidatePerformance();"></asp:LinkButton></div>
                        

                         </div>
                         </div>
                         </div>
                            </div>
                            </div>

                           
        </div>
       <%-- <div class="modal-footer">
          <button type="button" class="btn btn-info" data-dismiss="modal">ok</button>
        </div>--%>
      </div>

      </div>
      </div>

       
       
      <script type="text/javascript" language="javascript">

          function ValidatePerformance() {


             
          }
          function ValidateGrade() {


              
          }
          function ValidateCheckBoxes() {


              var value = document.getElementById("<%=chkEmpId.ClientID %>").checked;
              var rdoDOB = document.getElementById("<%=rdoDOB.ClientID %>").checked;
              var rdoAge = document.getElementById("<%=rdoAge.ClientID %>").checked;
              var chkDtJoin = document.getElementById("<%=chkDtJoin.ClientID %>").checked;
              var chkGender = document.getElementById("<%=chkGender.ClientID %>").checked;
              var chkDept = document.getElementById("<%=chkDept.ClientID %>").checked;
              
              var chkGrade = document.getElementById("<%=chkGrade.ClientID %>").checked;
              var chkManagerID = document.getElementById("<%=chkManagerID.ClientID %>").checked;
              var chkLatestPer = document.getElementById("<%=chkLatestPer.ClientID %>").checked;
              var chkPromotion = document.getElementById("<%=chkPromotion.ClientID %>").checked;





              if (value == false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Employee ID";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }

              if (rdoDOB == false && rdoAge==false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Age or DOB";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }



              if (chkDtJoin == false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Joining Date";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }


               if (chkGender== false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Gender ";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }
               if (chkDept== false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Department ";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }
               if (chkDesignation== false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Designation ";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }
               if (chkGrade== false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Grade ";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }
               if (chkManagerID== false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check ManagerID";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }
               if (chkLatestPer== false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Latest Performance";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }
              if (chkPromotion == false) {

                  document.getElementById("<%=lblerrormsg.ClientID%>").innerHTML = " Please Check Promotion";
                  document.getElementById("<%=lblerrormsg.ClientID%>").focus();
                  document.getElementById('<%=lblerrormsg.ClientID%>').style.color = 'red';
                  return false;
              }




          }
      
      </script>

       <script type="text/javascript" language="javascript">



           function openPopUp(popupId) {
               $('#' + popupId).modal('show');
           } 


    </script>
      
    <script type="text/javascript">
        

        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop("checked", $(this).prop("checked"));
        });

        $("input[type=checkbox]").click(function () {
            if (!$(this).prop("checked")) {
                $("#selectAll").prop("checked", false);
            }
        });

      </script>
</asp:Content>
