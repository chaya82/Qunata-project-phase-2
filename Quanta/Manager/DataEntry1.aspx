<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="DataEntry1.aspx.cs" Inherits="Quanta.Manager.DataEntry1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    /* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

/* Firefox */
input[type=number] {
  -moz-appearance: textfield;
}
    .percent 
    {
        position: absolute;
    top: 12px;
    right: 30px;
    }
#label {margin-left:5px;}

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
<asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
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
                  <div class="col-lg-12 col-md-12 col-sm-12">
                  <h5>Please provide some more details about your organization.</h5>                  <p style="background: #fffdfd; padding: 0 5px; color: #ff470f; font-weight: bold; border-radius: 5px;">Select the options that best describe your nature of business.</p>
                  </div>
                  </div>
                  <div class="card border">
                 <div class="card-body">
                
                 <asp:CheckBoxList ID="chknetureList" runat="server" RepeatColumns="4"></asp:CheckBoxList>
                 

                   <div class="row">
                   <asp:Repeater ID="rptChlList" runat="server">
                   <ItemTemplate>
                   <div class="col-lg-3 col-md-12 col-sm-12">
                 <div class="form-check">
                 <asp:CheckBox  ID="chk1" runat="server" Checked='<%#Convert.ToBoolean(Eval("nat")) %>'  CssClass="form-check-label"  Text=' <%#Eval("name") %>'  />
                  <asp:HiddenField ID="hdnid" runat="server"  Value=' <%#Eval("id") %>'/>
	                        <%--<input class="form-check-input" type="checkbox" id="Checkbox1" checked="checked">
	                        <label class="form-check-label" for="defaultCheck1">
	                          <%#Eval("name") %>
	                        </label>--%>
	                      </div>
                          </div>
                   </ItemTemplate>
                   </asp:Repeater>
                     <div class="col-lg-6 col-md-12 col-sm-12">
                  <asp:DropDownList ID="ddlIndustries" runat="server" onchange="showtxt()" CssClass="form-control"></asp:DropDownList>

                  </div>
                         <div class="col-lg-6 col-md-12 col-sm-12">
                      <asp:TextBox ID="txtother" runat="server" ClientIDMode="Static" name="other" style="display:none;" CssClass="form-control"></asp:TextBox>
                      </div>
                          </div>
                  </div>
                  </div>
             
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12">
                  <p>Please provide the following data for your organization.</p>
                  </div>
                  </div>

                  <div class="card border">
                  <asp:UpdatePanel ID="upd" runat="server"><ContentTemplate>
                 <div class="card-body">
                      
                 
                  <div class="row">
                  <div class="col-lg-6 col-md-12 col-sm-12">
                  <strong>DATA (Select the latest year for which you are giving information)</strong>
                  </div>
                  <div class="col-lg-2 col-md-12 col-sm-12">
                
                  <asp:DropDownList ID="ddlfyear" runat="server" AutoPostBack="true" 
                          CssClass="form-control" onselectedindexchanged="ddlfyear_SelectedIndexChanged">
                          <asp:ListItem Value="">Select First Year</asp:ListItem>
                  <asp:ListItem>2019</asp:ListItem>
                  <asp:ListItem>2018</asp:ListItem>
                  <asp:ListItem>2017</asp:ListItem>
                  </asp:DropDownList>
	                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlfyear" 
                                     Display="Dynamic" ErrorMessage="First Year is required." ToolTip="First Year is required."   ForeColor="Red"
                                     ValidationGroup="OrgrValidationGroup"></asp:RequiredFieldValidator>       
                  </div>
                  <div class="col-lg-2 col-md-12 col-sm-12">
                  <strong><asp:Label ID="lblyr1" CssClass="form-control" runat="server"></asp:Label></strong>
                  </div>
                  <div class="col-lg-2 col-md-12 col-sm-12">
                   <strong><asp:Label ID="lblyr2" CssClass="form-control" runat="server"></asp:Label></strong>
                  </div>
                  </div>

                     <div class="row">&nbsp;</div>
                  <div class="row">
                  <div class="col-lg-6 col-md-12 col-sm-12">Turnover / Revenues  in <asp:Label ID="lblcurrency" runat="server"></asp:Label> (<a href="#" data-toggle="modal" data-target="#newModal"><span style="color:#ff470f">change currency</span></a>)</div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtturn1" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"  required  ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtturn2" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"   ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtturn3" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"   ></asp:TextBox></div>
                  </div>
                  <div class="row">&nbsp;</div>
                  <div class="row">
                  <div class="col-lg-6 col-md-12 col-sm-12">Profit in <asp:Label ID="lblcurrency1" runat="server"></asp:Label></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtProfit1" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"  required ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtProfit2" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"   ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtProfit3" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"   ></asp:TextBox></div>
                  </div>
                  <div class="row">&nbsp;</div>
                    <div class="row">
                  <div class="col-lg-6 col-md-12 col-sm-12">Wage Bill in <asp:Label ID="lblcurrency2" runat="server"></asp:Label></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtWage1" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"  required ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtWage2" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"   ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtWage3" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"   ></asp:TextBox></div>
                  </div>
                    <div class="row">&nbsp;</div>
                  <div class="row">
                  <div class="col-lg-6 col-md-12 col-sm-12">Head Count</div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtHeadCount1" runat="server" CssClass="form-control"  min="0" pattern="[0-9]" oninput="this.value = Math.round(this.value);"   type="number" step="1"  required ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtHeadCount2" runat="server" CssClass="form-control"  min="0"  type="Number" step="1"  pattern="[0-9]" oninput="this.value = Math.round(this.value);" ></asp:TextBox></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtHeadCount3" runat="server" CssClass="form-control"  min="0"  type="Number" step="1"  pattern="[0-9]" oninput="this.value = Math.round(this.value);" ></asp:TextBox></div>
                  </div>
                
                
                  <div class="row">&nbsp;</div>
                  <div class="row">
                  <div class="col-lg-6 col-md-12 col-sm-12">Attrition % (no. of employees who left/total employees head count for the year</div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtAttrition1" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"  required></asp:TextBox><label><span class="percent">%</span></label></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtAttrition2" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01" ></asp:TextBox><label><span class="percent">%</span></label></div>
                  <div class="col-lg-2 col-md-12 col-sm-12"><asp:TextBox ID="txtAttrition3" runat="server" CssClass="form-control"  pattern="^\d+(?:\.\d{1,2})?$" min="0"  type="Number" step="0.01"   ></asp:TextBox><label><span class="percent">%</span></label></div>
                  </div>
                  </div>
                  
                  
                  
                  </ContentTemplate></asp:UpdatePanel>
                  </div>
                  
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12">
               
                  </div>
                  </div>
                  <div class="row">
                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                     <asp:Label ID="lblerrormsg"  runat="server" ForeColor="Red"></asp:Label>
                     </div>
                  </div>
                  <div class="row">
                  <div class="col-lg-12 col-md-12 col-sm-12" style="text-align:center">
                  <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="btn btn-warning"  ValidationGroup="OrgrValidationGroup"
                          onclick="btnContinue_Click" />
                  
                  </div>
                  </div>
                  </div>
                </div>
              </div>
           </div>
           
          </div>
        </section>
        <div class="modal fade" id="newModal" tabindex="-1" role="dialog" aria-Labeledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content modal-bg">
        <div class="modal-header">
        <h4 class="modal-title" id="H2">Change Currency</h4>
          <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span></button>
          
        </div>
        <div class="modal-body" style="overflow: auto; font-weight: lighter;">
        <div class="row">
                
                  <div class="col-lg-12 col-md-12 col-sm-12">
                  <strong>Select Currency</strong><br />
                  <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="true" 
                          CssClass="form-control" onselectedindexchanged="ddlCurrency_SelectedIndexChanged">
                          <asp:ListItem Value="">Select Currency</asp:ListItem>
                  <asp:ListItem>USD</asp:ListItem>
                  <asp:ListItem>INR</asp:ListItem>
                  <asp:ListItem>AUD</asp:ListItem>
                   <asp:ListItem>GBP</asp:ListItem>
                    <asp:ListItem>OMR</asp:ListItem>
                     <asp:ListItem>SAR</asp:ListItem>
                      <asp:ListItem>SGD</asp:ListItem>
                       <asp:ListItem>EUR</asp:ListItem>
                  </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="OrgnaisationRequired" runat="server" ControlToValidate="ddlCurrency" 
                                     Display="Dynamic" ErrorMessage="Currency is required." ToolTip="Currency is required."   ForeColor="Red"
                                     ValidationGroup="OrgrValidationGroup"></asp:RequiredFieldValidator>
	                       
                  </div>

                  </div>
        </div>
        
      </div>
      
    </div>
  </div>
      </div>
      <script>
          $(document).ready(function () {
              $('#DataEntry').addClass('active');
          });
          function showtxt() {
              if ($("#ContentPlaceHolder1_ddlIndustries").val() == "-1") {
                  document.getElementById('txtother').style.display = 'block'
              }
              else {
                  document.getElementById('txtother').style.display = 'none'
              }
          }
</script>
</asp:Content>
