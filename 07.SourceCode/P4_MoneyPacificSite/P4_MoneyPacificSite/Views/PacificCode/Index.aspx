<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <%: Html.ActionLink("A. Thông tin chi tiết tài khoản Pacific Code", "ViewDetail", "PacificCode")%> | 
    <%: Html.ActionLink("B. Đổi mã Pacific Code (khi có nghi ngờ bị tiết lộ)","ChangeCode") %>
    <br />
    <%: Html.ActionLink("C. Chuyển tiền cho người khác","SendMoney") %> | 
    <%: Html.ActionLink("D. Tôi không nhận được tin nhắn SMS","SendSMS") %>
    <br />
    <%: Html.ActionLink("Browse","Browse","PacificCode") %>

</asp:Content>
