<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.OrderNewViewModel>" %>
<%@ Import Namespace="Merchant.Models" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.GetText(Page.User.Identity.Name); %>
    <%: LangText.GetText("PROBLEM_MANAGER") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% MPWebmasterEntities db = new MPWebmasterEntities(); %>
    
    <h1><%: LangText.GetText("LIST_OF_ORDERS_PROBLEMS")%></h1>

    <fieldset class="fieldsetborder">
    <table class="tableindexproblem">
     <tr>
    <th><%: LangText.GetText("BUYINGID") %></th>
   <%-- <th><%: LangText.GetText("SCRIPT_NAME") %></th>--%>
   <%-- <th><%: LangText.GetText("WEBSITE") %></th>--%>
    <th><%: LangText.GetText("AMOUNT") %></th>
    <th><%: LangText.GetText("DATE") %></th>
    <th><%: LangText.GetText("REASON") %></th>
   <%-- <th><%: LangText.GetText("STATUS") %></th>--%>
    
    </tr>
    <%foreach (var x in Model.list)
      {
          string status_Report="";
          if (x.Status == 421)
              status_Report = LangText.GetText("DELIVERY_WITH_LOW_QULITY");
          else if (x.Status == 422)
              status_Report = LangText.GetText("DELIVERY_BROKEN");
          else if (x.Status == 423)
              status_Report = LangText.GetText("NOT_DELIVERY");
              
          
          %>
      <tr>
      <td><a href="/problem/follow/<%:x.BuyingId %>"><%:x.BuyingId %></a></td>
      <%--<td><%: x.Name %></td>--%>
      <%--<td><%:x.Website.URL %></td>--%>
      <td><%:x.Amount.ToString("n0") %> VND</td>
      <td><%: x.Date %></td>
      <td><%: status_Report %></td>
      <%--<td><%:LangText.GetText("CUSTOMER_REPORT_PROBLEM")%></td>--%>
       </tr>
    <%} %>

    </table>


    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>something here</center>
</asp:Content>