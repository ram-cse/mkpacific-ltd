<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.StoreManagerAskToBePartnerViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Ask to be Partner
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ask to be Partner</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <table >
            <tr>
                <td colspan="4"><b> >> Ask to be a Partner Store<< </b></td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.Name) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Name) %>
                    <%: Html.ValidationMessageFor(model => model.Name) %>
                </td>
                <th align="left"><%: Html.LabelFor(model => model.Town) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Town) %>
                    <%: Html.ValidationMessageFor(model => model.Town) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.NameOfStore) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.NameOfStore) %>
                    <%: Html.ValidationMessageFor(model => model.NameOfStore) %>
                </td>
                <th align="left"><%: Html.LabelFor(model => model.Country) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Country) %>
                    <%: Html.ValidationMessageFor(model => model.Country) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.Address) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Address) %>
                    <%: Html.ValidationMessageFor(model => model.Address) %>
                </td>
                <th align="left"><%: Html.LabelFor(model => model.Phone) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Phone) %>
                    <%: Html.ValidationMessageFor(model => model.Phone) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.Address2) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Address2) %>
                    <%: Html.ValidationMessageFor(model => model.Address2) %>
                </td>
                <th><%: Html.LabelFor(model => model.Phone2) %></th>
                <td align="left">
                    <%: Html.TextBoxFor(model => model.Phone2) %>
                    <%: Html.ValidationMessageFor(model => model.Phone2) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.Zip) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Zip) %>
                    <%: Html.ValidationMessageFor(model => model.Zip) %>
                </td>
                <th align="left"><%: Html.LabelFor(model => model.Email) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Email) %>
                    <%: Html.ValidationMessageFor(model => model.Email) %>
                </td>
            </tr>
            <tr>
                <th colspan=2  align="left"><%: Html.LabelFor(model => model.WebSite) %></th>
                <td colspan=2>
                    <%: Html.TextBoxFor(model => model.WebSite) %>
                    <%: Html.ValidationMessageFor(model => model.WebSite) %>
                </td>
            </tr>
        </table>
        <fieldset>
            <legend>Information</legend>
            
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Product) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Product) %>
                    <%: Html.ValidationMessageFor(model => model.Product) %>
                </div>
            
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.ShopSize) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.ShopSize) %>
                    <%: Html.ValidationMessageFor(model => model.ShopSize) %>
                </div>
            
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.NumOfShop) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.NumOfShop) %>
                    <%: Html.ValidationMessageFor(model => model.NumOfShop) %>
                </div>
                
        </fieldset>
        <fieldset>
            <legend>If you have a company</legend>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.LegalStructure) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.LegalStructure) %>
                    <%: Html.ValidationMessageFor(model => model.LegalStructure) %>
                </div>
            
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.NameOfCompany) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.NameOfCompany) %>
                    <%: Html.ValidationMessageFor(model => model.NameOfCompany) %>
                </div>
            
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.VATNumer) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.VATNumer) %>
                    <%: Html.ValidationMessageFor(model => model.VATNumer) %>
                </div>          
            
            <p>
                <input type="submit" value="Submit" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

