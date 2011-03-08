<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Merchant.Models.Payment>" %>

<%@ Import Namespace="Merchant.Helper" %>
 
 	<% LangText.Load(Page.User.Identity.Name); %>
     <h2> <%: LangText.GetText("SET_PAYMENT")%> </h2>
    <div id="han"></div>
     
  
    <% using (Ajax.BeginForm("SetPayment", "Account", new AjaxOptions { UpdateTargetId = "han"}))
       {%>
       
        
        <fieldset  style="width:560px;">
            <legend><%: LangText.GetText("RECEIVER_INFORMATION")%></legend>
            <table class="tablesetpm">
            <tr>
            <td>
               <%: LangText.GetText("NAME")%> <span class="required">*</span>
               </td>
               <td>
                <%: Html.TextBoxFor(model => model.Name)%>
                <%: Html.ValidationMessageFor(model => model.Name)%>
           </td>
           <td>
                      
                <%: LangText.GetText("ADDRESS")%>1 <span class="required">*</span>
                </td>
                <td>
                <%: Html.TextBoxFor(model => model.Address)%>
                <%: Html.ValidationMessageFor(model => model.Address)%>
                </td>
            </tr>
            
          <tr>
          <td>
                <%: LangText.GetText("ADDRESS")%>2
        </td>
        <td>
         
                <%: Html.TextBoxFor(model => model.Ward)%>
                <%: Html.ValidationMessageFor(model => model.Ward)%>
        </td>
        <td>
         
                <%: LangText.GetText("CITY")%> <span class="required">*</span>
        </td>
        <td>       
            
                <%: Html.TextBoxFor(model => model.City)%>
                <%: Html.ValidationMessageFor(model => model.City)%>
           </td>
            </tr>
           
           <tr>
           <td>ZipCode</td>        
           <td><%: Html.TextBoxFor(model=>model.ZipCode) %></td>
           <td><%: LangText.GetText("COUNTRY") %><span class="required">*</span></td> 
           <td><input id="Country" name="Country" type="text" value="<%: ViewData["Country"] %>" disabled /></td>
           </tr>

           
           
           <tr>
            <td>
                Email <span class="required">*</span>
            </td>
            <td>
                <%: Html.TextBoxFor(model => model.Email)%>
                <%: Html.ValidationMessageFor(model => model.Email)%>
          </td>
            <td>
          
                <%: LangText.GetText("PHONE")%>
           </td>
           <td>
                <%: Html.TextBoxFor(model => model.Phone)%>
                <%: Html.ValidationMessageFor(model => model.Phone)%>
                </td>


            </tr>
            <tr>
            <td>
            
               <%:LangText.GetText("TYPE_PAYMENT")%>
           </td>
            <td>
                   <select id="type" name="type">
                   <option value="0"
                   <% if (Model.TypePayment == 0){%>
                   selected
                   <%} %>
                 >Cash</option>
                   <option value="1"
                   <% if (Model.TypePayment == 1){%>
                   selected
                   <%} %>
                     >Bank Tranfer</option>
                   </select>
                   </td>
            <td>ATM Number</td>
            <td><input type="text" id="ATM" name="ATM" value="<%: ViewData["ATM"] %>" /></td>
            </tr> 
           
            <tr>
            <td>Bank</td>
            <td><input type="text" id="Bank" name="Bank" value="<%: ViewData["Bank"] %>" /></td>
            </tr>
            </table>
            <p>
                <input type="submit" value="<%:LangText.GetText("SAVE") %>" />
            </p>
        </fieldset>

    <% } %>

   
      