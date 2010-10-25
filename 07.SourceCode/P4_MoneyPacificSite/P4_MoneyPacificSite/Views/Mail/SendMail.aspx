<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StoreManager.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.Models.Mail>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SendMail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SendMail</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
       <%:ViewData["Message"] %><br /><br />
       <table border="0">
                <tr>
                    <td>
                        <%: Html.LabelFor(model => model.Subject) %>
                    </td>
                    <td>
                        <%: Html.TextBoxFor(model => model.Subject) %>
                        <%: Html.ValidationMessageFor(model => model.Subject) %>
                    </td>
                </tr>
                <!--tr>
                    <td>< %: Html.LabelFor(model => model.To) %></td>
                    <td>
                        < %: Html.TextBoxFor(model => model.To) %>
                        < %: Html.ValidationMessageFor(model => model.To) %>
                    </td>
                </tr>
                <tr>
                    <td>< %: Html.LabelFor(model => model.From) %></td>
                    <td>
                        < %: Html.TextBoxFor(model => model.From) %>
                        < %: Html.ValidationMessageFor(model => model.From) %>
                    </td>
                </tr-->
                <tr>
                    <td colspan="2"><%: Html.LabelFor(model => model.Body) %></td>
                </tr>
                <tr><td colspan="2">
                        <%: Html.TextAreaFor(model => model.Body,10,100,null) %>
                        <%: Html.ValidationMessageFor(model => model.Body) %>
                    </td>
                </tr>
            </table>
            <p>
                <input type="submit" value="Send" />
            </p>

    <% } %>

   

</asp:Content>

