<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Merchant.Models.Webmaster>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	sendWebmaster
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <h2>Send Message to Webmaster</h2>
    <form action="/messenger/sendWebmaster" method="post" enctype="multipart/form-data">
     <textarea id="message" name="message" cols="81" rows="5"></textarea>
       <br /><br />
       Attach File: <input type="file" id="file" name="file" />
     
    Send To 
    <select name="selectWebmaster">
    <option value="0" selected>all webmaster</option>
    <%foreach (var key in Model)
      { %>
        <option value="<%:key.Id %>"> <%:key.Username %></option>
    <%} %>
    </select>
    
        <p>
            <input type="submit" value="Send Now !!!" />
        </p>

    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>