<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<MoneyPacificSite.Models.StoreManager>" %>
    <%: Html.HiddenFor(model => model.Id) %>
          
<table>
    <tr>
        <th><%: Html.LabelFor(model => model.IdShop) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.IdShop) %>
            <%: Html.ValidationMessageFor(model => model.IdShop) %>
        </td>
        <th><%: Html.LabelFor(model => model.Username) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.Username) %>
            <%: Html.ValidationMessageFor(model => model.Username) %>
        </td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Password) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </td>
        <th><%: Html.LabelFor(model => model.Name) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.StatusId) %></th>
        <td>
            <%: Html.DropDownList("StatusId", 
                    new SelectList(ViewData["StoreManagerStates"] as IEnumerable, 
                                    "Id", 
                                    "Code",
                                    Model.StatusId )) %>                
        </td>
        <th><%: Html.LabelFor(model => model.Address) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.Address) %>
            <%: Html.ValidationMessageFor(model => model.Address) %>
        </td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.ManagerPhone) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.ManagerPhone) %>
            <%: Html.ValidationMessageFor(model => model.ManagerPhone) %>
        </td>
        <th><%: Html.LabelFor(model => model.Phone) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.Phone) %>
            <%: Html.ValidationMessageFor(model => model.Phone) %>
        </td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.EmailAlert) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.EmailAlert) %>
            <%: Html.ValidationMessageFor(model => model.EmailAlert) %>
        </td>
        <th><%: Html.LabelFor(model => model.WebSite) %></th>
        <td>
            <%: Html.TextBoxFor(model => model.WebSite) %>
            <%: Html.ValidationMessageFor(model => model.WebSite) %>
        </td>
    </tr>
    <tr>
        <th>
            <%: Html.LabelFor(model => model.Town) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.Town) %>
            <%: Html.ValidationMessageFor(model => model.Town) %>
        </td>
            
        <th>
            <%: Html.LabelFor(model => model.Country) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.Country) %>
            <%: Html.ValidationMessageFor(model => model.Country) %>
        </td>
    </tr>
    <tr>
        <th>
            <%: Html.LabelFor(model => model.StoreInternetAccessId) %>
        </th>
        <td>
            <%: Html.DropDownList("StoreInternetAccessId", 
                new SelectList(ViewData["InternetAccessRoles"] as IEnumerable,
                    "Id" , "Code" , Model.StoreInternetAccessId))%>
        </td>           
            
        <th>
            <%: Html.LabelFor(model => model.CreateDate) %>
        </th>
        <td>
            <%: Html.TextBoxFor(model => model.CreateDate, String.Format("{0:dd-MMM-yyyy}", Model.CreateDate)) %>
            <%: Html.ValidationMessageFor(model => model.CreateDate) %>
        </td>
    </tr>
</table>


