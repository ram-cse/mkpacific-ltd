<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("SUBMIT_PROBLEM")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: LangText.GetText("SUBMIT_PROBLEM")%></h1>
    <fieldset class="fieldsetborder">
    <% using (Html.BeginForm()){ %>
    
    
     <div class="display-label"><%: LangText.GetText("MESSAGE") %></div>
    <textarea id="description" name="description" cols="50" rows="4"></textarea>


    <div class="display-label"><%: LangText.GetText("REASON")%></div>
    <select name="reason">
    <option value="421"><%: LangText.GetText("DELIVERY_WITH_LOW_QULITY")%></option>
    <option value="422"><%: LangText.GetText("DELIVERY_BROKEN")%></option>
    <option value="423"><%: LangText.GetText("NOT_DELIVERY")%></option>
    </select>

   
     <p>
     <input type="submit" value="OK" />
     </p>
    
    <%} %>
    </fieldset>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>something here</center>
</asp:Content>