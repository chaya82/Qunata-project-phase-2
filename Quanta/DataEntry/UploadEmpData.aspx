<%@ Page Title="" Language="C#" MasterPageFile="~/DataEntry/Inner.Master" AutoEventWireup="true" CodeBehind="UploadEmpData.aspx.cs" Inherits="Quanta.DataEntry.UploadEmpData" EnableViewState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .table td {
    color: #e2e2e2;
}
    .btn-info 
    {
        color: #fff!important;
    background-color: #0062cc!important;
    border-color: #005cbf!important;
    }
    .btn-info:hover{color:#fff;background-color:#005cbf!important;border-color:#005cbf!important;}

    .btn-danger {
    color: #fff;
    background-color: red;
    border-color: #e60303;
}
.btn-danger:hover{color:#fff;background-color:#e60303!important;border-color:#e60303!important;}

.btn-success 
{
    background-color: green;
    border-color: #065406;
    color: #fff;
}
.btn-success:hover{color:#fff;background-color:#065406!important;border-color:#065406!important;}
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
.input-width1 {width:38%;}
@media only screen and (max-width: 1440px) 
{
    .modal-width {max-width: 70%;}
 .input-width1 {width:38%;}  
 .sm-none {display:block;} 
} 
@media only screen and (max-width: 425px) 
{
    .modal-width {max-width: 100%;}
 .input-width1 {width:100%;} 
 .sm-none {display:none;}  
} 
</style>
<style type="text/css">
   
    .loading
    {
       
        display: none;
       
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>Data Entry</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">Data Entry</div>
            </div>
          </div>
          <div class="section-body">
            <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="card">
                 
                  <div class="card-body">
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12">
                  <p>Please upload your manpower data in the defined data template - click <a id="hrfExcel" runat="server" class="link-blue">here</a> for the blank template. </p>
                  <p><b>Note:</b> You need to upload individual .xls/.xlsx files for each year</p>
                  <p>Please name each file as the 4-digit year ("2019.xls", "2018.xls", etc.)</p>
                  <p>Click <a href="#" data-toggle="modal" data-target="#inst">here</a> for instructions on the data preparation & upload</p>
                  </div>
                  </div>
                  </div>
                  </div>
                  <div class="row">
                  <div class="col-lg-6 col-md-6  col-sm-12 col-xs-12">
                  
                  <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>

                   <asp:Repeater ID="rptFile" runat="server">
                   <ItemTemplate>
                    <div class="row">
                
                  <div class="col-lg-2 col-md-12 col-sm-12">
                 <strong>
                 <asp:Label ID="lblyear" runat="server" Text='<%#Eval("year") %>'></asp:Label>
                :</strong>
                          </div>
                  <div class="col-lg-8 col-md-12 col-sm-12">
                 <div class="form-check">
             <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
	                     </div>
                          </div>
                  
                  </div>
                  <div class="row">&nbsp;</div>
                   </ItemTemplate>
                   </asp:Repeater>
              
                  
                  <div class="row" style="display:none;">
                  <div class="col-lg-12 col-md-12 col-sm-12">
                  <span style="color:Red">*</span> Mandatory
                  </div>
                  </div>
                     <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center">
                  <asp:Button ID="btnImport" CssClass="btn btn-warning"
                        runat="server"  Text="Upload" onclick="btnImport_Click" />
                 
                  </div>
                  </div>
                 </div>
                 
                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 sm-none "  style="text-align:center">
               <div class="loading">
                 <img src="../assets/img/loading.gif" style="width: 30%; padding: 0 0;"  />
              </div>
                 </div>
                 </div>
                 </div>
                  </div>
                </div>
              </div>
           </div>

           <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="card">
                 <div class="card-header">
                    <h4>Progress Bar (Data upload status post validation checks)</h4>
                  </div>
                  <div class="card-body card-type-4">
                  You can check your data for errors & reupload corrected
file(s) below. Note that data quality <75% may adversely impact the
subsequent analysis & report.
                  <asp:Repeater ID="rptProgress" runat="server"  onitemdatabound="rptProgress_ItemDataBound">
                 <ItemTemplate>
                    <div class="row pb-2 pt-3" style="border-bottom: 1px solid rgb(144 144 144 / 56%); ">
              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                 <div class="row">
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 <asp:HiddenField ID="hdncorrect" runat="server" Value='<%#Eval("strcorrect") %>' />
                  <div class="row pt-3 pb-3">
                    <div class="col-auto">
                      <div class="card-square l-bg-green text-white">
                        <i class="fas fa-database"></i>
                      </div>
                    </div>
                    <div class="col">
                    <div class="text-small float-right font-weight-bold text-muted"><span class="text-success"><%#Eval("strcorrect") %>%</span></div>
                    <div class="font-weight-bold">Uploaded data  (<%#Eval("year") %>)</div>
                    <div class="progress" data-height="5" style="height: 5px;">
                      <div class="progress-bar l-bg-green" role="progressbar" data-width='<%#Eval("strcorrect") %>%' aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: <%=strcorrect %>%;"></div>
                    </div>
                    <div class="text-small float-right font-weight-bold text-muted"><%#Eval("strcorrectNo") %></div>
                    </div>
                  </div>
                  </div>
                  </div>
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  <div class="row pt-3 pb-3">
                    <div class="col-auto">
                      <div class="card-square l-bg-cyan text-white">
                        <i class="fas fa-database"></i>
                      </div>
                    </div>
                    <div class="col">
                    <div class="text-small float-right font-weight-bold text-muted"><span class="text-danger"><%#Eval("strwrong") %>%</span></div>
                    <div class="font-weight-bold">Data with issues (<%#Eval("year") %>)</div>
                    <div class="progress" data-height="5" style="height: 5px;">
                      <div class="progress-bar l-bg-cyan" role="progressbar" data-width='<%#Eval("strwrong") %>%' aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" style="width: <%=strwrong %>%;"></div>
                    </div>
                    <div class="text-small float-right font-weight-bold text-muted"><%#Eval("strwrongNo") %></div>
                    </div>
                  </div>
                  </div>
                </div>
                </div>
              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="text-align:center">
                   <div class="row pt-3 pb-3">
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:CheckBox ID="chkcont" runat="server" Text="Use existing data" />
               <%--   <asp:Button ID="btncontinue" CssClass="btn btn-info"  runat="server"  Text="Continue with existing valid data" PostBackUrl="~/Manager/RPTReadRpt.aspx"  />--%>
                  </div>
                  </div>
                 
                  <div class="row pt-3 pb-3">
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <a href='testexport.aspx?yr=<%#Eval("year") %>' style="color:#fff"  class="btn btn-danger" target="_blank">Download & correct invalid data</a>
                 <asp:Button ID="btndownload" CssClass="btn btn-danger"  runat="server"  Text="Download & correct invalid data" onclick="btndownload_Click" Visible="false" />
              </div>
              </div>
              </div>
              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
               
               <div class="row pt-3 pb-3">
                
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 <div class="form-check pl-0" >
                    <asp:Label ID="lblyear" runat="server" Text='<%#Eval("year") %>' Visible="false"></asp:Label>
             <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" style="padding: 4px 15px;
    height: 35px;" />
	                     </div>
                          </div>
                          </div>
                  <div class="row pt-3 pb-3">
                
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  <asp:Button ID="btnImport1" CssClass="btn btn-success"
                        runat="server"  Text="Upload corrected data" onclick="btnImport1_Click" />
                 
                  </div>
                  </div>
              </div>
               </div>
              
                 </ItemTemplate>
                 </asp:Repeater>
                   <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center; padding-top:20px;"><asp:Button ID="btncontinue" CssClass="btn btn-info"  runat="server"  Text="Continue " onclick="btncontinue_Click" Visible="false"   /></div></div>
                </div>
              </div>
           </div>
           </div>

           
        </section>
        
      </div>
     
     <div class="modal fade" id="inst" tabindex="-1" role="dialog" aria-Labeledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-width ">
    
      <!-- Modal content-->
      <div class="modal-content modal-bg">
        <div class="modal-header">
          <h4 class="modal-title" id="H2">Instructions</h4>
          <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span></button>
        
          
        </div>
        <div class="modal-body" style="font-weight: lighter;">
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

                          <asp:CheckBox class="form-check-input" ID="chkEmpId" runat="server" Checked="true" />
	                       <%-- <input class="form-check-input" type="checkbox" id="chkEmpId">--%>
                          
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        <tr style="background: #1a2233;">
                          <td>Date of Birth (dd-mm-yy)<br />Age (yrs)</td>
                          <td>You need to enter either date of birth in dd-mm-yyyy format, or the current age of each employee</td>
                          <td>I will uplod: <div class="form-check">
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
                          <td>Date of joining (dd-mm-yy)</td>
                          <td>You need to enter the Date of Joining for each employee, in dd-mm-yyyy format</td>
                          <td><div class="form-check">
	                        <asp:CheckBox class="form-check-input" ID="chkDtJoin" runat="server" Checked="true" />
                            <%--<input class="form-check-input" type="checkbox" id="Checkbox2">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        <tr style="background: #1a2233;">
                          <td>Gender (Male/Female/Non Binary)</td>
                          <td>Please indicate the gender only as 'Male', 'Female' or 'Non-Binary'</td>
                          <td><div class="form-check">
                            <asp:CheckBox class="form-check-input" ID="chkGender" runat="server" Checked="true" />
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
                          <asp:CheckBox class="form-check-input" ID="chkDept" runat="server" Checked="true" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox4">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        
                        <tr style="background: #1a2233;">
                          <td>Grade/Career Level</td>
                          <td>Please indicate the Grade/ Career Level (and not designation/ job title)</td>
                          <td><div class="form-check"  style="display:none;">
                          <asp:CheckBox class="form-check-input" ID="chkGrade" runat="server" Checked="true" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox6">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it | Click <a href="#" data-toggle="modal" data-target="#newModal">here</a> to provide grade mapping
	                        </label>
	                      </div>
                          Click <a href="#" data-toggle="modal" data-target="#newModal">here</a> to provide grade mapping
                           </td>
                        </tr>
                        <tr>
                          <td>Manager Emp ID</td>
                          <td>Mandatory unique identifier for each Manager (we don’t need names).<br />
As all Managers are also employees, these IDs will also feature as Emp IDs</td>
                          <td><div class="form-check">
	                        <asp:CheckBox class="form-check-input" ID="chkManagerID" runat="server" Checked="true" />
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
                          <asp:CheckBox class="form-check-input" ID="chkLatestPer" runat="server" Checked="true" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox8">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it | Click <a href="#" data-toggle="modal" data-target="#modalPerformance">here</a> to provide Latest Performance Rating mapping
	                        </label>
	                      </div> 
                          Click <a href="#" data-toggle="modal" data-target="#modalPerformance">here</a> to provide Latest Performance Rating mapping
                          </td>
                        </tr>
                        <tr style="display:none;">
                          <td>Year of Last Promotion (Year/NA)</td>
                          <td>Please provide the year in which an employee was last promoted. In case an employee has not been promoted yet, please leave blank</td>
                          <td><div class="form-check">
                            <asp:CheckBox class="form-check-input" ID="chkPromotion" runat="server" Checked="true" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox9">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                        <tr>
                          <td>Total Fixed/Gross Pay</td>
                          <td>Please provide the Total Fixed/ Gross Pay for each employee (i.e. do not include any incentives/ variable pay/ benefits/ etc.)</td>
                        <td><div class="form-check">
                        <asp:Label ID="lblCurrency" runat="server" Visible="false"></asp:Label>
                            <asp:CheckBox class="form-check-input" ID="chkTFP" runat="server" Checked="true" />
	                       <%-- <input class="form-check-input" type="checkbox" id="Checkbox9">--%>
	                        <label class="form-check-label" for="defaultCheck1">
	                          Got it
	                        </label>
	                      </div></td>
                        </tr>
                      </tbody>


                     


                    </table>
                   
                  </div>
                </div>
        </div>
       <%-- <div class="modal-footer">
          <button type="button" class="btn btn-info" data-dismiss="modal">ok</button>
        </div>--%>
      </div>
      </div>
      </div>


          <div class="modal fade bd-example-modal-lg" id="newModal" tabindex="-1" role="dialog" aria-Labeledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
    
      <!-- Modal content-->
      <div class="modal-content modal-bg">
        <div class="modal-header">
          <h4 class="modal-title" id="H1"> Grade / Career Level</h4>
          <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span></button>
        
          
        </div>
        <div class="modal-body" style="overflow: auto; font-weight: lighter; height: 400px;">
        
                            
                                   
                                    <div class="row" style="overflow:auto">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                               <div class="card-body">
                      <div class="table-responsive">
                      <table class="table table-sm">
                      <thead>
                        <tr>
                          <th scope="col" class="table-new">Position</th>
                         
                          <th scope="col" class="table-new">Grade (Highest/Lowest)</th>
                         
                         
                        </tr>
                      </thead>
                      <tbody>
                      
                              <asp:Repeater ID="rptGrade" runat="server" >
                        <HeaderTemplate>
                        
                   </HeaderTemplate>
                        <ItemTemplate>
                        <tr>
                          <td>
                          <asp:Label ID="txt1" runat="server" Text='<%#Eval("Grade")%>'></asp:Label></td>
                          <td><%#Eval("GLevel")%> </td>
                           
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate> 
                 </FooterTemplate>
                        </asp:Repeater>
                         </tbody>   </table>
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

       <div class="modal fade bd-example-modal-lg" id="modalPerformance" tabindex="-1" role="dialog" aria-Labeledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog  modal-lg" >
    
      <div class="modal-content modal-bg">
        <div class="modal-header">
          <h4 class="modal-title" id="H3"> Latest Performance Rating</h4>
          <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span></button>
        
          
        </div>
        <div class="modal-body" style="overflow: auto; font-weight: lighter; height: 375px;">
        <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnperid" runat="server" />
                                    
                                </div>
                            </div>
                            
                                   
                                    <div class="row" style="overflow:auto">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                               <div class="card-body">
                      <div class="table-responsive">
                      <table class="table table-sm">
                      <thead>
                        <tr>
                          <th scope="col" class="table-new">Position</th>
                         
                          <th scope="col" class="table-new">Performance Rating</th>
                        
                         
                        </tr>
                      </thead>
                      <tbody>
                      
                              <asp:Repeater ID="rptListPer" runat="server" >
                        <HeaderTemplate>
                        
                   </HeaderTemplate>
                        <ItemTemplate>
                        <tr>
                          <td>
                          <asp:Label ID="txt1" runat="server" Text='<%#Eval("LatestPerformance")%>'></asp:Label></td>
                          <td><%#Eval("perLevel")%> </td>
                           
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate> 
                 </FooterTemplate>
                        </asp:Repeater>
                         </tbody>   </table>

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
      <div class="modal fade" id="basicModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
          aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                 <img src="../assets/img/loading.gif" style="width: 30%; padding: 10em 0;"  />
              </div>
              <div class="modal-footer bg-whitesmoke br">
                <button type="button" class="btn btn-primary">Save changes</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              </div>
            </div>
          </div>
        </div>
      <script type="text/javascript">

          function liactive(id) {
              $(id).siblings().removeClass('active');
              $(id).addClass('active');
          }
      </script>

      
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var loading = $(".loading");
            loading.show();

        }, 200);
    }

    $("form").submit(function () {
        ShowProgress();
    });
   
</script>
</asp:Content>
