<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdminSite.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.Models.StoreManager>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditStore
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditStore</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>       
                
        <%: Html.EditorFor(model => Model) %>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

