<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.StoreViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register</h2>


    <%:ViewData["Message"] %><br /><br />
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <table width="80%">
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.Name) %><br />
                    <%: Html.TextBoxFor(model => model.Name) %>
                    <%: Html.ValidationMessageFor(model => model.Name) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.Coutry) %><br />
                    <%: Html.TextBoxFor(model => model.Coutry) %>
                    <%: Html.ValidationMessageFor(model => model.Coutry) %>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.NameOfStore) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.NameOfStore) %>
                        <%: Html.ValidationMessageFor(model => model.NameOfStore) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Phone) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Phone) %>
                        <%: Html.ValidationMessageFor(model => model.Phone) %>
                    </div>            
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Address) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Address) %>
                        <%: Html.ValidationMessageFor(model => model.Address) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Phone02) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Phone02) %>
                        <%: Html.ValidationMessageFor(model => model.Phone02) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Address02) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Address02) %>
                        <%: Html.ValidationMessageFor(model => model.Address02) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Email) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Email) %>
                        <%: Html.ValidationMessageFor(model => model.Email) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Zip) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Zip) %>
                        <%: Html.ValidationMessageFor(model => model.Zip) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.WebSite) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.WebSite) %>
                        <%: Html.ValidationMessageFor(model => model.WebSite) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Town) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Town) %>
                        <%: Html.ValidationMessageFor(model => model.Town) %>
                    </div>
                </td>
                <td>
                </td>
            </tr>
        </table>
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
            <%: Html.TextBoxFor(model => model.ShopSize)%>
            <%: Html.ValidationMessageFor(model => model.ShopSize)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.NumberOfShop) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.NumberOfShop) %>
            <%: Html.ValidationMessageFor(model => model.NumberOfShop) %>
        </div>

        <fieldset>
            <legend>If you have a company: </legend>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LegalStructure) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LegalStructure) %>
                <%: Html.ValidationMessageFor(model => model.LegalStructure)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NameOfCompany) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NameOfCompany)%>
                <%: Html.ValidationMessageFor(model => model.NameOfCompany)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.VATNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.VATNumber)%>
                <%: Html.ValidationMessageFor(model => model.VATNumber)%>
            </div>
        </fieldset>
        <p>
            <input type="submit" value="Register" />
        </p>        
    <% } %>

</asp:Content>

