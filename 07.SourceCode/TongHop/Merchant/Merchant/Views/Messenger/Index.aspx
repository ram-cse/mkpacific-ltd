<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.MessengerIndexViewModel>" %>
<%@ Import Namespace="Merchant.Models" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("PACIFIC_MESSENGER")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% MPWebmasterEntities db = new MPWebmasterEntities(); %>
    
    <h1><%:LangText.GetText("ALL_YOUR_MESSAGES")%></h1>

  <fieldset class="fieldsetborder">
    <a href="/messenger/create" class="buttonfloatright"><%:LangText.GetText("SEND_MESSAGE_TO_MONEY_PACIFIC")%></a>
   <br /><br />

    <strong> <%:LangText.GetText("BETWEEN_YOU_AND_MONEY_PACIFIC")%></strong>
   <br /><br />
   <table class="tablecreate">
   <tr>
   <th><%: LangText.GetText("MESSAGEID") %></th>
   <th><%: LangText.GetText("DATE") %></th>
   <th><%: LangText.GetText("MESSAGE_CONTENT") %></th>
   </tr>
    <% int count = 0;
        foreach (var x in Model.chatbox.OrderByDescending(c => c.DateSend))
       { %>
            <% if(count <= 10){ %> <!-- chi hien thi 10 tin nhan moi nhat -->
            <tr>
             <td><a href="/messenger/create/"><%: x.Id%></a></td>
             <td><%: x.DateSend%></td>
             <td><%: Html.ShortString(x.Message, 100)%></td>
             </tr>
            <%} %>
             
    <%} %>
    </table>
 
 <br /><br />


    <strong><%: LangText.GetText("BETWEEN_YOU_AND_CUSTOMER")%></strong>
    <br /><br />

   <table class="tablecreate">
   <tr>
   <th><%: LangText.GetText("MESSAGEID") %></th>
   <th><%: LangText.GetText("DATE") %></th>
   <th><%: LangText.GetText("MESSAGE_CONTENT") %></th>
   </tr>
  
    <%  int i = 0;
        foreach (var y in Model.MessageList.OrderByDescending(o => o.DateSend))
        { %>
        <% 
            i++;
            if (i <= 10)
            { %>
            <tr>
                <td><a href="/problem/follow/<%:y.UserId %>"><%:y.Id%></a></td>
                <td><%: y.DateSend%></td>
                <td><%: Html.ShortString(y.Message1, 100)%></td>
        </tr>

       <%} %>     
    <%} %>
    </table>
</fieldset>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>