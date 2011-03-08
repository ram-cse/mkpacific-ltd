<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.RegisterModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("BUSINESS_REGISTER")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <h1><%:LangText.GetText("CREATE_A_BUSSINESS_ACCOUNT")%></h1>
   
    <p>
        <%:LangText.GetText("PASSWORDS_ARE_REQUIRED_TO_BE_A_MINIMUM_OF")%> <%: ViewData["PasswordLength"] %> <%:LangText.GetText("CHARACTERS_IN_LENGTH")%>
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, LangText.GetText("ACCOUNT_CREATION_WAS_UNSUCCESSFUL._PLEASE_CORRECT_THE_ERRORS_AND_TRY_AGAIN"))%>
        <div>
            <fieldset class="fieldsetborder">
                <legend><%:LangText.GetText("ACCOUNT_INFORMATION")%></legend>
                 <table class="margin-left15">
                    <tr>
                        <td>
                             <%:LangText.GetText("COMPANY_NAME")%>
                        </td>
                        <td>
                            <%: Html.EditorFor(m=>m.CompanyName) %>
                        </td>
                        <td>
                            <%:LangText.GetText("USERNAME") %>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(m => m.UserName) %>
                            <%: Html.ValidationMessageFor(m => m.UserName) %>
                        </td>

                        </tr>
                       
                        <tr>
                        <td>
                            <%:LangText.GetText("PASSWORD") %>
                        </td>
                        <td>
                            <%: Html.PasswordFor(m => m.Password) %>
                            <%: Html.ValidationMessageFor(m => m.Password) %>
                        </td>
                        <td>
                             <%: LangText.GetText("CONFIRM_PASSWORD")%>
                        </td>
                        <td>
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                    </td>
               </tr>

               <tr>             
                <td>
                    <%: Html.LabelFor(m => m.Email) %>
               </td>
               <td>
                    <%: Html.TextBoxFor(m => m.Email) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
              </td>
              <td>
                    <%:LangText.GetText("PHONE") %>
              </td>
              <td>
                    <%: Html.TextBoxFor(m => m.Phone) %>
                    <%: Html.ValidationMessageFor(m => m.Phone) %>
              </td>
              </tr>

                  <tr>
                        <td>
                                <%: Html.LabelFor(m => m.TaxCode) %>
                        </td>

                        <td>
                            <%: Html.TextBoxFor(m => m.TaxCode) %>
                            <%: Html.ValidationMessageFor(m => m.TaxCode) %>
                        </td>
                    
                        <td></td>
                        <td></td>
                  </tr>

              </table>
                 <p>
                    <input type="submit" value="<%:LangText.GetText("REGISTER") %>" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>

<asp:Content ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>