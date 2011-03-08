<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Problem.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Follow Report Problem  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login To Follow Report Problem </h2>


     <% using (Html.BeginForm()) { %>
       <div>
            <fieldset>
                <legend>Report Problem User</legend>
                
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
                    <input type="password" name="password" />
                </div>
                <input type="checkbox" name="remember"/> Remember password?
                <p>
                    <input type="submit" value="Login" />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>
