<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.EarningViewModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("MONEY_OVERVIEW")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1> <%: LangText.GetText("MONEY_OVERVIEW")%></h1>

<fieldset class="fieldsetborder">

<p><%: LangText.GetText("THIS_IS_THE_PAYOUT_AND_EARNING_DETAILS_PAGE")%></p>
<br />
<strong><%: LangText.GetText("EARNING")%></strong>
<table class="tableindex">
<tr>
<td>Total</td>
<td><%: ViewData["totalEarning"]%> VND</td>
<td></td>
</tr>


<tr>
<td>Pending</td>
<td><%: ViewData["pending"]%> VND</td>
<td></td>
</tr>

<tr>
<td>Lock for claim</td>
<td><%: ViewData["problem"]%> VND</td>
<td><a href="/problem" class="btview">Details</a></td>
</tr>

<tr>
<td>Total Available</td>
<td><%: ViewData["MoneyAvailable"]%> VND</td>
<td><a href="/report/setWithdraw" class="btview">Payout Now</a><br />(Minimum <%: ViewData["limitedWidthDraw"]%> VND)</td>
</tr>
</table>
<br /><br />
<strong>Total details</strong>
    <table class="tableindex1">
               
        <tr>
            <td></td>
            <td><strong>Total</strong></td>
        </tr>

        <tr>
            <td class="tdindex1">Today</td>
            <td><%: ViewData["todayearning"]%> VND</td>
        </tr>

        <tr>
            <td class="tdindex1">Yesterday</td>
            <td><%: ViewData["yesterdayearning"]%> VND</td>
        </tr>

        <tr>
            <td class="tdindex1">This month</td>
            <td><%: ViewData["thismonthearning"]%> VND </td>
        </tr>
        <tr>
            <td class="tdindex1">Last month</td>
            <td><%: ViewData["lastmonthearning"]%> VND</td>
        </tr>

        <tr>
            <td class="tdindex1">Total this year</td>
            <td><%: ViewData["thisyearearning"]%> VND</td>
        </tr>
    </table><br />
   

</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">
<h3>Common Questions </h3>
<ul>
<li><a href="/faq">How payout working?</a></li>
<li><a href="/faq">Why payout button not activated?</a></li>
</ul>
<div class="readmore"><a href="#">More questions</a></div>


</asp:Content>