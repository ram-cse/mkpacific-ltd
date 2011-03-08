<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.AccountIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <h2>Welcome <%: ViewData["Name"] %></h2>
   <b> Account Type:</b> <%if(ViewData["AccountType"].ToString() == "0"){ %>
    Personal
    <%} else if(ViewData["AccountType"].ToString() == "1"){%>
    Business
    <%} %>
    <p>
   <b> Total Balance: </b><%:ViewData["Earning"]%>  <%:ViewData["Currency"]%>
    <ul>
    <%foreach (var x in Model.listOrder)
      { %>
       <%if(x.Status != 413){ %>
      <li><a href="/order/details/<%:x.Id %>"><%:x.BuyingId %></a> : <%: x.Amount.ToString("n0") %> VND - Pending...(comming soon)</li>
      <%} %>
     <%} %>
    </ul>
    </p>
    <table>
        <tr>
            <th>Newest Order</th>
            <th>Order On Delivery</th>
            <th>Order Problems</th>
        </tr>
    <tr>
        <td>
            <ul>
            <%foreach (var o in Model.listOrder)
              {
                  %>
     
              <%if(o.Status == 411){ %>
              <li><a href="/order/details/<%:o.Id %>"> <%: o.Name %> </a>- <%: o.Website.URL %> - <%:o.BuyingId %> - <%: o.Amount.ToString("n0")%> VND</li>
              <%} %>

            <%} %>
            </ul>
        </td>

          <td>
            <ul>
             <%foreach (var o in Model.listOrder)
              { %>
     
              <%if(o.Status == 412){ %>
              <li><a href="/order/details/<%:o.Id %>"><%: o.Name %> </a>- <%: o.Website.URL %> - <%: o.Amount.ToString("n0") %> VND</li>
              <%} %>

            <%} %>
    
            </ul>

          </td>
          <td>
          <ul>
             <%foreach (var o in Model.listOrder)
              { %>
     
              <%if(o.Status == 423){ %>
              <li><a href="/order/details/<%:o.Id %>"><%: o.Name %> </a>- <%: o.Website.URL %> - <%: o.Amount.ToString("n0") %> VND</li>
              <%} %>

            <%} %>
          </ul>
          
          </td>

    </tr>
    </table>
</asp:Content>
