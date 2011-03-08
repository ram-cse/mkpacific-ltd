<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.WebsiteViewModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("ADD_AND_EDIT_WEBSITE")%> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: LangText.GetText("ADD_AND_EDIT_WEBSITE")%></h1>
    <fieldset class="fieldsetborder">
     <p>
    <%: LangText.GetText("IN_THIS_PAGE_YOUR_CAN_EASILY_ADD_AND_EDIT_ALL_YOUR_WEBSITE_TO_USE_MONEY_PACIFIC_PAYMENT_SOLUTION")%><br />
    <%: LangText.GetText("DO_IT_NOW_:_YOU_JUST_NEED_5_MINUTES_TO_ADD_A_NEW_WEB_SITE") %>
    </p>


    <%if(Model.list.Count != 0){ %>
    <h2><%: LangText.GetText("MY_WEBSITE")%></h2>
    <table class="tableindex2">
    <tr>
    <th><%: LangText.GetText("WEBSITE_TITLE")%></th>
    <th>URL</th>
    <th></th>
    <th></th>
    </tr>
    
    <% foreach (var w in Model.list)
       { %>
       <tr>
       <td><%:Html.ShortString(w.Title,15) %></td>
       <td><%: w.URL %></td>
      
       <td>
       <%: Html.ActionLink(LangText.GetText("EDIT"),"Edit","Website", new { id = w.Id, height = 400, width = 520 }, new { @class = "thickbox" }) %>
       </td>
        <td><a href="Delete/<%:w.Id %>"><%: LangText.GetText("DELETE") %></a></td>
       </tr>
    <%} %>
    </table>
   
    <%} %><br /><br />

      <h2><%: LangText.GetText("ADD_NEW_WEBSITE")%></h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend><%: LangText.GetText("WEBSITE_INFORMATION")%></legend>
            
            <div class="editor-label">
               <%: LangText.GetText("WEBSITE_TITLE")%>
            </div>
            <div class="editor-field">
               <input type="text" id="Title" name="Title" />
            </div>
            
            <div class="editor-label">
               URL
            </div>
            <div class="editor-field">
                <input type="text" id="URL" name="URL" />
            </div>
            
            <div class="editor-label">
               <%: LangText.GetText("DESCRIPTION")%>
            </div>
            <div class="editor-field">
                <textarea id="Description" name="Description" cols="47",rows="5" ></textarea>
            </div>
            
            
            <p>
                <input type="submit" value="<%: LangText.GetText("ADD") %>" />
            </p>
        </fieldset>

    <% } %>
    <h2><%: LangText.GetText("PACIFIC_CODE_TEST")%></h2>
    <span style="margin-left:40px;"><%: LangText.GetText("THIS_PACIFIC_CODE_IS_USED_TO_MAKE_TEST")%></span>
    <p><strong>xxxx-xxxx-xxxx-xxxx</strong></p>
   </fieldset>
</asp:Content>

<asp:Content ContentPlaceHolderID="SidebarInformation" runat="server">
<h3>Common Questions </h3>
<ul>
<li><a href="#">How to install Money Pacific on your website?</a></li>
<li><a href="#">How the first registered website receive 600 000 VND?</a></li>
</ul>
<div class="readmore"><a href="#">More questions...</a></div>

<br /><br /><br /><br /><br /><br />

<center>
<div class="call">NEED HELP ?
<br/>

You don’t know how to do ...
<br/>

we will help you for FREE<br/>
Phone <span class="phonenumber"><%: ViewData["phone"] %></span> <br/>
Email: <a href="/messenger/create" >PACIFIC MESSENGER</a>
<br />
<span style="font-size:16px;">Y!M: <a href="ymsgr:sendIM?web_moneypacific"><img src="http://opi.yahoo.com/online?u=web_moneypacific&amp;m=g&amp;t=1" border="0" alt="" /> </a></span>

</div>
</center>


</asp:Content>
