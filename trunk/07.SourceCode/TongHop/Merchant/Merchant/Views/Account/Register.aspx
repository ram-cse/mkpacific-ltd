<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("REGISTER")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%:LangText.GetText("REGISTER_A_NEW_ACCOUNT")%></h1>
    <fieldset class="fieldsetborder">
    <center>
    <table>
    <tr>
    <td>
    <strong><%:LangText.GetText("PERSONAL_REGISTER")%></strong><br />
    <%:LangText.GetText("FOR_WEBMASTER_WHO_IS_PERSONAL")%>.<br /><br />
    <a href="/Account/pregister"><%:LangText.GetText("GET_START_NOW")%></a>
    </td>
    
    <td>
    <strong><%:LangText.GetText("BUSINESS_REGISTER")%></strong><br />
    <%:LangText.GetText("FOR_WEBMASTER_WHO_IS_BUSINESS")%>.<br /><br />
    <a href="/Account/bregister" ><%:LangText.GetText("GET_START_NOW")%></a>
    </td>
    </tr>
    </table>

    </fieldset>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>