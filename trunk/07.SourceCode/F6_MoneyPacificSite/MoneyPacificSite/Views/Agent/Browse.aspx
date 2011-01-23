<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" 
Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.AgentListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Browse
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
        <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
        <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
        <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>     

        <script src="/Scripts/jquery.thickbox.js" type="text/javascript"></script>    


        <%--<script type="text/javascript">
            function handleRemove(context) {            
                alert("hello");
                var json = context.get_data();
                alert(json.toString());
                var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

                // Update the page elements
                $('#row-' + data.DeleteId).fadeOut('slow');
                $('#update-message').text("xong roi !...");
            }
            function handleRemove() {
                alert("hello no context");
                var json = context.get_data();
                alert(json.toString());
                var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

                // Update the page elements
                $('#row-' + data.DeleteId).fadeOut('slow');
                $('#update-message').text("xong roi !...");
            }
        </script>--%>

        <div id="update-message"></div>
        <fieldset>
            <legend>List</legend>
            <p>
                <%--<%: Html.ActionLink("Create New", "Create", "Agent") %>--%>
                <%=Html.ActionLink("Create"
                        , "Create"
                        , "Agent"
                        , new { height = 400, width = 300}
                        , new { @class = "thickbox" }) %>
            </p>

            <table>
            <tr>
                <th></th>
                <th>
                    Username
                </th>
                <th>
                    Password
                </th>
                <th>
                    Status
                </th>
                <th>
                    Fist Name
                </th>
                <th>
                    Last Name
                </th>
                <th>
                    Address
                </th>
                <th>
                    Phone
                </th>
                <th>
                    Email
                </th>
                <th>
                    Comment
                </th>
            </tr>

        <% foreach (var item in Model.agents) { %>
    
    
            <tr id="row-<%:item.Id %>">
                <td>
                    <%=Html.ActionLink("Edit"
                        , "Edit"
                        , "Agent"
                        , new { height = 300, width = 300, id = item.Id }
                        , new { @class = "thickbox" }) %>
                
                    <%: Html.ActionLink("Details", "Details", new { id=item.Id })%> |
    
    
                    <%: Ajax.ActionLink("Remove"
                        , "Delete"
                        , new { id = item.Id }
                        , new AjaxOptions { 
                                OnSuccess = "$('#row-' + " + item.Id + ").fadeOut('slow')"
                            }
                        )%>
                </td>
                <td>
                    <%: item.Username %>
                </td>
                <td>
                    ******
                </td>
                <td>
                    <%: Html.DropDownList("StatusId", 
                        new SelectList(Model.agentStates,"Id", "Name",item.StatusId) )%>
                </td>
                <td>
                    <%: item.FistName %>
                </td>
                <td>
                    <%: item.LastName %>
                </td>
                <td>
                    <%: item.Address %>
                </td>
                <td>
                    <%: item.Phone %>
                </td>
                <td>
                    <%: item.Email %>
                </td>
                <td>
                    <%: item.Comment %>
                </td>
            </tr>
    
        <% } %>

        </table>

        </fieldset>
    
        
    
</asp:Content>

