<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Store Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Browse Genres</h3>
    <h2>Store Home</h2>

    <p>Select from <%: Model.NumberOfGenres %> genres:</p>
    <ul>
        <% foreach (string genreName in Model.Genres)
           {%>
           <li><%:genreName %></li>
        <%} %>
    </ul>

</asp:Content>
