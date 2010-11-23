<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" 
Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.AgentEditViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%: Html.ActionLink("Back to List", "Browse") %>
    </div>

    <h2>Edit</h2>

    <div style="color:Red;"><%: ViewData["message"] %></div>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <%: Html.HiddenFor(model => model.existAgent.Id) %>
    <table>
        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.Username) %>
            </th>
            <td>
                <%: Html.TextBoxFor(model => model.existAgent.Username)%>
                <%: Html.ValidationMessageFor(model => model.existAgent.Username) %>
            </td>
        </tr>

        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.Password) %>
            </th>
            <td>
                <%: Html.PasswordFor(model => model.existAgent.Password) %>
                <%: Html.ValidationMessageFor(model => model.existAgent.Password) %>
            </td>
        </tr>

        <tr>
            <th>
                Status
            </th>
            <td>
                <%: Html.DropDownListFor(model => model.existAgent.StatusId, 
                        new SelectList(Model.agentStates
                                        ,"Id"
                                        ,"Name" 
                                        ,Model.existAgent.StatusId)
                                        ,"[None]") %>

                <%: Html.ValidationMessageFor(model => model.existAgent.StatusId) %>
            </td>
        </tr>

        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.FistName) %>
            </th>
            <td>
                <%: Html.TextBoxFor(model => model.existAgent.FistName) %>
                <%: Html.ValidationMessageFor(model => model.existAgent.FistName) %>
            </td>
        </tr>

        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.LastName) %>
            </th>
            <td>
                <%: Html.TextBoxFor(model => model.existAgent.LastName) %>
                <%: Html.ValidationMessageFor(model => model.existAgent.LastName) %>
            </td>
        </tr>

        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.Address) %>
            </th>
            <td>
                <%: Html.TextBoxFor(model => model.existAgent.Address) %>
                <%: Html.ValidationMessageFor(model => model.existAgent.Address) %>
            </td>
        </tr>

        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.Phone) %>
            </th>
            <td>
                <%: Html.TextBoxFor(model => model.existAgent.Phone) %>
                <%: Html.ValidationMessageFor(model => model.existAgent.Phone) %>
            </td>
        </tr>

        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.Email) %>
            </th>
            <td>
                <%: Html.TextBoxFor(model => model.existAgent.Email) %>
                <%: Html.ValidationMessageFor(model => model.existAgent.Email) %>
            </td>
        </tr>
    
        <tr>
            <th>
                <%: Html.LabelFor(model => model.existAgent.Comment) %>
            </th>
            <td>
                <%: Html.TextBoxFor(model => model.existAgent.Comment) %>
                <%: Html.ValidationMessageFor(model => model.existAgent.Comment) %>
            </td>
        </tr>

    </table>
        <p>
            <input type="submit" value="Save" />
        </p>
    <% } %>


</asp:Content>

