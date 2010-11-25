<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<F02_MVCAJAX.ViewModels.KhachHangViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
 
    <script type="text/javascript">
        function handleUpdate(context) {
            // Load and deserialize the returned JSON data
            alert("hello");

            var json = context.get_data();
            alert(json.toString());
            var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

            // Update the page elements
            $('#row-' + data.DeleteId).fadeOut('slow');
            $('#update-message').text("xong roi !...");
        }
    </script>

    <h2>Danh Sach Khach Hang</h2>

    <p><%:Html.ActionLink("Tạo mới", "Create", "KhachHang") %></p>

    <div id="update-message">le thanh dung</div>
    <table>
        <tr>
            <th></th>
            <th>Tài khoản</th>
            <th>Mật khẩu</th>
            <th>Mô tả</th>
            <th>Thư điện tử</th>
        </tr>
        <% foreach (var item in Model.KhachHangs)
           { %>
           
        <tr id="row-<%:item.Id%>">
            <td><%: Ajax.ActionLink("Xóa", "Delete"
                    , new {id = item.Id}
                    , new AjaxOptions{ OnSuccess = "handleUpdate" }) %></td>
            <td><%:item.Username %></td>
            <td><%:item.Password %></td>
            <td><%:item.Description %></td>
            <td><%:item.Email  %></td>
            
        </tr>
        <%} %>
    </table>
</asp:Content>

