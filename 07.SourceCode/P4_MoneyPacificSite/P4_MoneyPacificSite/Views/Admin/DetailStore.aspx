<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdminSite.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.Models.StoreManager>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DetailStore
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>DetailStore</h2>
    <p>
        <%: Html.ActionLink("Edit", "EditStore", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "BrowseStore") %>
    </p>
    <% using (Html.BeginForm())
       {%>
        <table>
            <tr>        
                <th>Id</th>
                <td><%: Model.Id %></td>
            </tr>
            <tr>
                <th>Username</th>
                <td><%: Model.Username %></td>
            </tr>
            <tr>        
                <th>Password</th>
                <td><%: Model.Password %></td>
            </tr>
            <tr>
                <th>Name</th>
                <td><%: Model.Name %></td>
            </tr>
            <tr>
                <th>NameOfStore</th>
                <td><%: Model.NameOfStore %></td>
            </tr>
            <tr>
                <th>StatusId</th>
                <td><%: Model.StatusId %></td>
            </tr>
            <tr>
                <th>Address</th>
                <td><%: Model.Address %></td>
            </tr>
            <tr>
                <th>Address2</th>
                <td><%: Model.Address2 %></td>
            </tr>
            <tr>
                <th>Phone</th>
                <td><%: Model.Phone %></td>
            </tr>
            <tr>
                <th>Phone2</th>
                <td><%: Model.Phone2 %></td>
            </tr>
            <tr>
                <th>EmailAlert</th>
                <td><%: Model.EmailAlert %></td>
            </tr>
            <tr>
                <th>EmailBill</th>
                <td><%: Model.EmailBill %></td>
            </tr>
            <tr>
                <th>WebSite</th>
                <td><%: Model.WebSite %></td>
            </tr>
            <tr>
                <th>Zip</th>
                <td><%: Model.Zip %></td>
            </tr>
            <tr>
                <th>Town</th>
                <td><%: Model.Town %></td>
            </tr>
            <tr>
                <th>Country</th>
                <td><%: Model.Country %></td>
            </tr>
            <tr>
                <th>LegalStructure</th>
                <td><%: Model.LegalStructure %></td>
            </tr>
            <tr>
                <th>NameOfCompany</th>
                <td><%: Model.NameOfCompany %></td>
            </tr>
            <tr>
                <th>VATNumber</th>
                <td><%: Model.VATNumber %></td>
            </tr>
            <tr>
                <th>Product</th>
                <td><%: Model.Product %></td>
            </tr>
            <tr>
                <th>ShopSize</th>
                <td><%: Model.ShopSize %></td>
            </tr>
            <tr>
                <th>NumberOfShop</th>
                <td><%: Model.NumberOfShop %></td>
            </tr>
            <tr>
                <th>StoreInternetAccess</th>
                <td><%: Model.StoreInternetAccess %></td>
            </tr>        
        </table>
    <%} %>
</asp:Content>

