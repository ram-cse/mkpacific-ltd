<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentEN.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("EN"); %>
    <%: LangText.GetTextPortal("QUESTION")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">
<center>
<div style="font-size:14px; font-weight:bold; color:#663333">Customer function<br /><br />
and customer manager...
<br />
<br />
<hr />
<br />
If you are a store partner or a<br /><br />
website already registered<br /><br />
<a href="/Account/Login?height=350&amp;width=450" class="thickbox" style="text-decoration:none;"> Login here</a>
</div>
<br/>
<hr/>
<span style="font-size:27px; font-weight:bold; color:#663333">CONTACT US</span>
<br /><br />
<span style="font-size:14px;font-weight:bold">
You don’t find the answer <br />
in this list ?<br />
If you have any question about
<br />
Money Pacific, the Web Site <br />
or your order...
</span><br /><br />
<div style="background-color: #FF9933; width: 156px; padding: 8px; font-weight: bold;">Pacific Contact for All</div>
<br />
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
<img src="/Content/Images/asian.png" border="0" />
<br /><br /><br /><br />
</center>
</asp:Content>
