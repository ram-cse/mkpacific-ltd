<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Money Pacific Administrator Login   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Money Pacific Administrator</h2>


     <% using (Html.BeginForm()) { %>
       <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                   Username
                </div>
                <div class="editor-field">
                    <input type="text" name="username" />
                </div>
                
                <div class="editor-label">
                    Password
                </div>
                <div class="editor-field">
                    <input type="text" name="password" />
                </div>
                <input type="checkbox" name="remember"/> Remember password?
                <p>
                    <input type="submit" value="Login" />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>
