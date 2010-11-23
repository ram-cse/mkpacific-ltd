<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<F5_MoneyPacificSite.Models.Agent>" %>

<table>
    <tr>
        <th>
            <%: Html.LabelFor(model => model.Username) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.Username) %>
            <%: Html.ValidationMessageFor(model => model.Username) %>
        </td>
    </tr>

    <tr>
        <th>
            <%: Html.LabelFor(model => model.Password) %>
        </th>
        <td>
            <%: Html.PasswordFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </td>
    </tr>

    <tr>
        <th>
            Status
        </th>
        <td>
            <%: Html.DropDownListFor(model => model.StatusId, 
                    new SelectList(ViewData["AgentStates"] as IEnumerable,
                                    "Id", "Name" , Model.StatusId),"[None]") %>
            <%: Html.ValidationMessageFor(model => model.StatusId) %>
        </td>
    </tr>

    <tr>
        <th>
            <%: Html.LabelFor(model => model.FistName) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.FistName) %>
            <%: Html.ValidationMessageFor(model => model.FistName) %>
        </td>
    </tr>

    <tr>
        <th>
            <%: Html.LabelFor(model => model.LastName) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.LastName) %>
            <%: Html.ValidationMessageFor(model => model.LastName) %>
        </td>
    </tr>

    <tr>
        <th>
            <%: Html.LabelFor(model => model.Address) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.Address) %>
            <%: Html.ValidationMessageFor(model => model.Address) %>
        </td>
    </tr>

    <tr>
        <th>
            <%: Html.LabelFor(model => model.Phone) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.Phone) %>
            <%: Html.ValidationMessageFor(model => model.Phone) %>
        </td>
    </tr>

    <tr>
        <th>
            <%: Html.LabelFor(model => model.Email) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </td>
    </tr>
    
    <tr>
        <th>
            <%: Html.LabelFor(model => model.Comment) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.Comment) %>
            <%: Html.ValidationMessageFor(model => model.Comment) %>
        </td>
    </tr>

</table>
<br />
<input type="submit" value="Create" />



