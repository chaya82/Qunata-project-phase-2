<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrgInfo1.aspx.cs" Inherits="Quanta.Admin.OrgInfo1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>Please Provide some more details about you  Organisation </p>
<p>Nature Of Bussiness</p>
<p>
<asp:CheckBoxList ID="chknetureList" runat="server" RepeatColumns="4"></asp:CheckBoxList>
</p>
<p>
<div class="row">

<div ></div>
</div>
</p>
</asp:Content>
