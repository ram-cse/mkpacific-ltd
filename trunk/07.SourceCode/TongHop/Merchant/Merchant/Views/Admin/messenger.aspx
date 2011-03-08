<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.AdminIndexViewModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	messenger
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pacific Messenger </h2>
    <div class="button">
        <a href="/messenger/sendWebmaster">SEND MESSAGE TO WEBMASTER</a>
    </div>
   <br /><br />
    <table>
    <tr>
    <th>Message ID</th>
    <th>Date</th>
    <th>Content</th>
    </tr>
        <%foreach (var key in Model.listMessage.OrderByDescending(o=>o.date))
          {              
        %>
        <tr>
            <%if (key.reference.Length == 15)
              { %>
                   <td><a href="/problem/follow/<%:key.reference %>"> <%: key.reference %></a> </td>
                   <td><%: key.date %></td>
                   <td><%: Html.ShortString(key.TextDisplay, 100) %></td>
            <%}else { %>
                    
                    <td><a href="/messenger/create/<%:key.reference %>"><%: key.reference%></a></td>
                    <td><%: key.date %></td>
                    <td><%: Html.ShortString(key.TextDisplay, 100) %></td>
                    
                  <%} %>
        </tr>
        <%} %>
   </table>
    

</asp:Content>
