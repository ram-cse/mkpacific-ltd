<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.CreateMessageViewModel>" %>
<%@ Import Namespace="Merchant.Models" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("CREATE_MESSAGE")%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% MyRoleProvider role = new MyRoleProvider(); %>
  <h1><%: LangText.GetText("TYPE_MESSAGE_TO")%> <%if (role.IsUserInRole(Page.User.Identity.Name, "Webmaster"))
                          { %>Money Pacific<%}
                          else
                          { %> <%: LangText.GetText("REPLY_TO")%> Webmaster
                          <%} %>
    </h1>

    <fieldset class="fieldsetborder">
   
    <form action="/messenger/create" method="post" enctype="multipart/form-data">
       <textarea id="message" name="message" cols="70" rows="5"></textarea>
       <br /><br />
       <%: LangText.GetText("ATTACH_FILE")%> : <input type="file" id="file" name="file" />
      
       <input type="submit" value="<%:LangText.GetText("POST_MESSAGE") %>" />

   </form>
<br />
<br />
<table class="tablefollow">
<tr>
<th align="center" bgcolor="#339966"><center><%: LangText.GetText("SENDER")%></center></th>

<th align="center" width="400px" bgcolor="#339966"><center><%: LangText.GetText("MESSAGE|ATTACH_FILE")%></center></th>
<th align="center" bgcolor="#339966"><center><%:LangText.GetText("DATE|TIME")%></center></th>
<th align="center" bgcolor="#339966"><center><%: LangText.GetText("AVAILABLE_FOR")%></center></th>
</tr>

    <%foreach(var message in Model.ListChat){ %>
   
   <% string sender = "";
      if (message.Sender == 0) {
          sender = "Webmaster";
    %>
          <tr style="background-color:#d1e5f9">
    <% }
      else if (message.Sender == 1){ 
           sender = "Money Pacific";
    %>
          <tr style="background-color:#f5e0bb">
    <%} %>
      
<td><%:sender %></td>
<td width="400px"><%  Response.Write(message.Message); %><%if(message.DateSend.Value.ToShortDateString() == DateTime.Now.Date.ToShortDateString()) {%> <img src="/Content/Images/new.jpg" border="0" /><%} %>
<br /><br />
<%if (message.AttachFile != null)
  {%>
         <% string file = message.AttachFile.Replace("/Content/File/","");
            string urlroot = Request.Url.GetLeftPart(UriPartial.Authority);
         %>
         Attach File: <a href="<%:urlroot %><%:message.AttachFile %>"><%:file %></a>

<%} %>

</td>
<td><%: message.DateSend %></td>
<td>


<input type="checkbox" disabled checked/>MP <br />
<input type="checkbox" disabled checked/>You

</td>

</tr>
<%} %>

</table>
</fieldset>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>