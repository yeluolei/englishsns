<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Follow
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Follow</h2>
    <% using (Html.BeginForm("Index", "Follow", FormMethod.Post))
       { %>
    <p>请输入要Follow的人的账号: </p>
    <input class="editor-field" size="69" maxlength="250" name="name" type="text" />
    <input title="Search" value="确定" type="submit" />
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
