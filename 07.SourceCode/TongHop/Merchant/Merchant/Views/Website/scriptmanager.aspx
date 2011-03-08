<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.ScriptViewModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("SCRIPT_MANAGER")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h1><%: LangText.GetText("SCRIPT_MANAGER")%></h1>
<fieldset class="fieldsetborder">
       
    <table class="tableindex">
    <tr>
    <th> <%: LangText.GetText("SCRIPT_NAME")%>  </th>
    <th>Website</th>
    
    <th><%: LangText.GetText("EDIT") %> </th>
    <th><%: LangText.GetText("DELETE") %></th>
    </tr>
    <% foreach (var s in Model.list)
       {%>
       <tr>
       <td><%: Html.ShortString(s.ScriptName,25) %> </td> 
       <td><%: s.Website.URL %> </td>
      
       <td> <a href="/website/script/<%:s.Id %>"><%:LangText.GetText("EDIT") %></a> </td>
       <td> <a href="/website/deletescript/<%:s.Id %>"><%: LangText.GetText("DELETE") %></a> </td>
       </tr>
    <%} %>
    
    </table>
    </fieldset>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">
<h3>Common Questions </h3>
<ul>
<li><a href="#">How to install Money Pacific on your website? </a></li>
<li><a href="#">What is the script? </a></li>
<li><a href="#">What is the return URL (success and fail)? </a></li>
<li><a href="#">What is a virtual product, and what this check for? </a></li>
</ul>

<div class="readmore"><a href="#">More questions</a></div>


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