<%@ Page Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   <% LangText.Load(Page.User.Identity.Name.ToString()); %>
   <%:LangText.GetText("WELCOME_ACCOUNT_INDEX")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset class="fieldsetborder">
    <h2><%:LangText.GetText("WELCOME") %> <%: ViewData["Name"] %>  back!. What would you like to do today?</h2>
      
      <br /><br />     
     <strong>My Orders</strong>
        <table class="tableindex">
        <tr>
            <th></th>
            <th>Number</th>
            <th>Amount</th>
            <th></th>
        </tr>
                <tr>
            <td>New Order(411)</td>
            <td><%: ViewData["number411"]%></td>
            <td><%: ViewData["total411"]%> VND</td>
            <td><a href="/order/newview" class="btview">See...</a></td>
        </tr>

        <tr>
            <td>On delivery(412)</td>
            <td><%: ViewData["number412"]%></td>
            <td><%: ViewData["total412"]%> VND</td>
            <td><a href="/order/Ondelivery" class="btview">See...</a></td>
        </tr>

        <tr>
            <td>Claim No Delivery (423)</td>
            <td><%: ViewData["number423"]%></td>
            <td><%: ViewData["total423"]%> VND</td>
            <td><a href="/problem/only423" class="btview">See...</a></td>
        </tr>

        <tr>
            <td>Claim Other (42x)</td>
            <td><%: ViewData["number42x"]%></td>
            <td><%: ViewData["total42x"]%> VND</td>
            <td><a href="/problem" class="btview">See...</a></td>
        </tr>

        <tr><td colspan="4">&nbsp;</td></tr>

        <tr>
            <td>History (413)</td>
            <td><%: ViewData["number413"]%></td>
            <td><%: ViewData["total413"]%> VND</td>
            <td><a href="/order/endtran" class="btview">See...</a></td>
        </tr>

        </table><br />

    <strong>My Money</strong>

    <table class="tableindex1">
        <tr>
            <td class="tdindex1"><strong>Total Available</strong></td>
            <td><%: ViewData["Earning"]%> VND</td>
        </tr>
       
        <tr><td colspan="2">&nbsp;</td></tr>
       
        <tr>
            <td></td>
            <td><strong>Net Earning</strong></td>
        </tr>

        <tr>
            <td class="tdindex1">Today</td>
            <td><%: ViewData["todayearning"]%> VND</td>
        </tr>

        <tr>
            <td class="tdindex1">Yesterday</td>
            <td><%:  ViewData["yesterdayearning"]%> VND</td>
        </tr>

        <tr>
            <td class="tdindex1">This month</td>
            <td><%: ViewData["thismonthearning"]%> VND</td>
        </tr>
        <tr>
            <td class="tdindex1">Last month</td>
            <td><%: ViewData["lastmonthearning"]%> VND</td>
        </tr>

        <tr>
            <td class="tdindex1">Total this year</td>
            <td><%:  ViewData["thisyearearning"]%> VND</td>
        </tr>
    </table><br />
   <span class="spanviewmoneyIndex"><a href="/report/details" class="btview">View earning detail...</a></span>
</fieldset>
 
</asp:Content>

<asp:Content ContentPlaceHolderID="SidebarInformation" runat="server">
<h3>Common Questions</h3>
<ul>
<li><a href="#">How to start ?</a></li>
<li><a href="#">How to install Money Pacific on your website?</a></li>
<li><a href="#">How payout working?</a></li>
<li><a href="#">How the first registered website receive 600 000 VND?</a></li>
<li><a href="#">How the rating about your website working?</a></li>
<li><a href="#">How to make money, by sponsoring a new webmaster?</a></li>
<li><a href="#">You need help ?</a></li>
</ul>
<div class="readmore"><a href="">More questions...</a></div>

<br /><br /><br /><br /><br /><br />

<center>
<div class="call">NEED HELP ?
<br/>

You don’t know how to do ...
<br/>

we will help you for FREE<br/>
Phone <span class="phonenumber"><%: ViewData["phone"] %></span> <br/>
Email: <a href="/messenger/create" >PACIFIC MESSENGER</a>
<br />
<span style="font-size:16px;">Y!M: <a href="ymsgr:sendIM?web_moneypacific"><img src="http://opi.yahoo.com/online?u=web_moneypacific&amp;m=g&amp;t=1" border="0" alt="" /> </a></span>

</div>
</center>

</asp:Content>
