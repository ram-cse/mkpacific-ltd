<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.OrderNewViewModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("END_TRANSACTION_413")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: LangText.GetText("LIST_OF_END_TRANSACTION_ORDERS")%></h1>
     <fieldset class="fieldsetborder">
    <table class="tableorder">
    
    <tr>
    <th><%: LangText.GetText("BUYINGID") %></th>
   <%-- <th><%: LangText.GetText("SCRIPT_NAME") %></th>--%>
    <th><%: LangText.GetText("WEBSITE") %></th>
    <th><%: LangText.GetText("AMOUNT") %></th>
    <%--<th><%: LangText.GetText("DATE") %></th>--%>
    <%--<th><%: LangText.GetText("STATUS") %></th>--%>
    </tr>
     <% int count = Model.list.Count;
       if (count > 0)
       { 
        %> 
            <%foreach (var x in Model.list.OrderByDescending(o=>o.Date))
              { %>
              <tr>
              <td><a href="/order/details/<%:x.Id %>"><%:x.BuyingId %></a></td>
            <%--  <td><%: x.Name %></td>--%>
              <td><%: x.Website.URL %></td>
              <td><%: x.Amount.ToString("n0") %> VND</td>
            <%--  <td><%: x.Date %></td>--%>
             <%-- <td><%: LangText.GetText("END_TRANSACTION_413")%></td>--%>
              </tr>
            <%} %>
    <%} else {%>
    <tr>
       <td colspan="3" style="text-align:center;"><span style="color:Red;"><%: LangText.GetText("NO_DATA") %></span></td>
       </tr>
    <%} %>
    </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>