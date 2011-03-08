<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<% LangText.Load(Page.User.Identity.Name); %>
    
    <h2><%: LangText.GetText("SELECT_THE_LANGUAGE_TO_USE_FOR_DEFAULT")%></h2>
    <br /><br />
    <div id="han" style="font-size:16px; color:Green;font-weight:bold;"></div>
    <fieldset><legend><%: LangText.GetText("SET_LANGUAGE")%></legend>
    <% using (Ajax.BeginForm("setlang", "Account", new AjaxOptions { UpdateTargetId = "han" }))
       { %>
      
      <%: LangText.GetText("SELECT_THE_LANGUAGE")%> <select name = "select" id="select">
        <option value="VI" <% if(ViewData["LANG"].ToString() == "VI") {%> selected <%} %> >
            <%: LangText.GetText("VIETNAMESE")%>
        </option>
        <option value="EN" <% if(ViewData["LANG"].ToString() == "EN") {%> selected <%} %> >
          <%: LangText.GetText("ENGLISH")%>
        </option>
        </select>

        <br /><br />
        <input type="submit" value="<%:LangText.GetText("SAVE") %>" />

    <%} %>

    </fieldset>   