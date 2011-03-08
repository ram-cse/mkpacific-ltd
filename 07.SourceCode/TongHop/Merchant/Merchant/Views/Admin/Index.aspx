<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.AdminIndexViewModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <h2>General Information</h2>
    <table>
    <tr>
    <th valign="top" style="width: 370px;text-align:center;">Newest Order</th>
    <th valign="top" style="width: 200px;text-align:center;">Newest Problem</th>
    <th valign="top" style="width: 127px;text-align:center;">Newest Webmaster</th>
    <th valign="top" style="text-align:center;">Newest Message</th>
    </tr>
    <tr>
    <td valign="top" style="width: 325px">
    <ul>
    <% int i = 0;
       foreach (var key in Model.listOrder)
       {
           if (i <= 10 && (key.Status == 411 || key.Status == 412))
           {
               i++;
             %>
             <li><a href="/order/details/<%: key.Id %>"><%: key.BuyingId%></a> - <%:key.Date %> - <%:key.Status %></li>
         <%}
           
       } %>
    </ul>
    </td>
    <td valign="top" style="width: 195px;">
         <ul>
        <% i = 0;
           foreach (var key in Model.listOrder)
           {
               if (i <= 10 && (key.Status == 421 || key.Status == 422 || key.Status == 423))
               {
                   i++;
                 %>
                <li><a href="/problem/follow/<%: key.BuyingId%>"><%: key.BuyingId%> </a> - <%:key.Status %></li>
             <%}
            } %>
        </ul>
      </td>
    <td valign="top" style="width: 127px;">
    <ul>
    <%foreach (var key in Model.listWebmaster)
      { %>
      <li><a href="/admin/userdetail/<%:key.Username %>"><%:key.Username %></a></li>
    <%} %>
    </ul>
    </td>
    <td valign="top">
    <ul>
        <%foreach (var key in Model.listMessage.OrderByDescending(o=>o.date))
          {              
        %>
            <%if (key.reference.Length == 15)
              { %>
                   <li><a href="/problem/follow/<%:key.reference %>"> <%:Html.ShortString(key.TextDisplay,100)%> </a> </li>
            <%}else { %>
                    
                    <li><a href="/messenger/create/<%:key.reference %>"><%:Html.ShortString(key.TextDisplay,100) %></a></li>
                    
                  <%} %>
        <%} %>
    </ul>
    </td>
    </tr>
    </table>
    

</asp:Content>
