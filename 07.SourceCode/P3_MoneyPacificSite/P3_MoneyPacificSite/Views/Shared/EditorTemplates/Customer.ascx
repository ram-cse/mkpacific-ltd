<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<P3_MoneyPacificSite.Models.Customer>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>---</legend>            
            <table>
                <tr>
                    <td>
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.ID) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.ID) %>
                            <%: Html.ValidationMessageFor(model => model.ID) %>
                        </div>            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.Phone) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.Phone) %>
                            <%: Html.ValidationMessageFor(model => model.Phone) %>
                        </div>            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.FirstName) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.FirstName) %>
                            <%: Html.ValidationMessageFor(model => model.FirstName) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.LastName) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.LastName) %>
                            <%: Html.ValidationMessageFor(model => model.LastName) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.Username) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.Username) %>
                            <%: Html.ValidationMessageFor(model => model.Username) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.Password) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.Password) %>
                            <%: Html.ValidationMessageFor(model => model.Password) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.Email) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.Email) %>
                            <%: Html.ValidationMessageFor(model => model.Email) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.Address) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.Address) %>
                            <%: Html.ValidationMessageFor(model => model.Address) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.CreateDate) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.CreateDate, String.Format("{0:g}", Model.CreateDate)) %>
                            <%: Html.ValidationMessageFor(model => model.CreateDate) %>
                        </div>          
                    </td>
                    <td>
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.LastDate) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.LastDate, String.Format("{0:g}", Model.LastDate)) %>
                            <%: Html.ValidationMessageFor(model => model.LastDate) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.CurrentPacificCoded) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.CurrentPacificCoded) %>
                            <%: Html.ValidationMessageFor(model => model.CurrentPacificCoded) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.TotalAmount) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.TotalAmount) %>
                            <%: Html.ValidationMessageFor(model => model.TotalAmount) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.NumberTransaction) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.NumberTransaction) %>
                            <%: Html.ValidationMessageFor(model => model.NumberTransaction) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.BadTransaction) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.BadTransaction) %>
                            <%: Html.ValidationMessageFor(model => model.BadTransaction) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.SecurCode) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.SecurCode) %>
                            <%: Html.ValidationMessageFor(model => model.SecurCode) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.Pincode) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.Pincode) %>
                            <%: Html.ValidationMessageFor(model => model.Pincode) %>
                        </div>
            
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.StatusID) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.StatusID) %>
                            <%: Html.ValidationMessageFor(model => model.StatusID) %>
                        </div>
                    </td>
                </tr>
            </table>  
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>