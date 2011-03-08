<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentVI.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("VI"); %>
    <%: LangText.GetTextPortal("ABOUT_SECURITY")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">


<br />
<center>
<img src="/Content/Images/security1.jpg" border="0" /><br /><br />
<strong>

Money Pacific sử dụng giải pháp <br /><br />hiện đại nhất 
về BẢO MẬT<br /><br />
Hệ thống của chúng tôi được bảo vệ <br /><br />
bởi 7 tầng Bảo Mật, không ai có thể <br /><br />
BẺ hay Crack cho dù là tầng đầu tiên<br /><br />

<hr />

<br />
Giao dịch được bảo mật bởi<br /><br />
<img src="/Content/Images/verisign.jpg" border="0"/>
<br /><br />
VeriSign Inc.<br /><br />
là nhà cung cấp về cơ chế bảo mật<br /><br /> uy tín nhất trên Internet hiện giờ<br /><br />
<span style="color:#663333;font-size:16px;text-align:center">Bảo hiểm lên đến $250 000 </span>
<br /><br />
<hr />
<br />
Trung Tâm Bảo Mật dữ liệu ở Châu Âu<br /><br />
<img src="/Content/Images/security2.jpg" border="0" /><br /><br />
<img src="/Content/Images/ovh.jpg" border="0" /><br /><br /><br />
</strong>
</center>

</asp:Content>
