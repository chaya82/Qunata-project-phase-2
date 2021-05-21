<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Inner.Master" AutoEventWireup="true" CodeBehind="RPT2EquitybyGendert.aspx.cs" Inherits="Quanta.Manager.RPT2EquitybyGendert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- JS Libraies -->

 

  
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-content">
        <section class="section">
          <div class="section-header">
            <h1>TFP Internal Equity by Gender</h1>
            <div class="section-header-breadcrumb">
              <div class="breadcrumb-item active"><a href="#">User</a></div>
              
              <div class="breadcrumb-item">TFP Internal Equity by Gender</div>
            </div>
          </div>
          <div class="section-body" id="content">
<div class="row">
              <div class="col-lg-7 col-md-7 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>TFP Internal Equity by Gender</h4>
                    <br />
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                     <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" DataKeyNames="cal" OnRowDataBound="grdList_RowDataBound" Width="100%">
                     <Columns>
                     <asp:BoundField DataField="grade" HeaderText="Grade" />
                      <asp:BoundField DataField="female" HeaderText="Female" />
                       <asp:BoundField DataField="male" HeaderText="Male" />
                        <asp:BoundField DataField="Non Binary" HeaderText="Non Binary" />
                       <asp:TemplateField Visible="false">
                       <ItemTemplate>
                       <asp:HiddenField ID="hdncal" runat="server" Value='<%#Eval("cal") %>' />
                       </ItemTemplate>
                       </asp:TemplateField>
                     </Columns>
                     </asp:GridView>
                     
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-5 col-md-5 col-sm-12 col-sm-12">
                <div class="card card-height-report">
                  <div class="card-header">
                    <h4>Commentary </h4>
                  </div>
                  <div class="card-body">
                    <div class="recent-report__chart">
                  <p>
                  
              sample sample sample sample sample sample sample sample sample.<br /><br />

  sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample  <br /><br />

  sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample   sample sample sample sample sample sample sample sample sample
     </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            
         

</div>
</section>
</div>

</asp:Content>


