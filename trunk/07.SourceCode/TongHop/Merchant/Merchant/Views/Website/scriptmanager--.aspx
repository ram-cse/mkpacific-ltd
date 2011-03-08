<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.ScriptViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	scriptmanager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Script Manager</h2>
    <fieldset><legend>Your Script</legend>
    <table>
    <th> Name  </th>
    <th>Website</th>
    <th>Edit </th>
    <th>Delete</th>
    <% foreach (var s in Model.list)
       {%>
       <tr>
       <td><%: s.ScriptName %> </td> 
       <td><%: s.Website.URL %> </td>
       <td> <a href="/website/script/<%:s.Id %>">Edit</a> </td>
       <td> <a href="/website/deletescript/<%:s.Id %>">Delete</a> </td>
       </tr>
    <%} %>
    
    </table>
</asp:Content>
