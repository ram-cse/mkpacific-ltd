<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<P4_MoneyPacificSite.Models.StoreManager>" %>

    <fieldset>
            <legend>Thong tin</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Id) %>
                <%: Html.ValidationMessageFor(model => model.Id) %>
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
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NameOfStore) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NameOfStore) %>
                <%: Html.ValidationMessageFor(model => model.NameOfStore) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StatusId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StatusId) %>
                <%: Html.ValidationMessageFor(model => model.StatusId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Address) %>
                <%: Html.ValidationMessageFor(model => model.Address) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address2) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Address2) %>
                <%: Html.ValidationMessageFor(model => model.Address2) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Phone) %>
                <%: Html.ValidationMessageFor(model => model.Phone) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Phone2) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Phone2) %>
                <%: Html.ValidationMessageFor(model => model.Phone2) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EmailAlert) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EmailAlert) %>
                <%: Html.ValidationMessageFor(model => model.EmailAlert) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EmailBill) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EmailBill) %>
                <%: Html.ValidationMessageFor(model => model.EmailBill) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.WebSite) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.WebSite) %>
                <%: Html.ValidationMessageFor(model => model.WebSite) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Zip) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Zip) %>
                <%: Html.ValidationMessageFor(model => model.Zip) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Town) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Town) %>
                <%: Html.ValidationMessageFor(model => model.Town) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Country) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Country) %>
                <%: Html.ValidationMessageFor(model => model.Country) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LegalStructure) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LegalStructure) %>
                <%: Html.ValidationMessageFor(model => model.LegalStructure) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NameOfCompany) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NameOfCompany) %>
                <%: Html.ValidationMessageFor(model => model.NameOfCompany) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.VATNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.VATNumber) %>
                <%: Html.ValidationMessageFor(model => model.VATNumber) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Product) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Product) %>
                <%: Html.ValidationMessageFor(model => model.Product) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ShopSize) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ShopSize) %>
                <%: Html.ValidationMessageFor(model => model.ShopSize) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NumberOfShop) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NumberOfShop) %>
                <%: Html.ValidationMessageFor(model => model.NumberOfShop) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StoreInternetAccess) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StoreInternetAccess) %>
                <%: Html.ValidationMessageFor(model => model.StoreInternetAccess) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
