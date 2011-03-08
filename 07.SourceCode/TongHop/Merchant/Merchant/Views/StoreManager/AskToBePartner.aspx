<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentVI.Master" Inherits="System.Web.Mvc.ViewPage<MPDataAccess.StoreManager>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AskToBePartner
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ask to be Partner</h2>
   
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

       <fieldset>
            <legend>Information</legend>
                    <table>
                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Town) %>
                            </td>

                            <td>
                                <%: Html.TextBoxFor(model => model.Town) %>
                                <%: Html.ValidationMessageFor(model => model.Town) %>
                            </td>
                        </tr>

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.NameOfStore) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.NameOfStore) %>
                                <%: Html.ValidationMessageFor(model => model.NameOfStore) %>
                            </td>
                        </tr>
                    

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Country) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.Country) %>
                                <%: Html.ValidationMessageFor(model => model.Country) %>
                            </td>
                        </tr>

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Address) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.Address) %>
                                <%: Html.ValidationMessageFor(model => model.Address) %>
                            </td>
                        </tr>

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Phone) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.Phone) %>
                                <%: Html.ValidationMessageFor(model => model.Phone) %>
                            </td>
                        </tr>

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Address2) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.Address2) %>
                                <%: Html.ValidationMessageFor(model => model.Address2) %>
                             </td>
                        </tr>

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Phone2) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.Phone2) %>
                                <%: Html.ValidationMessageFor(model => model.Phone2) %>
                            </td>
                        </tr>

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Zip) %>
                             </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.Zip) %>
                                <%: Html.ValidationMessageFor(model => model.Zip) %>
                            </td>
                        </tr>
              </table>

                </fieldset>


        <fieldset>
            <legend>Information</legend>
            
                   <table>
                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.Product) %>
                            </td>    
                            <td>
                                <%: Html.TextBoxFor(model => model.Product) %>
                                <%: Html.ValidationMessageFor(model => model.Product) %>
                            </td>
                        </tr>

                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.ShopSize) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.ShopSize) %>
                                <%: Html.ValidationMessageFor(model => model.ShopSize) %>
                            </td>
                        </tr>
                </table>
                
        </fieldset>
        <fieldset>
            <legend>If you have a company</legend>
                <table>
                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.LegalStructure) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.LegalStructure) %>
                                <%: Html.ValidationMessageFor(model => model.LegalStructure) %>
                            </td>
                        </tr>
                        <tr>
                            <td class="width100px">
                                <%: Html.LabelFor(model => model.NameOfCompany) %>
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.NameOfCompany) %>
                                <%: Html.ValidationMessageFor(model => model.NameOfCompany) %>
                            </td>
                        </tr>
               </table>
            
        </fieldset>
        <input type="submit" value="Submit" />
    <% } %>
    
</asp:Content>

<asp:Content ContentPlaceHolderID="Sidebar" runat="server">
<center>something here</center>
</asp:Content>