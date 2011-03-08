<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentVI.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("VI"); %>
    <%: LangText.GetTextPortal("QUESTION")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">
<center>
<div style="font-size:14px; font-weight:bold; color:#663333">Chức năng dành cho<br /><br />
Khách hàng và Quản lý Khách Hàng...
<br />
<br />
<hr />
<br />
Nếu bạn là cửa hàng đối tác hoặc chủ<br /><br />
website đã đăng ký<br /><br />
<a href="/Account/Login?height=350&amp;width=450" class="thickbox" style="text-decoration:none;"> Đăng nhập tại đây</a>
</div>
<br/>
<hr/>
<span style="font-size:27px; font-weight:bold; color:#663333">LIÊN HỆ</span>
<br /><br />
<span style="font-size:14px;font-weight:bold">
Nếu bạn không thấy câu trả lời<br />
trong danh sách bên cạnh?<br />
Nếu bạn có bất kỳ câu hỏi nào về
<br />
Money Pacific, WebSite <br />
hay đơn đặt hàng của bạn...
</span><br /><br />
<div style="background-color: #FF9933; width: 156px; padding: 8px; font-weight: bold;">Cổng thông tin Liên Hệ chung</div>
<br />
<hr />

<br />
Giao dịch của  bạn được bảo mật bởi<br /><br />
<img src="/Content/Images/verisign.jpg" border="0"/>
<br /><br />
VeriSign Inc.<br /><br />
là nhà cung cấp hạ tầng an ninh mạng hàng đầu thế giới<br /><br />
<span style="color:#663333;font-size:16px;text-align:center">Bảo hiểm giao dịch $250 000 </span>
<br /><br />
<hr />
<br />
<img src="/Content/Images/asian.png" border="0" />
<br /><br /><br /><br />
</center>
</asp:Content>
