<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Store.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.StoreManagerInformationViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Information
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

    
    <legend><b>Manager Information</b></legend><br /><br />
        
    <table width="100%">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.Name) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.Name) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.Username) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.Username) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.Password) %></th>
                        <td><%:Html.HiddenFor(model=>model.Manager.Password) %>*******</td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.NameOfStore) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.NameOfStore) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.ManagerPhone) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.ManagerPhone) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.Address) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.Address) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.Address2) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.Address2) %></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.Phone) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.Phone2) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.City) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.City) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.Country) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.Country) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.EmailAlert) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.EmailAlert) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.EmailBill) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.EmailBill) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.NameOfCompany) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.NameOfCompany) %></td>
                    </tr>
                    <tr>
                        <th><%:Html.LabelFor(model=>model.Manager.VATNumber) %></th>
                        <td><%:Html.DisplayFor(model=>model.Manager.VATNumber) %></td>
                    </tr>
                </table>                
            </td>
        </tr>
    </table>
    
    <br /><legend><b>List Store</b></legend><br /><br />
    <table width="100%">
        <tr>
            <th>Name</th>
            <th>Phone</th>
            <th>Password</th>
            <th>PINStore</th>
            <th>Email</th>
            <th>Status</th>
            <th>LastTransaction</th>
            <th>---</th>
        </tr>
        <% for (int i = 0; i < Model.ArrUser.Count(); i++)
           { %>
        <tr>
            <td><%:Model.ArrUser[i].Name %></td>
            <td><%:Model.ArrUser[i].Phone %></td>
            <td><%:Model.ArrUser[i].Password %></td>
            <td><%:Model.ArrUser[i].PINStore %></td>
            <td><%:Model.ArrUser[i].Email %></td>
            <td><%:Model.ArrUser[i].Status %></td>
            <td><%:Model.ArrUser[i].LastTransaction %></td>
            <td><input type="button" value="Change PINStore" /></td>
        </tr>
        <%} %>
    </table>

</asp:Content>

