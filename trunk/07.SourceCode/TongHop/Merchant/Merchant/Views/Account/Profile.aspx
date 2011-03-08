<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.RegisterModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("MY_PROFILE")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h1><%: LangText.GetText("MY_PROFILE")%></h1>
    
    <p><b><%: LangText.GetText("MANAGE_YOUR_PROFILE_FROM_THIS_PAGE")%></b></p>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
          <%if (Model.AccountType == 0)
            { %>


            <fieldset class="fieldsetborder">
            <legend><%:LangText.GetText("PERSONAL_ACCOUNT_INFORMATION")%></legend>
              <table>
              <tr>
                    <td>
                        <%:LangText.GetText("FIRST_NAME") %><span class="required">*</span>
                    </td>

                    <td>
                        <%: Html.TextBoxFor(model => model.FirstName, new { disabled = true})%>
                        <%: Html.ValidationMessageFor(model => model.FirstName)%>
                    </td>
              
                     <td>
                        <%:LangText.GetText("LAST_NAME") %><span class="required">*</span>
                    </td>

                    <td>
                        <%: Html.TextBoxFor(model => model.LastName, new {disabled = true })%>
                        <%: Html.ValidationMessageFor(model => model.LastName)%>
                    </td>
            </tr>
            <tr><td colspan="2">&nbsp; </td></tr>

            <tr>
                 <td><%:LangText.GetText("ADDRESS") %>1 <span class="required">*</span></td>
                 <td>
                    <%: Html.TextBoxFor(model => model.Address1) %>
                    <%: Html.ValidationMessageFor(model => model.Address1) %>
                </td>

                <td><%: LangText.GetText("ADDRESS") %>2</td>
                 <td>
                    <%: Html.TextBoxFor(model => model.Address2) %>
                    <%: Html.ValidationMessageFor(model => model.Address2) %>
                </td>
            </tr>
              <tr><td colspan="2">&nbsp;</td></tr>    
            <tr>
                <td>ZipCode</td>
                <td>
                        <%: Html.TextBoxFor(model => model.ZipCode) %>
                        <%: Html.ValidationMessageFor(model => model.ZipCode) %>
                </td>

                 <td>State</td>
                <td>
                        <%: Html.TextBoxFor(model => model.State) %>
                        <%: Html.ValidationMessageFor(model => model.State) %>
                </td>

            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <td><%: LangText.GetText("CITY") %>  <span class="required">*</span></td>
                <td>
                        <%: Html.TextBoxFor(model => model.City) %>
                        <%: Html.ValidationMessageFor(model => model.City) %>
                </td>
            
                 <td><%: LangText.GetText("COUNTRY") %>  <span class="required">*</span></td>
                 <td><input id="Text1" name="Country" type="text" value="<%: ViewData["Country"] %>" disabled /></td>
               
            
            </tr>

            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <td>
                   Email <span class="required">*</span>
                </td>
                <td>
                    <%: Html.TextBoxFor(model => model.Email) %>
                    <%: Html.ValidationMessageFor(model => model.Email) %>
                </td>
                <td>
                    <%:LangText.GetText("PHONE") %>
                </td>
                <td>
                    <%: Html.TextBoxFor(model => model.Phone) %>
                    <%: Html.ValidationMessageFor(model => model.Phone) %>
                </td>
           </tr>

      </table>
            
      

            <%}
                
            else
            { %>
          
        <fieldset style="width:615px;">
            <legend><%:LangText.GetText("BUSINESS_ACCOUNT_INFORMATION")%></legend>
                <table>
                <tr>
                     <td>
          
                        <%: LangText.GetText("COMPANY_NAME")%> <span class="required">*</span>
                    </td>
                    <td>
                        <%: Html.TextBoxFor(model => model.CompanyName, new { disabled = true})%>
                        <%: Html.ValidationMessageFor(model => model.CompanyName)%>
                    </td>
                    
                    <td>
                        <%: Html.LabelFor(model => model.Email) %>
                    </td>
                    <td>
                        <%: Html.TextBoxFor(model => model.Email) %>
                        <%: Html.ValidationMessageFor(model => model.Email) %>
                    </td>
                    
                    </tr>
                  <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td> Address1</td>
                    <td> <%: Html.TextBoxFor(model => model.Address1) %>
                         <%: Html.ValidationMessageFor(model => model.Address1) %>
                    </td>
                    <td>Address 2</td>
                    <td> <%: Html.TextBoxFor(model => model.Address2) %>
                         <%: Html.ValidationMessageFor(model => model.Address2) %></td>
                    
                
                </tr>
                  <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td>ZipCode</td>
                    <td><%: Html.TextBoxFor(model => model.ZipCode) %>
                         <%: Html.ValidationMessageFor(model => model.ZipCode) %></td>
                    <td>State</td>
                    <td><%: Html.TextBoxFor(model => model.State) %>
                         <%: Html.ValidationMessageFor(model => model.State) %></td>
                
                </tr>
                  <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td>City</td>
                    <td><%: Html.TextBoxFor(model => model.City) %>
                         <%: Html.ValidationMessageFor(model => model.City) %></td>
                    <td><%: LangText.GetText("COUNTRY") %></td>
                    <td><input id="Country" name="Country" type="text" value="<%: ViewData["Country"] %>" disabled /></td>
                
                </tr>
                  <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                <td>
                    <%: LangText.GetText("PHONE") %>
                </td>
                <td>
                        <%: Html.TextBoxFor(model => model.Phone) %>
                        <%: Html.ValidationMessageFor(model => model.Phone) %>
                </td>
                <td>
                        <%: LangText.GetText("TAX_CODE")%>
                </td>
                <td>
                <%: Html.TextBoxFor(model => model.TaxCode) %>
                <%: Html.ValidationMessageFor(model => model.TaxCode) %>
            </td>
            </tr>
           
           
               
       
               
        </table>
            
         

            
           
        
            

           
            <%} %>
  
            <p>
                <input type="submit" value="<%:LangText.GetText("SAVE") %>" />
            </p>
       

    <% } %>
     </fieldset>
    <p style="font-size:10px; margin-right:28px;">
    By the Data Processing, Data Files and Individual Liberties Act of January 6, 1978, users have the right 
to access and correct personal data on file at companies. To view or edit your personal data, visit the 
"My profile" section or write directly to us.

    </p>
    
</asp:Content>


<asp:Content ContentPlaceHolderID="SidebarInformation" runat="server">
<h3>Warning !</h3>
<p>Complete this form carefully.<br /><br />
We use this information to manage your account, inform you, and record your earning money.
</p>
<p><strong>Common Questions </strong></p>
<ul>
<li>To change your first or last name, please <strong><a href="#">contact us.</a></strong></li>

<li><a href="#">Why Money Pacific  need banking information ?</a></li>

<li><a href="#">What is the swift number ?</a></li>
<li><a href="#">How to receive outpayment?</a></li>


</ul>

<div class="readmore"><a href="#">More questions...</a></div>
</asp:Content>