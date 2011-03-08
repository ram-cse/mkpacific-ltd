<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentEN.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("EN"); %>
    <%: LangText.GetTextPortal("ABOUT_SECURITY")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">


<br />
<center>
<img src="/Content/Images/security1.jpg" border="0" /><br /><br />
<strong>Money pacific use the most <br /><br />
advance solution for security.<br /><br />
Our system is protect buy <br /><br />
7 security layers, and nobody succeed<br /><br />
to break even the fisrt<br /><br />

<hr />

<br />
The transaction are secure  by<br /><br />
<img src="/Content/Images/verisign.jpg" border="0"/>
<br /><br />
VeriSign Inc.<br /><br />
is the trusted provider of internet<br /><br />
infrastructure security service<br /><br />
<span style="color:#663333;font-size:16px;text-align:center">$ 250 000 of warranty </span>
<br /><br />
<hr />
<br />
Data security center oversea<br /><br />
<img src="/Content/Images/security2.jpg" border="0" /><br /><br />
<img src="/Content/Images/ovh.jpg" border="0" /><br /><br /><br />
</strong>
</center>

</asp:Content>
