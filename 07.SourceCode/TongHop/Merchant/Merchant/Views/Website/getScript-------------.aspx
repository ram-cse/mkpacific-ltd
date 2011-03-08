<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.Script>" %>
<%@ Import Namespace="Merchant.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditScript
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Get Script </h2>
   
   <%
       MPWebmasterEntities StoreDb = new MPWebmasterEntities();
       var website = from m in StoreDb.Websites
                     where(m.Webmaster.Username == Page.User.Identity.Name)
                     select m;
       
        %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
       
    <table>

    <tr>
    <td valign="top">
   <div class="editor-label">
   Select Website
   </div>
    <select id="website" name="website" disabled>
    <% foreach (var x in website)
       { 
           
           %>
    <option value="<%:x.Id%>" <% if(x.Id == Model.WebsiteId){ %>
    selected
    <%} %>
    ><%:x.URL %></option>
    <%} %>
    </select>

     <input type="checkbox" id="virtual1" name="virtual1" 
    <% if(Model.Virtual == 1) {%> checked
     <%} %> disabled
     /> Virtual Product
     
    <input type="checkbox" id="virtual1" name="deliveryAddress1" 
    <% if(Model.CustomerAddress == 1) {%> checked 
     <%} %> disabled 
     /> Delivery Address

    <div class="editor-label">
   Script Name
   </div>                                          
   <input type="text" id="scriptName" name="scriptName" value="<%:Model.ScriptName %>" disabled />

    <div class="editor-label">
   Item Name
   </div>
   <input type="text" id="ItemName" name="ItemName" value="<%: Model.ItemName %>" disabled/>
   
    <div class="editor-label">
   Item Id
   </div>
   <input type="text" id="ItemId" name="ItemId" value="<%: Model.ItemId %>" disabled/>

     <div class="editor-label">
    Price
   </div>
   
   <input type="text" id="Price" name="Price"  value="<%: Model.Price %>" disabled/>
  
   <select name="Currency" id="Currency" disabled>
  
   <option value="VND" <% if(Model.Currency == "VND") {%> selected <%} %> >VND</option>
   <option value="USD" <% if(Model.Currency == "USD") {%> selected <%} %> >USD</option>
   </select>
   </td>
   <td>
   
   <span id="picture">
   <% if(Model.ButtonStyle==1){ %>
   <img src="/Content/Images/bt1.jpg" border="0"/>
   <%} %>
    <% if(Model.ButtonStyle==2){ %>
   <img src="/Content/Images/bt2.jpg" border="0"/>
   <%} %>
   
   </span>
   
   <td valign="top">
    <div class="editor-label">
    Button Style
   </div>
   <select id="buttonStyle" name="buttonStyle" disabled>
   <option value="1" <% if(Model.ButtonStyle == 1) {%> selected <%} %> >Button 1</option>
   <option value="2" <% if(Model.ButtonStyle == 2) {%> selected <%} %>>Button 2</option>
   </select>

    <div class="editor-label">
    Return Url(If success)
   </div> 
   <input type="text" id="urlsuccess" name="urlsuccess" value="<%: Model.URLSuccess %>" disabled/>

    <div class="editor-label">
    Return Url(If fail)
   </div>
   <input type="text" id="urlfail" name="urlfail" value="<%: Model.URLFail %>" disabled/>

    <div class="editor-label">
    Email to Receive Notification
   </div>
   <input type="text" id="EmailNotification" name="EmailNotification" value="<%: Model.Email %>" disabled/>

   
   </td>
   </tr>
   </table>
   <script type="text/javascript">
       function returnEdit(id) {
           window.location = "http://localhost:50315/website/script/" + id;
       }

       function SelectAll(id) {
           document.getElementById(id).focus();
           document.getElementById(id).select();
       }
    </script>

  <textarea id="codeplace" name="codeplace" cols="50" rows="5" onclick="SelectAll('codeplace')"><%:Model.Code %></textarea> 
    

    <center><input type="button" value="Edit Script" onclick="returnEdit(<%: ViewData["scriptId"] %>);"/></center>
   <%} %>
</asp:Content>
